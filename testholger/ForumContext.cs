using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testholger
{
    public class ForumContext : DbContext
    {

        public DbSet<Users> Users { get; set; }
        public DbSet<Topics> Topics { get; set; }

        public DbSet<Posts> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ForumDB;Trusted_Connection=True;");
        }

        public ForumContext(DbContextOptions<ForumContext> dbContext)
            :base( dbContext)
        {

        }
    }
}
