using Course.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Course.Shared.ControllerBases
{
    public class CustomeBaseController : ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
