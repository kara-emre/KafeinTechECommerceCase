using Identity.Api.Model.Dtos;
using Identity.Api.Model.Entity;

namespace Identity.Api.Services
{
    public static class UserService
    {
        private static List<UserEntity> DummyUserList = new()
        {
            new UserEntity()
            {
                Id = 5005,
                Address = "İstanbul / Turkey",
                Mail = "mr.emrekara@outlook.com",
                Name = "Emre",
                Password = "123"
            },
            new UserEntity()
            {
                Id = 5006,
                Address = "Ankara / Turkey",
                Mail = "frontend.developer@gmail.com",
                Name = "Ayşe",
                Password = "abcd"
            },
            new UserEntity()
            {
                Id = 5007,
                Address = "Izmir / Turkey",
                Mail = "fullstack.developer@yahoo.com",
                Name = "Ahmet",
                Password = "5678"
            },
            new UserEntity()
            {
                Id = 5008,
                Address = "Bursa / Turkey",
                Mail = "mobile.developer@hotmail.com",
                Name = "Mehmet",
                Password = "efgh"
            },
            new UserEntity()
            {
                Id = 5009,
                Address = "Antalya / Turkey",
                Mail = "data.scientist@icloud.com",
                Name = "Elif",
                Password = "91011"
            }
        };

        public static UserLoginResponse UserCheckLogin(UserLoginRequest request)
        {
            var user = DummyUserList.Where(x => x.Password == request.Password && x.Mail == request.Email).FirstOrDefault();
            if (user is not null)
            {
                var tokenService = new JwtTokenService("E9sSHvBNzDP9ZVZGpAE9sSHvBNzDP9ZVZGpA", "KafeinTech", "KafeinTechUser");
                var token = tokenService.GenerateToken(user);

                return new()
                {
                    Token = token
                };
            }
            else
            {
                throw new Exception("Invalid user");
            }
        }

    }
}
