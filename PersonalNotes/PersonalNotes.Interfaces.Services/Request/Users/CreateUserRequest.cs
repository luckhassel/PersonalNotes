namespace PersonalNotes.Interfaces.Services.Request.Users
{
    public class CreateUserRequest : IRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
