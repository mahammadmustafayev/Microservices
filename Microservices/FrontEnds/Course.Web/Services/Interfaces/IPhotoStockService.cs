using Course.Web.Models.PhotoStocks;

namespace Course.Web.Services.Interfaces;

public interface IPhotoStockService
{
    Task<PhotoViewModel> UploadPhoto(IFormFile photo);

    Task<bool> DeletePhoto(string photoUrl);
}
