using Cortex.Mediator;
using DevSkill.Shop.Application.Contracts;
using DevSkill.Shop.Application.Features.Categories.Command;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace DevSkill.Shop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CategoryController(ILogger<CategoryController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var model = new CategoryAddCommand();
            return View(model);
        }
    }
}
