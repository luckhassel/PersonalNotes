namespace PersonalNotes.Services.Authentication.Password
{
    public static class PasswordService
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool IsPasswordCorrect(string password, string passwordHashed)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHashed);
        }
    }
}
