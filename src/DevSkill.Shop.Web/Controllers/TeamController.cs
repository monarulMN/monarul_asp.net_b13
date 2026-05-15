using DevSkill.Shop.Application.Contracts;
using DevSkill.Shop.Domain.Entities;
using DevSkill.Shop.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevSkill.Shop.Web.Controllers
{
    public class TeamController : Controller
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public TeamController(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index(Team team)
        {
            _unitOfWork.TeamRepository.Add(new Team { Id = Guid.NewGuid(), Name = "Developer" });
            _unitOfWork.Save();
            return View();
        }

        
    }
}
