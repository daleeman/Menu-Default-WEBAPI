using Menu_Default_WEBAPI.Data;
using Menu_Default_WEBAPI.Models;

namespace Menu_Default_WEBAPI.Infrastructure
{
    public class CategoryRepository: RepositoryBase<CategoryModel>,ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
