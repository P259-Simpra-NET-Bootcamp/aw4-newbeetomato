using SimApi.Data;

namespace SimApi.Data.Repository;

public interface ICategoryRepository : IGenericRepository<Data.Category>
{
    IEnumerable<Data.Category> FindByName (string name);
    int GetAllCount();
}
