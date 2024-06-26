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
    //[Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
       
        public CompanyController(IUnitOfWork unitOfWork)
        
        {
            _unitOfWork = unitOfWork;
           
        }

        public async Task<IActionResult> Index()
        {
            // Fetch the list of Companys asynchronously and convert to List
            List<Company> objCompanyList = (await _unitOfWork.Company.GetAllAsync()).ToList();

            

            // Return the view with the list of Companys
            return View(objCompanyList);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            

            if (id == null || id == 0)
            {
                // Create
                return View(new Company());
            }
            else
            {
                // Update
                Company companyObj = await _unitOfWork.Company.GetAsync(u => u.Id == id);
                
                return View(companyObj);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Upsert(Company CompanyObj)
        {
            if (ModelState.IsValid)
            {
               
                if (CompanyObj.Id == 0) 
                { 
                await _unitOfWork.Company.AddAsync(CompanyObj);
                }
                else
                {
                    await _unitOfWork.Company.UpdateAsync(CompanyObj);
                }
                
                await _unitOfWork.SaveAsync();
                TempData["success"] = "Company created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(CompanyObj);
            }
        }


        #region Api calls

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Company> objCompanyList = (await _unitOfWork.Company.GetAllAsync()).ToList();
            return Json(new { data = objCompanyList });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return Json(new { success = false, message = "Invalid ID" });
            }

            var CompanyToDlt = await _unitOfWork.Company.GetAsync(u => u.Id == id);

            if (CompanyToDlt == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            await _unitOfWork.Company.RemoveAsync(CompanyToDlt);
            await _unitOfWork.SaveAsync();
            return Json(new { success = true, message = "Delete successful." });
        }


        #endregion


    }
}
