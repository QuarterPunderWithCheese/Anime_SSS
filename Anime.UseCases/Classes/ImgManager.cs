using Microsoft.AspNetCore.Http;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using DomainServices.DTO.ImgManagerDto;

namespace DomainServices.Classes
{
    public class ImgManager : IImgManager
    {
        public  Bitmap ResizeImage(ImgResizerDto dto)
        { 
            var destRect = new Rectangle(0, 0, dto.width, dto.height);
            var destImage = new Bitmap(dto.width, dto.height);

            destImage.SetResolution(dto.image.HorizontalResolution, dto.image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(dto.image, destRect, 0, 0, dto.image.Width,dto.image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        
        public bool AssertThatImage(IFormFile file)
        {
            var name = file.FileName;
            var extension = name //Extract extension
                .Substring(name.LastIndexOf('.'), name.Length - name.LastIndexOf('.')) 
                .ToLower();

            if (extension == ".png" || extension == ".jpg" || extension == ".jpeg")
                return 1 != 0;

            return false;
        }
        
        public async Task<Image> ParseIFormFileToImageOrDefault(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }

            if (!AssertThatImage(file))
            {
                return null;
            }

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                using (var img = Image.FromStream(memoryStream))
                {
                    return img;
                }
            }
        }

        public bool TryChangeAvatar(TryChangeAvatarDto dto)
        {
            string Path = "wwwroot/Img/" +  dto.file.Name;
            if (!AssertThatImage(dto.file))
            {
                return false;
            }

            Image image = ParseIFormFileToImageOrDefault(dto.file).Result;

            ImgResizerDto dto1 = new ImgResizerDto
            {
                image =  image,
                height = dto.h,
                width = dto.w
            };
            ///!!!!!!!!!!
            /// CreateDirectoryforUser
            
            //!!!!!!!!!!!
            Bitmap bitmap = ResizeImage(dto1);
            bitmap.Save(Path,ImageFormat.Jpeg);
            return true;
        }
        
        
        
    }
}