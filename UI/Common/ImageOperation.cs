using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;


namespace OHD.UI.Common
{
        public interface IImageOperation<T> where T : class
            {
              Task<string> UploadImageAsync(T model, IFormFile imageFile);
            }

    public class ImageOperation<T> : IImageOperation<T> where T : class
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageOperation(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadImageAsync(T model, IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                throw new ArgumentException("Image file cannot be null or empty.");
            }

            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            // Update the image property of the model with the saved file name
            // model.ImageFile = uniqueFileName;

            return uniqueFileName;
        }
    }

}
