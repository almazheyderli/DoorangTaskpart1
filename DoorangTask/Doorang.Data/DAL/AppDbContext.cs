using Doorang.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doorang.Data.DAL
{
    public class AppDbContext : IdentityDbContext<User>

    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Explorer> explorers { get; set; }
    }
}
