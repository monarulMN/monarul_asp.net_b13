namespace MaleFashion.Web.Models.Account
{
    public class RegisterConfirmModel
    {
        public string? Email { get; set; }

        
        public bool DisplayConfirmAccountLink { get; set; }

        
        public string? EmailConfirmationUrl { get; set; }
    }
}
