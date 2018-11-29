using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CST465Lab8.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the CST465Lab8User class
    public class CST465Lab8User : IdentityUser
    {
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public bool Field3 { get; set; }

    }
}
