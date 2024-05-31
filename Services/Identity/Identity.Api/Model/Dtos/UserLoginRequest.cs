namespace Identity.Api.Model.Dtos
{
    public class UserLoginRequest
    {
        /// <summary>
        /// Dummy User Name
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        ///  Dummy Password
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
