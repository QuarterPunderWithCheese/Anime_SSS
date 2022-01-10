using System.ComponentModel.DataAnnotations;
using DomainModel.Entities;
using Microsoft.AspNetCore.Identity;

namespace DomainServices.DTO
{
    public class UserRegistrationDto
    {
        [Required]
        public  string Name { get; set;}
        [Required]
        public string Email { get; set; }
        [Required]
        public  string Password { get; set; }
    }
}