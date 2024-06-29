using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Zahidul_s_Tech_Emporium.Models;
using Zahidul_s_Tech_Emporium.Models.ViewModels;
using Zahidul_s_Tech_Emporium.Repository.IRepository;

namespace Zahidul_s_Tech_Emporium.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHosteEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        
        {
            _unitOfWork = unitOfWork;
            _webHosteEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            // Fetch the list of products asynchronously and convert to List
            List<Product> objProductList = (await _unitOfWork.Product.GetAllAsync(includeProperties:"Category")).ToList();

            

            // Return the view with the list of products
            return View(objProductList);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            ProductVM productVM = new()
            {
                CategoryList = (await _unitOfWork.Category.GetAllAsync())
                    .Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    }),
                Product = new Product()
            };

            if (id == null || id == 0)
            {
                // Create
                return View(productVM);
            }
            else
            {
                // Update
                productVM.Product = await _unitOfWork.Product.GetAsync(u => u.Id == id);
                if (productVM.Product == null)
                {
                    return NotFound();
                }
                return View(productVM);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Upsert(ProductVM productVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHosteEnvironment.WebRootPath; // Corrected typo
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    if (!string.IsNullOrEmpty(productVM.Product.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, productVM.Product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);  
                        }
                    }



                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream); // Use async version
                    }
                    productVM.Product.ImageUrl = @"\images\product\" + fileName;
                }
                if (productVM.Product.Id == 0) 
                { 
                await _unitOfWork.Product.AddAsync(productVM.Product);
                }
                else
                {
                    await _unitOfWork.Product.UpdateAsync(productVM.Product);
                }
                
                await _unitOfWork.SaveAsync();
                TempData["success"] = "Product created/updated successfully";
                return RedirectToAction("Index");
            }
            else
            {
                productVM.CategoryList = (await _unitOfWork.Category.GetAllAsync())
                    .Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    });
                return View(productVM);
            }
        }


        #region Api calls

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Product> objProductList = (await _unitOfWork.Product.GetAllAsync(includeProperties: "Category")).ToList();
            return Json(new { data = objProductList });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return Json(new { success = false, message = "Invalid ID" });
            }

            var productToDlt = await _unitOfWork.Product.GetAsync(u => u.Id == id);

            if (productToDlt == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            var oldImagePath = Path.Combine(_webHosteEnvironment.WebRootPath,productToDlt.ImageUrl.TrimStart('\\', '/'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            await _unitOfWork.Product.RemoveAsync(productToDlt);
            await _unitOfWork.SaveAsync();
            return Json(new { success = true, message = "Delete successful." });
        }


        #endregion


    }
}
