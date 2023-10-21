using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace online_shop_backend.Services.Interfaces;

/// <summary>
/// Service for uploading pictures
/// </summary>
public interface IPictureService
{
    /// <summary>
    /// Uploads picture
    /// </summary>
    /// <param name="files"></param>
    /// <param name="file">Файл картинки</param>
    /// <returns>Путь к файлу</returns>
    public Task UploadPictureAsync(IFormFileCollection files);
}