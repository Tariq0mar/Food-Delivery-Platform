using Domain.Enums;

namespace Domain.Interfaces.Services;

public interface IUploadService
{
    Task<string> StartProcessingAsync(int menuItemId, String file);
    Status GetStatus(string uploadId);
}