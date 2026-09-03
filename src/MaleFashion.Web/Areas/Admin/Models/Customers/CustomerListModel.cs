using MaleFashion.Domain.Utilities;
using System.ComponentModel.DataAnnotations;

namespace MaleFashion.Web.Areas.Admin.Models.Customers
{
    public class CustomerListModel : DataTables
    {
        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? LastName { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(20)]
        public string? PhoneNumber { get; set; }

    }
}
