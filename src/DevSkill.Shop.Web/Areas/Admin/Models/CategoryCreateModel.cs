using System.ComponentModel.DataAnnotations;

namespace DevSkill.Shop.Web.Areas.Admin.Models
{
    public class CategoryCreateModel
    {
        public Guid Id { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; }
        public bool IsActive { get; set; }

        [Required, StringLength(200)]
        public string ImageName { get; set; }
    }
}
