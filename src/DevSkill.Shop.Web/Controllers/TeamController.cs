using DevSkill.Shop.Application.Contracts;
using DevSkill.Shop.Domain.Entities;
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
        public IActionResult Index(TeamMember teamMember)
        {
            _unitOfWork.TeamMemberRepository.Add(new TeamMember { 
                Id = Guid.NewGuid(), 
                Name = "Asif", 
                Email = "example123@gmail.com",
                Address = "Dhaka",
                Phone = "01734567890"
            });
            _unitOfWork.Save();
            return View();
        }
    }
}
