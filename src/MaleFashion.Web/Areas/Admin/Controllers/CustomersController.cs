using Cortex.Mediator;
using MaleFashion.Application.Features.Customers.Query;
using MaleFashion.Domain.Entities;
using MaleFashion.Domain.Utilities;
using MaleFashion.Web.Areas.Admin.Models.Customers;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace MaleFashion.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomersController : Controller
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public CustomersController(ILogger<CustomersController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var model = new CustomerListModel();
            return View(model);
        }

        [HttpPost]
        public async Task<JsonResult> GetPagedCustomers([FromBody] CustomerListModel model)
        {
            try
            {
                var query = _mapper.Map<GetAllCustomersByPagingQuery>(model);
                query.SearchText = model.Search.Value;
                query.SortText = model.FormatSortExpression("Name", "PhoneNumber");

                var (users, total, totalDisplay) = await _mediator.SendQueryAsync<GetAllCustomersByPagingQuery,
                    (IList<User>, int, int)>(query);

                var customer = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = (from user in users
                            select new string[]
                            {
                                HttpUtility.HtmlEncode(user.FirstName),
                                user.Email,
                                user.Id.ToString(),
                            }).ToArray()
                };

                return Json(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Falid to get CustomerList");

                return Json(DataTables.EmptyResult);
            }
        }
    }
}
