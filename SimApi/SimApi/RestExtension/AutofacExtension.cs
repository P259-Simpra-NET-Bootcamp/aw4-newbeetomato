using Autofac;
using Autofac.Extensions.DependencyInjection;
using SimApi.Data;
using SimApi.Data.Context;
using SimApi.Data.Repository;
using SimApi.Data.Repository.Category;
using SimApi.Data.Repository.Transaction;
using SimApi.Data.Uow;
using SimApi.Operation;
using SimApi.Operation.Dapper.Category;
using SimApi.Operation.Transaction;

namespace SimApi.Service.RestExtension;

public  class AutofacExtension:Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

        builder.RegisterType<SimEfDbContext>().AsSelf();

        builder.RegisterType<UserLogService>().As<IUserLogService>();

        builder.RegisterType<TokenService>().As<ITokenService>();

        builder.RegisterType<UserService>().As<IUserService>(); builder.RegisterType<CustomerService>().As<ICustomerService>();

        builder.RegisterType<AccountService>().As<IAccountService>();

        builder.RegisterType<TransactionService>().As<ITransactionService>(); 
        builder.RegisterType<TransactionReportService>().As<ITransactionReportService>();

        builder.RegisterType<DapperAccountService>().As<IDapperAccountService>(); 
        builder.RegisterType<DapperCategoryService>().As<IDapperCategoryService>(); 

        builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();

        builder.RegisterType<ProductRepository>().As<IProductRepository>(); builder.RegisterType<UserRepository>().As<IUserRepository>();

    }
}
