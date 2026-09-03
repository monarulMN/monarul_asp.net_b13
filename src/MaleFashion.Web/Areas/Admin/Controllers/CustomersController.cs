using Cortex.Mediator;
using MaleFashion.Application.Features.Customers.Command;
using MaleFashion.Application.Features.Customers.Query;
using MaleFashion.Domain.Entities;
using MaleFashion.Domain.Utilities;
using MaleFashion.Infrastructure.Extensions;
using MaleFashion.Infrastructure.Identity;
using MaleFashion.Web.Areas.Admin.Models;
using MaleFashion.Web.Areas.Admin.Models.Customers;
using MaleFashion.Web.Codes;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web;

namespace MaleFashion.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomersController : Controller
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;


        public CustomersController(ILogger<CustomersController> logger, 
            IMediator mediator, 
            IMapper mapper, 
            UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var model = new CustomerListModel();
            return View(model);
        }


        public async Task<IActionResult> Update(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetCustomerByIdQuery { Id = id };
                var user = await _mediator.SendQueryAsync(query, cancellationToken);

                if (user == null)
                {
                    TempData.Put(Constants.ResponseTempKey,
                        new ResponseModel
                        {
                            Message = "Customer not found.",
                            Type = ResponseTypes.Danger
                        });

                    return RedirectToAction(nameof(Index));
                }

                var model = _mapper.Map<CustomerUpdateModel>(user);
                return View(model);
            }
            catch (Exception ex)
            {
                const string message = "Failed to load customer for update.";

                _logger.LogError(ex, message);

                TempData.Put(Constants.ResponseTempKey,
                    new ResponseModel
                    {
                        Message = message,
                        Type = ResponseTypes.Danger
                    });

                return RedirectToAction(nameof(Index));

            }
        }



        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(CustomerUpdateModel model,
            CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var command = _mapper.Map<CustomerUpdateCommand>(model);
                    await _mediator.SendCommandAsync(command, cancellationToken);

                    TempData.Put(Constants.ResponseTempKey,
                        new ResponseModel
                        {
                            Message = "Customer's information updated successfully.",
                            Type = ResponseTypes.Success
                        });

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    const string message = "Failed to update customer's information.";
                    _logger.LogError(ex, message);
                    TempData.Put(Constants.ResponseTempKey,
                        new ResponseModel
                        {
                            Message = message,
                            Type = ResponseTypes.Danger
                        });

                    return View(model);
                }
            }
            else
            {
                TempData.Put(Constants.ResponseTempKey,
                    new ResponseModel
                    {
                        Message = "Please provide all information.",
                        Type = ResponseTypes.Warning
                    });
            }

            return View(model);
        }



        [HttpPost]
        public async Task<JsonResult> GetPagedCustomers([FromBody] CustomerListModel model,
            CancellationToken cancellationToken)
        {
            try
            {
                var query = _mapper.Map<GetAllCustomersByPagingQuery>(model);
                query.SearchText = model.Search.Value;
                query.SortText = model.FormatSortExpression("FirstName", "LastName", "Email", "PhoneNumber");

                var (users, total, totalDisplay) = await _mediator.SendQueryAsync(query, cancellationToken);

                var customer = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = (from user in users
                            select new string[]
                            {
                                HttpUtility.HtmlEncode(user.FirstName),
                                HttpUtility.HtmlEncode(user.LastName),
                                HttpUtility.HtmlEncode(user.Email),
                                HttpUtility.HtmlEncode(user.PhoneNumber),
                                user.Id.ToString(),
                            }).ToArray()
                };

                return Json(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get CustomerList");

                return Json(DataTables.EmptyResult);
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var command = _mapper.Map<CustomerDeleteCommand>(new { Id = id });
                await _mediator.SendCommandAsync(command, cancellationToken);

                TempData.Put(Constants.ResponseTempKey,
                    new ResponseModel
                    {
                        Message = "Customer deleted successfully.",
                        Type = ResponseTypes.Success
                    });

                
            }
            catch (Exception ex)
            {
                const string message = "Failed to delete customer";

                _logger.LogError(ex, message);

                TempData.Put(Constants.ResponseTempKey,
                    new ResponseModel
                    {
                        Message = message,
                        Type = ResponseTypes.Danger
                    });
                
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
