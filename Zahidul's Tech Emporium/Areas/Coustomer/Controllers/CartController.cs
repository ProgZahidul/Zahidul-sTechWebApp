using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Stripe;
using Stripe.Checkout;
using System.Security.AccessControl;
using System.Security.Claims;
using Zahidul_s_Tech_Emporium.Models;
using Zahidul_s_Tech_Emporium.Models.ViewModels;
using Zahidul_s_Tech_Emporium.Repository.IRepository;

namespace Zahidul_s_Tech_Emporium.Areas.Coustomer.Controllers
{
    [Area("Coustomer")]
    [Authorize]
    public class CartController : Controller
    {  
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public ShoppingCartVM ShoppingCartVM { get; set; }
        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartVM = new()
            {
                shoppingCarts = await _unitOfWork.ShoppingCart.GetAllAsync(u => u.ApplicationUserId == userId, includeProperties: "Product"),

                OrderHeader = new()
            };
            foreach (var cart in ShoppingCartVM.shoppingCarts)
            {
                cart.Price = GetPriceBasedOnQuantity(cart);
                ShoppingCartVM.OrderHeader.OrderTotal += (cart.Price * cart.Count);
            }
            return View(ShoppingCartVM);
        }
        public async Task<IActionResult> Summary()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartVM = new()
            {
                shoppingCarts = await _unitOfWork.ShoppingCart.GetAllAsync(u => u.ApplicationUserId == userId, includeProperties: "Product"),
                OrderHeader = new()
            };

            ShoppingCartVM.OrderHeader.ApplicationUser = await _unitOfWork.ApplicationUser.GetAsync(u => u.Id == userId);
            ShoppingCartVM.OrderHeader.Name = ShoppingCartVM.OrderHeader.ApplicationUser.Name;
            ShoppingCartVM.OrderHeader.City = ShoppingCartVM.OrderHeader.ApplicationUser.City;
            ShoppingCartVM.OrderHeader.PhoneNumber = ShoppingCartVM.OrderHeader.ApplicationUser.PhoneNumber;
            ShoppingCartVM.OrderHeader.Address = ShoppingCartVM.OrderHeader.ApplicationUser.Address;
            ShoppingCartVM.OrderHeader.PostalCode = ShoppingCartVM.OrderHeader.ApplicationUser.PostalCode;

            foreach (var cart in ShoppingCartVM.shoppingCarts)
            {
                cart.Price = GetPriceBasedOnQuantity(cart);
                ShoppingCartVM.OrderHeader.OrderTotal += (cart.Price * cart.Count);
            }
            return View(ShoppingCartVM);
        }


        [HttpPost]
        [ActionName("Summary")]
        public async Task<IActionResult> SummaryPOST()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartVM.shoppingCarts =await _unitOfWork.ShoppingCart.GetAllAsync(u => u.ApplicationUserId == userId, includeProperties: "Product");

            ShoppingCartVM.OrderHeader.OrderDate = System.DateTime.Now;
            ShoppingCartVM.OrderHeader.ApplicationUserId = userId;

           ApplicationUser applicationUser = await _unitOfWork.ApplicationUser.GetAsync(u => u.Id == userId);
           
            foreach (var cart in ShoppingCartVM.shoppingCarts)
            {
                cart.Price = GetPriceBasedOnQuantity(cart);
                ShoppingCartVM.OrderHeader.OrderTotal += (cart.Price * cart.Count);
            }

            if (applicationUser.CompanyId.GetValueOrDefault() == 0)
            {
                //regular coustomer accound and need to capture payment
                ShoppingCartVM.OrderHeader.PaymentStatus = SD.PymentStatusPending;
                ShoppingCartVM.OrderHeader.OrderStatus = SD.StatusPending;
            }
            else
            {
                ShoppingCartVM.OrderHeader.PaymentStatus = SD.PymentStatusDelayedPayment;
                ShoppingCartVM.OrderHeader.OrderStatus = SD.StatusApproved;

            }

            await _unitOfWork.OrderHeader.AddAsync(ShoppingCartVM.OrderHeader);
            await _unitOfWork.SaveAsync();


            foreach(var cart in ShoppingCartVM.shoppingCarts)
            {
                OrderDetail orderDetail = new()
                {
                    ProductId = cart.ProductId,
                    OrderHeaderId = ShoppingCartVM.OrderHeader.Id,
                    Price = cart.Price,
                    Count = cart.Count
                };
                await _unitOfWork.OrderDetail.AddAsync(orderDetail);
                await _unitOfWork.SaveAsync();
            }

            if (applicationUser.CompanyId.GetValueOrDefault() == 0)
            {
                //it is a regular coustomer account and we need to capture payment
                //stripe logic

                var domain = "https://localhost:7112/";
                var options = new Stripe.Checkout.SessionCreateOptions
                {
                    SuccessUrl = domain + $"coustomer/cart/OrderConfirmation?id={ShoppingCartVM.OrderHeader.Id}",
                    CancelUrl = domain + $"coustomer/cart/index",
                    LineItems = new List<SessionLineItemOptions>(),
                    Mode = "payment",
                };
                foreach (var item in ShoppingCartVM.shoppingCarts)
                {
                    var sessionLineItem = new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = (long)(item.Price * 100), // $20.50 => 2050
                            Currency = "usd",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = item.Product.Title
                            }
                        },
                        Quantity = item.Count
                    };
                    options.LineItems.Add(sessionLineItem);
                }
               
                var service = new SessionService();

               Session session= service.Create(options);

               await _unitOfWork.OrderHeader.UpdateStripePaymentID(ShoppingCartVM.OrderHeader.Id, session.Id, session.PaymentIntentId);
              await  _unitOfWork.SaveAsync();
                Response.Headers.Add("Location", session.Url);
                return new StatusCodeResult(303);

            }


            return RedirectToAction(nameof(OrderConfirmation),new {id=ShoppingCartVM.OrderHeader.Id});
        }

       

        public async Task <IActionResult> OrderConfirmation(int id)
        {

            OrderHeader orderHeader = await _unitOfWork.OrderHeader.GetAsync(u => u.Id == id, includeProperties: "ApplicationUser");

            if (orderHeader.PaymentStatus != SD.PymentStatusDelayedPayment)
            {
                //this is an order by customer

                var service = new SessionService();
                Session session = service.Get(orderHeader.SessionId);

                if (session.PaymentStatus.ToLower() == "paid")
                {
                   await _unitOfWork.OrderHeader.UpdateStripePaymentID(id, session.Id, session.PaymentIntentId);
                    await _unitOfWork.OrderHeader.UpdateStatus(id, SD.StatusApproved, SD.PymentStatusApproved);
                    await _unitOfWork.SaveAsync();
                }
           

            }



            // Ensure that GetAllAsync is awaited and that its result is used correctly
            var shoppingCarts = await _unitOfWork.ShoppingCart.GetAllAsync(u => u.ApplicationUserId == orderHeader.ApplicationUserId);

            // Convert to list
            var shoppingCartList = shoppingCarts.ToList();

            await _unitOfWork.ShoppingCart.RemoveRangeAsync(shoppingCarts);
            await _unitOfWork.SaveAsync();

            return View(id);
        }





        public async Task<IActionResult> plus(int cartId)
        {
            var cartFromDb = await _unitOfWork.ShoppingCart.GetAsync(u => u.Id == cartId);
            cartFromDb.Count += 1;
            await _unitOfWork.ShoppingCart.UpdateAsync(cartFromDb);
            await _unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Minus(int cartId)
        {
            var cartFromDb = await _unitOfWork.ShoppingCart.GetAsync(u => u.Id == cartId);
            if (cartFromDb.Count <= 1)
            {
                await _unitOfWork.ShoppingCart.RemoveAsync(cartFromDb);
            }
            else
            {
                cartFromDb.Count -= 1;
                await _unitOfWork.ShoppingCart.UpdateAsync(cartFromDb);

            }

            await _unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Remove(int cartId)
        {
            var cartFromDb = await _unitOfWork.ShoppingCart.GetAsync(u => u.Id == cartId);
            await _unitOfWork.ShoppingCart.RemoveAsync(cartFromDb);
            await _unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
        private double GetPriceBasedOnQuantity(ShoppingCart shoppingCart)
        {
            return shoppingCart.Product.Price;
        }
    }
}
