using DomainModel.Entities;
using Microsoft.AspNetCore.Identity;

namespace DomainServices.DTO
{
    public class ChangeUserRoleDto
    {
        public int Id { get; set; }
        public string Role { get; set; }
        
    }
}