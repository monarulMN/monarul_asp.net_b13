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
            _unitOfWork.CategoryRepository.Add(new Category
            {
                Id = Guid.NewGuid(),
                Name = "sample category",
                Description = "Electric device",
                ImageUrl = "category.png",
                IsActive = true,
                CreatedDate = DateTime.Now
            });
            //_unitOfWork.Save();
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
