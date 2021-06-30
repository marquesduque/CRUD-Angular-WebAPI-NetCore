using Microsoft.EntityFrameworkCore;
using SampleWebApiAspNetCore.Entities;

namespace SampleWebApiAspNetCore.Repositories
{
    public class productDbContext : DbContext
    {
        public productDbContext(DbContextOptions<productDbContext> options)
           : base(options)
        {

        }

        public DbSet<productEntity> productItems { get; set; }

    }
}
