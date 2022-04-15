using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
