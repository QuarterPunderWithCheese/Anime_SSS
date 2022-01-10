using System.ComponentModel.DataAnnotations;

namespace WebApplication.ViewModels
{
    public class AddRoleViewModel
    {   
        [Required]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
    }
}