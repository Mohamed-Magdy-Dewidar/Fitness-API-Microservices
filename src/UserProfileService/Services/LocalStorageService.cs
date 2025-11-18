using UserProfileService.Contracts;

namespace UserProfileService.Services;

public class LocalStorageService : IFileStorageService
{

    private readonly IWebHostEnvironment _environment;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private const string ProfileImagesFolder = "images/profiles";

    public LocalStorageService(IWebHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
    {
        _environment = environment;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<string> SaveFileAsync(IFormFile file, string userId)
    {

        var webRootPath = _environment.WebRootPath;
        if (string.IsNullOrEmpty(webRootPath))
        {
            webRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        }

        var folderPath = Path.Combine(webRootPath, ProfileImagesFolder);
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        var extension = Path.GetExtension(file.FileName);
        var fileName = $"{userId}_{DateTime.UtcNow.Ticks}{extension}";
        var filePath = Path.Combine(folderPath, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        var relativeUrl = $"/{ProfileImagesFolder}/{fileName}";

        return relativeUrl;
    }

    public async Task<bool> DeleteFileAsync(string? fileUrl)
    {
        if (string.IsNullOrEmpty(fileUrl))
        {
            return false;
        }

        var relativePath = fileUrl.TrimStart('/');

        var webRootPath = _environment.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        var filePath = Path.Combine(webRootPath, relativePath);

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        return true;
    }
}
