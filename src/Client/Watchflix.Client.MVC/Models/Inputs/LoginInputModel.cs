namespace Watchflix.Client.MVC.Models.Inputs
{
    public class LoginInputModel
    {
        public UserForLoginDto UserForLoginDto { get; set; }
    }

    public class UserForLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
