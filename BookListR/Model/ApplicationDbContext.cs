using System;
using Microsoft.EntityFrameworkCore;
namespace BookListR.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        public DbSet<CBook> Book { get; set; }

    }
}
