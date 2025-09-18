using Domain.Enums;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class UploadsController : ControllerBase
{
    private readonly IUploadService _uploadService;

    public UploadsController(IUploadService uploadService)
    {
        _uploadService = uploadService;
    }


    [HttpPost("{menuItemId}")]
    public async Task<IActionResult> UploadImage(int menuItemId, string file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded");

        var uploadId = await _uploadService.StartProcessingAsync(menuItemId, file);

        return Ok(new { uploadId, status = "Processing" });
    }


    [HttpGet("{uploadId}/status")]
    public async Task<IActionResult> GetStatus(string uploadId)
    {
        var timeout = TimeSpan.FromSeconds(25);
        var startTime = DateTime.UtcNow;

        while (DateTime.UtcNow - startTime < timeout)
        {
            var status = _uploadService.GetStatus(uploadId);

            if (status is Status.Completed or Status.Failed)
            {
                return Ok(new { uploadId, status = status.ToString() });
            }

            await Task.Delay(1000);
        }

        return Ok(new { uploadId, status = "Processing" });
    }
}

