using SimApi.Data.Context;
using SimApi.Data;

namespace SimApi.Data.Repository;

public class CategoryRepository : GenericRepository<Data.Category>, ICategoryRepository
{
    public CategoryRepository(SimEfDbContext context) : base(context)
    {

    }

    public IEnumerable<Data.Category> FindByName(string name)
    {
        var list = dbContext.Set<Data.Category>().Where(c => c.Name.Contains(name)).ToList();
        return list;
    }

    public int GetAllCount()
    {
        return dbContext.Set<Data.Category>().Count();
    }
}
