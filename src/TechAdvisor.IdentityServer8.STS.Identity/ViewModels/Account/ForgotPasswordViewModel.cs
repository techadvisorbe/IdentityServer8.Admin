using System.ComponentModel.DataAnnotations;
using TechAdvisor.IdentityServer8.Shared.Configuration.Configuration.Identity;

namespace TechAdvisor.IdentityServer8.STS.Identity.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        public LoginResolutionPolicy? Policy { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }

        public string Username { get; set; }
    }
}
