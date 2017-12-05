using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MY.Northwind.WebUI.Entity
{
    public class CustomIdentityDbContext:IdentityDbContext<CustomIdentityUser,CustomIdentityRole,string>
    {

        public CustomIdentityDbContext(DbContextOptions<CustomIdentityDbContext> options):base(options)
            //customidentity db context tipindeki konfigürasyonları base e yolla
        {
            
        }
    }
}
