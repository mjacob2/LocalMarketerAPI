using Microsoft.AspNetCore.Hosting;

namespace LocalMarketer.ApplicationServices
{
        public class ImageDecoder : IImageDecoder
        {
                private readonly IWebHostEnvironment hostingEnvironment;
                public ImageDecoder(IWebHostEnvironment hostingEnvironment)
                {
                        this.hostingEnvironment = hostingEnvironment;
                }
                public string ExtractAndSave(string image)
                {
                        string base64Data = image.Split(',')[1];
                        byte[] bytes = Convert.FromBase64String(base64Data);
                        string fileExtension = GetFileExtensionFromImageData(image);
                        string uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
                        string wwwrootPath = hostingEnvironment.WebRootPath;
                        string filePath = Path.Combine(wwwrootPath, "ProductsImages", uniqueFileName);
                        File.WriteAllBytes(filePath, bytes);

                        return uniqueFileName;
                }

                private string GetFileExtensionFromImageData(string imageData)
                {
                        string mime = imageData.Split(':')[1].Split(';')[0];

                        switch (mime)
                        {
                                case "image/jpeg":
                                        return ".jpg";
                                case "image/png":
                                        return ".png";
                                case "image/gif":
                                        return ".gif";
                                default:
                                        throw new NotSupportedException("Unsupported image format.");
                        }
                }
        }
}
