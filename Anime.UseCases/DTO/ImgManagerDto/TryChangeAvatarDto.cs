using DomainModel.Entities;
using Microsoft.AspNetCore.Http;

namespace DomainServices.DTO.ImgManagerDto
{
    public class TryChangeAvatarDto
    {
        public IFormFile file { get; set; }
        public int w { get; set; }
        public int h { get; set; }
        public string Email { get; set; }
    }
}