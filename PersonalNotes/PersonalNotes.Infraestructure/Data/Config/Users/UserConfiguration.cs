using Microsoft.EntityFrameworkCore;
using PersonalNotes.Entities.Users;

namespace PersonalNotes.Infraestructure.Data.Config.Users
{
    public static class UserConfiguration
    {
        public static void ConfigureUser(ModelBuilder userBuilder)
        {
            userBuilder.Entity<User>(u =>
            {
                u.ToTable("tblUser");
                u.HasKey(u => u.Id);
                u.Property(u => u.Id).HasColumnName("id");
                u.Property(u => u.Name).HasColumnName("name");
                u.Property(u => u.Password).HasColumnName("password");
            });
        }
    }
}
