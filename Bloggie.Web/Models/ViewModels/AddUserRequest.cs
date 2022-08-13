namespace Bloggie.Web.Models.ViewModels
{
    public class AddUserRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
    }
}
