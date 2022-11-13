using System.IdentityModel.Tokens.Jwt;
using Test.Data.Repositories.Interface;
using TestWebAPI.DTOS.Person;
using TestWebAPI.Helpers;
using TestWebAPI.Services.Interface;

namespace TestWebAPI.Services.Implement
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _userRepository;

        public PersonService(IPersonRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public LoginRespone Login(LoginRequest request)
        {
            var user =  _userRepository
                .GetOne(user => user.Username == request.Username &&
                                        user.Password == request.Password);

            var token = JWTHelper.CreateJwtToken(new PersonModel
            {
                Id = user.Id,
                Role = user.Role,
            });

            return new LoginRespone
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                Token = token
            };
        }

        
    }
}
