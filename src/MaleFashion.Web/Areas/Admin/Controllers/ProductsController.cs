using Cortex.Mediator;
using MaleFashion.Application.Contracts;
using MaleFashion.Application.Features.Products.Query;
using MaleFashion.Domain.Entities;
using MaleFashion.Domain.Utilities;
using MaleFashion.Web.Areas.Admin.Models.Products;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace MaleFashion.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductsController(ILogger<ProductsController> logger, 
            IMapper mapper, IMediator mediator)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<JsonResult> GetPagedProducts([FromBody] ProductListModel model)
        {
            try
            {
                var query = _mapper.Map<GetAllProductsByPagingQuery>(model);
                query.SearchText = model.Search.Value;
                query.SortText = model.FormatSortExpression("Name", "Price");

                var (items, total, totalDisplay) = await _mediator.SendQueryAsync<GetAllProductsByPagingQuery, 
                    (IList<Product>, int, int)>(query);

                var product = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = (from item in items
                            select new string[]
                            {
                                @HttpUtility.HtmlEncode(item.Name),
                                item.Price.ToString(),
                                item.Id.ToString()

                            }).ToArray()
                };

                return Json(product);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Falied to get Product list ");
                return Json(DataTables.EmptyResult);
            }
        }
    }
}
