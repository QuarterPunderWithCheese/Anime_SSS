using DomainModel.Entities;
using Microsoft.AspNetCore.Identity;

namespace DomainServices.DTO
{
    public class GetUserByIdDto
    {
        public int Id { get; set; }
        public User user { get; set; }
    }
}