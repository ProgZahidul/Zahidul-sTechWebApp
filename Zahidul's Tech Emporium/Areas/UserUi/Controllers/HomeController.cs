using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Zahidul_s_Tech_Emporium.Models;
using Zahidul_s_Tech_Emporium.Repository.IRepository;

namespace Zahidul_s_Tech_Emporium.Areas.UserUi.Controllers
{
    [Area("UserUi")]
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
            Product product = (await _unitOfWork.Product.GetAsync(u=>u.Id== productId, includeProperties: "Category"));
            return View(product);
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
