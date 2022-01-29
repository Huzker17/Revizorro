using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revizorro.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<User> ContextUser { get; set; }
        public DbSet<Places> Places { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }
    }
}
