using MaleFashion.Application.Contracts;
using MaleFashion.Domain.Entities;
using MaleFashion.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MaleFashion.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApplicationUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IApplicationUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            //_unitOfWork.ProductRepository.Add(new Product
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "sample category",
            //    Description = "Electric device",
            //    Price = 2000,
            //    DiscountPrice = 0,
            //    StockQuantity = 100,
            //    SKU = "THS-002",
            //    MainImageUrl = "category.png",
            //    IsFeatured = true,
            //    IsActive = true,
            //    CreatedDate = DateTime.Now,
            //    CategoryId = Guid.Parse("0bf999e7-f582-4224-9ae7-adc7b2e1c5f1")
            //});
            ////_unitOfWork.Save();
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
