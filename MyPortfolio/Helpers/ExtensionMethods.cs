namespace MyPortfolio.Helpers
{
    public static class ExtensionMethods
    {
        public static async Task<string> TryUploadImageAsync(this IFormFile image, string uploadsFolderName, string webRootPath)
        {
            string path = null;
            try
            {
                if (image != null)
                {
                    var documentsDirectory = Path.Combine("wwwroot", "Documents", uploadsFolderName);

                    if (!Directory.Exists(documentsDirectory))
                        Directory.CreateDirectory(documentsDirectory);

                    path = Path.Combine("Documents", uploadsFolderName, Guid.NewGuid().ToString() + "_" + image.FileName);
                    string filePath = Path.Combine(webRootPath, path);
                    using var fileStream = new FileStream(filePath, FileMode.Create);
                    await image.CopyToAsync(fileStream);
                }
                return path;
            }
            catch (Exception e) when (e is IOException || e is Exception)
            {
                return "";
            }
        }
    }
}
