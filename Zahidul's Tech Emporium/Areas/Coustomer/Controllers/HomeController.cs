using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Zahidul_s_Tech_Emporium.Models;
using Zahidul_s_Tech_Emporium.Repository.IRepository;

namespace Zahidul_s_Tech_Emporium.Areas.Coustomer.Controllers
{
    [Area("Coustomer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> objProductList = (await _unitOfWork.Product.GetAllAsync(includeProperties: "Category")).ToList();
            return View(objProductList);
        }

        public async Task<IActionResult> Details(int productId)
        {
            ShoppingCart cart = new() {

                Product = await _unitOfWork.Product.GetAsync(u => u.Id == productId, includeProperties: "Category"),
                Count = 1,
                ProductId = productId
        };
            
            return View(cart);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Details(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.ApplicationUserId = userId;

            ShoppingCart cartFromDb = await _unitOfWork.ShoppingCart.GetAsync(u => u.ApplicationUserId == userId && u.ProductId == shoppingCart.ProductId);

            if (cartFromDb != null)
            {
                //if shopping cart is exixt
                cartFromDb.Count += shoppingCart.Count;
                await _unitOfWork.ShoppingCart.UpdateAsync(cartFromDb);
            }
            else
            {
                //if shopping cart is not exixt
                await _unitOfWork.ShoppingCart.AddAsync(shoppingCart);
            }

            TempData["success"] = "Cart Updated Successfuly";
            await _unitOfWork.SaveAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
