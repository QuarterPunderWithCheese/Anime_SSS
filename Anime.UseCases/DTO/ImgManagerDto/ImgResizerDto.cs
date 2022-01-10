using System.Drawing;
using Microsoft.AspNetCore.Http;

namespace DomainServices.DTO.ImgManagerDto
{
    public class ImgResizerDto
    {
        public Image image { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
}