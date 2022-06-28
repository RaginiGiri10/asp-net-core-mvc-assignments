using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MobileAPPMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAPPMVC.EFDBContext
{
    public class MobileDbContext: IdentityDbContext<IdentityUser>
    {

        public MobileDbContext(DbContextOptions<MobileDbContext> options) : base(options)
        {

        }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Mobile> Mobiles { get; set; }

    }
}
