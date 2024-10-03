using Course.Shared.DTOs;
using Course.Web.Models.PhotoStocks;
using Course.Web.Services.Interfaces;

namespace Course.Web.Services;

public class PhotoStockService : IPhotoStockService
{
    private readonly HttpClient _httpClient;

    public PhotoStockService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> DeletePhoto(string photoUrl)
    {
        var response = await _httpClient.DeleteAsync($"photos?photoUrl={photoUrl}");
        return response.IsSuccessStatusCode;
    }

    public async Task<PhotoViewModel> UploadPhoto(IFormFile photoFile)
    {
        if (photoFile == null || photoFile.Length <= 0)
        {
            return null;
        }
        // örnek dosya ismi= 203802340234.jpg
        var randonFilename = $"{Guid.NewGuid()}{Path.GetExtension(photoFile.FileName)}";

        using var ms = new MemoryStream();

        await photoFile.CopyToAsync(ms);

        ms.Position = 0;

        var multipartContent = new MultipartFormDataContent();

        //var streamContent = new StreamContent(ms);
        //streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(photo.ContentType);
        //multipartContent.Add(streamContent, "photo", randonFilename);
        if (ms.CanRead && ms.CanWrite)
        {
            multipartContent.Add(new ByteArrayContent(ms.ToArray()), "photo", randonFilename);

        }
        else
        {
            return null;
        }


        var response = await _httpClient.PostAsync("photos", multipartContent);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var responseSuccess = await response.Content.ReadFromJsonAsync<Response<PhotoViewModel>>();

        return responseSuccess?.Data;
    }
}
