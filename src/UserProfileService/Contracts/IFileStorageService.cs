namespace UserProfileService.Contracts;


public interface IFileStorageService
{
    /// <summary>
    /// Saves a file to storage and returns the public-facing URL.
    /// </summary>
    /// <param name="file">The IFormFile to save.</param>
    /// <param name="userId">The ID of the user, used for naming/partitioning.</param>
    /// <returns>The accessible URL of the saved file.</returns>
    Task<string> SaveFileAsync(IFormFile file, string userId);

    /// <summary>
    /// Deletes a file from storage, given its URL.
    /// </summary>
    /// <param name="fileUrl">The URL of the file to delete.</param>
    Task<bool> DeleteFileAsync(string? fileUrl);
}



