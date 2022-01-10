using System.Drawing;
using System.Threading.Tasks;
using DomainServices.DTO.ImgManagerDto;
using Microsoft.AspNetCore.Http;

namespace DomainServices
{
    public interface IImgManager
    {
        Bitmap ResizeImage(ImgResizerDto dto);

        bool AssertThatImage(IFormFile file);

        Task<Image> ParseIFormFileToImageOrDefault(IFormFile file);
        bool TryChangeAvatar(TryChangeAvatarDto dto);
    }
}