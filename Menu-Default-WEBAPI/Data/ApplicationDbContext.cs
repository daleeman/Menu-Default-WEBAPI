using Menu_Default_WEBAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Menu_Default_WEBAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
        public DbSet<FoodModel> Foods { get; set; }
        public DbSet<CategoryModel> Categorys { get; set; }
    }
}
