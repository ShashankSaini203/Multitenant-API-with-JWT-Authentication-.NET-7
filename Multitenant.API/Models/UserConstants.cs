using System.Collections.Generic;

namespace Multitenant.API.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() { Username = "admin", EmailAddress = "admin@email.com", Password = "admin", GivenName = "Admin", Surname = "Admin", Role = "Administrator" },
        };
    }

}
