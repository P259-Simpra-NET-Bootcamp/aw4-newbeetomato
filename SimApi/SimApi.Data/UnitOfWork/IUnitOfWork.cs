using SimApi.Base;
using SimApi.Data.Repository;
using SimApi.Data.Repository.Transaction;

namespace SimApi.Data.Uow;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Category> CategoryRepository { get; }
    IDapperRepository<Account> DapperAccountRepository { get; }
    IDapperRepository<Category> DapperCategoryRepository { get; }

    IDapperTransactionRepository DapperTransactionRepository { get; }
    IEfTransactionRepository EFTransactionRepository { get; }

    IDapperRepository<Entity> DapperRepository<Entity>() where Entity : BaseModel;
    IGenericRepository<Entity> Repository<Entity>() where Entity : BaseModel;

    void Complete();
    void CompleteWithTransaction();
}
