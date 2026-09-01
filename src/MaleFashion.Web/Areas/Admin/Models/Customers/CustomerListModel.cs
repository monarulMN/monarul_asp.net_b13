using MaleFashion.Domain.Utilities;

namespace MaleFashion.Web.Areas.Admin.Models.Customers
{
    public class CustomerListModel : DataTables
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

    }
}
