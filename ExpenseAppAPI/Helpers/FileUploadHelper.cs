namespace ExpenseAppAPI.Helpers
{
    public static class FileUploadHelper
    {
        public static async Task<string> SaveImageAsync(IFormFile imageFile, string folderPath = "assets/images")
        {
            if (imageFile == null || imageFile.Length == 0)
                return string.Empty;

            var uploadsRootFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderPath);

            if (!Directory.Exists(uploadsRootFolder))
                Directory.CreateDirectory(uploadsRootFolder);

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            var filePath = Path.Combine(uploadsRootFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return Path.Combine(folderPath, uniqueFileName).Replace("\\", "/");
        }
    }
}
