using Menu_Default_WEBAPI.Data;
using Menu_Default_WEBAPI.Models;

namespace Menu_Default_WEBAPI.Infrastructure
{
    public class FoodRepository : RepositoryBase<FoodModel>, IFoodRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public FoodRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext= dbContext;
        }
    }
}
