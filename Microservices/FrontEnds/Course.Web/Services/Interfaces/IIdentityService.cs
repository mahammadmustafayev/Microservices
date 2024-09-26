using Course.Shared.DTOs;
using Course.Web.Models;
using IdentityModel.Client;

namespace Course.Web.Services.Interfaces;

public interface IIdentityService
{
    Task<Response<bool>> SignIn(SigninInput signinInput);
    Task<TokenResponse> GetAccessTokenByRefreshToken();
    Task RevokeRefreshToken();
}
