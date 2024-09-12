using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SampleProductManagementApp.Data
{
    public class ApplicationDataSeed
    {
        private static Guid adminId = Guid.NewGuid();
        private static Guid adminRoleId = Guid.NewGuid();

        public static void SeedData(ModelBuilder builder)
        {
            builder.Entity<IdentityUser>().HasData(Users());
            builder.Entity<IdentityRole>().HasData(Roles());
            builder.Entity<IdentityUserRole<string>>().HasData(UserRoles());
        }

        private static List<IdentityRole> Roles()
        {
            return new List<IdentityRole>
           {
               new IdentityRole {
                   Id = adminRoleId.ToString(),
                   Name = "Administrator",
                   NormalizedName = "administrator"
               }
           };
        }

        private static List<IdentityUser> Users()
        {
            return new List<IdentityUser>
           {
               new IdentityUser
               {
               Id = adminId.ToString(),
               UserName = "admin@website.test",
               NormalizedUserName = "ADMIN@WEBSITE.TEST",
               Email = "admin@website.test",
               NormalizedEmail = "ADMIN@WEBSITE.TEST",
               PasswordHash = "AQAAAAIAAYagAAAAEA9RV9IZ7uTwqvt+REGCBaXcXW7qF2ysOuzTODtktTyJRd/aFjaC5IZA1t2rM6yuhQ==",  // Password!123
               SecurityStamp = "OXWX2FMWOQVU6TOIVTOEP5P3WDU2DPXF",
               ConcurrencyStamp = "be5e4901-b686-4333-bc22-b7353115e2a7",
               EmailConfirmed = true
               }
           };
        }

        private static List<IdentityUserRole<string>> UserRoles()
        {
            return new List<IdentityUserRole<string>>
           {
               new IdentityUserRole<string>
               {
                   UserId = adminId.ToString(),
                   RoleId = adminRoleId.ToString()
               }
           };
        }
    }
}
