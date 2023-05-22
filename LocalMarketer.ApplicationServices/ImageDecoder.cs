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
                public string Extract(string image)
                {
                        // Extract the base64-encoded image data from the Data URL
                        string base64Data = image.Split(',')[1];
                        // Convert the base64-encoded image data to a byte array
                        byte[] bytes = Convert.FromBase64String(base64Data);
                        // Generate a unique file name with the appropriate extension based on the MIME type
                        string fileExtension = GetFileExtensionFromImageData(image);
                        string uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
                        // Get the wwwroot folder path
                        string wwwrootPath = hostingEnvironment.WebRootPath;
                        // Create the destination file path
                        string filePath = Path.Combine(wwwrootPath, "ProductsImages", uniqueFileName);
                        // Write the byte array to the destination file path
                        File.WriteAllBytes(filePath, bytes);

                        return uniqueFileName;
                }

                private string GetFileExtensionFromImageData(string imageData)
                {
                        // Extract the MIME type from the Data URL
                        string mime = imageData.Split(':')[1].Split(';')[0];

                        // Determine the file extension based on the MIME type
                        switch (mime)
                        {
                                case "image/jpeg":
                                        return ".jpg";
                                case "image/png":
                                        return ".png";
                                case "image/gif":
                                        return ".gif";
                                // Add more cases for other supported image types if needed
                                default:
                                        throw new NotSupportedException("Unsupported image format.");
                        }
                }
        }
}
