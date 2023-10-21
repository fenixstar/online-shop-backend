using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using online_shop_backend.Services.Interfaces;

namespace online_shop_backend.Services.Implementations;

internal class PictureService : IPictureService
{
    private const string UploadPath = "uploads";

    public async Task UploadPictureAsync(IFormFileCollection files)
    {
        foreach (var item in files)
        {
            var fullPath = $"{UploadPath}/{item.FileName}";
            
            await using var fileStream = new FileStream(fullPath, FileMode.Create);
            await item.CopyToAsync(fileStream);
        }
    }
}