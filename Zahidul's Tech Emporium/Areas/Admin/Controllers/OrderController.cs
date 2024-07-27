using Microsoft.AspNetCore.Mvc;
using Zahidul_s_Tech_Emporium.Models;
using Zahidul_s_Tech_Emporium.Repository;
using Zahidul_s_Tech_Emporium.Repository.IRepository;

namespace Zahidul_s_Tech_Emporium.Areas.Admin.Controllers
{
    [Area("admin")]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<OrderHeader> objOrderHeaders = (await _unitOfWork.OrderHeader.GetAllAsync(includeProperties: "ApplicationUser")).ToList();
            return Json(new { data = objOrderHeaders });
        }
    }
}
