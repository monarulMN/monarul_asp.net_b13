using MaleFashion.Domain.Utilities;
using System.ComponentModel.DataAnnotations;

namespace MaleFashion.Web.Areas.Admin.Models.Categories
{
    public class CategoryListModel : DataTables
    {
        [StringLength(100)]
        public string Name { get; set; } 
    }
}
