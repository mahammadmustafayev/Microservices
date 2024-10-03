using Course.Shared.ControllerBases;
using Course.Shared.DTOs;
using CourseMicroservices.PhotoStock.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CourseMicroservices.PhotoStock.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PhotosController : CustomeBaseController
{
    [HttpPost]
    public async Task<IActionResult> PhotoSave(IFormFile photo, CancellationToken cancellationToken)
    {
        if (photo != null && photo.Length > 0)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photo.FileName);

            using var stream = new FileStream(path, FileMode.Create);
            await photo.CopyToAsync(stream, cancellationToken);

            var returnPath = photo.FileName;

            PhotoDTO photoDto = new() { Url = returnPath };

            return CreateActionResultInstance(Response<PhotoDTO>.Success(photoDto, 200));
        }

        return CreateActionResultInstance(Response<PhotoDTO>.Fail("photo is empty", 400));
    }


    [HttpDelete]
    public IActionResult PhotoDelete(string photoUrl)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photoUrl);
        if (!System.IO.File.Exists(path))
        {
            return CreateActionResultInstance(Response<NoContent>.Fail("photo not found", 404));
        }

        System.IO.File.Delete(path);

        return CreateActionResultInstance(Response<NoContent>.Success(204));
    }
}
