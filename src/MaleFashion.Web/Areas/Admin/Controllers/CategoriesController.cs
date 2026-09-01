using Cortex.Mediator;
using MaleFashion.Application.Features.Categories.Query;
using MaleFashion.Domain.Utilities;
using MaleFashion.Web.Areas.Admin.Models.Categories;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using MaleFashion.Domain.Entities;
using System.Web;

namespace MaleFashion.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CategoriesController(ILogger<CategoriesController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var model = new CategoryListModel();
            return View(model);
        }


        [HttpPost]
        public async Task<JsonResult> GetPagedCategories([FromBody] CategoryListModel model)
        {
            try
            {
                var query = _mapper.Map<GetAllCategoriesByPagingQuery>(model);
                query.SearchText = model.Search.Value;
                query.SortText = model.FormatSortExpression("Name", "CreatedAt");

                var (categories, total, totalDisplay) = await _mediator.SendQueryAsync<GetAllCategoriesByPagingQuery, 
                    (IList<Category>, int, int)>(query);

                var category = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = (from categoty in categories
                            select new string[]
                            {
                                HttpUtility.HtmlEncode(categoty.Name),
                                categoty.Description,
                                categoty.Id.ToString()
                            }).ToArray()
                };
                return Json(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get category list!");
                return Json(DataTables.EmptyResult);
            }
        }
    }
}
