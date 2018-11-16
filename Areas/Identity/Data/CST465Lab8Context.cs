using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CST465Lab8.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CST465Lab8.Models
{
    public class CST465Lab8Context : IdentityDbContext<CST465Lab8User>
    {
        public CST465Lab8Context(DbContextOptions<CST465Lab8Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
