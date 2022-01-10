using System.ComponentModel.DataAnnotations;

namespace WebApplication.ViewModels
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
     
        public string Name { get; set; }
        
        public string Password { get; set; }
    }
}