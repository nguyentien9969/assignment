using Microsoft.AspNetCore.Authentication;
using TestWebAPI.DTOS.Person;

namespace TestWebAPI.Services.Interface
{
    public interface IPersonService
    {
        LoginRespone Login(LoginRequest request);
    }
}
