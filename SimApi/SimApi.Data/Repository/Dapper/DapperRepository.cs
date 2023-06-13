using Dapper;
using SimApi.Base;
using SimApi.Data.Context;

namespace SimApi.Data.Repository;

public class DapperRepository<Entity> : IDapperRepository<Entity> where Entity : BaseModel
{
    protected readonly SimDapperDbContext dbContext;
    private bool disposed;

    public DapperRepository(SimDapperDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public void DeleteById(int id)
    {
        var sql = $"DELETE FROM {typeof(Entity).Name} WHERE Id = @Id";
        using (var connection = dbContext.CreateConnection())
        {
            connection.Open();
            connection.Execute(sql, new { Id = id });
            connection.Close();
        }
    }

    public List<Entity> Filter(string sql)
    {
        using (var connection = dbContext.CreateConnection())
        {
            connection.Open();
            var result = connection.Query<Entity>(sql);
            connection.Close();
            return result.ToList();
        }
    }

    public List<Entity> GetAll()
    {
        var sql = $"SELECT * FROM {typeof(Entity).Name}";
        using (var connection = dbContext.CreateConnection())
        {
            connection.Open();
            var result = connection.Query<Entity>(sql);
            connection.Close();
            return result.ToList();
        }
    }

    public Entity GetById(int id)
    {
        var sql = $"SELECT * FROM {typeof(Entity).Name} WHERE Id = @Id";
        using (var connection = dbContext.CreateConnection())
        {
            connection.Open();
            var result = connection.QueryFirstOrDefault<Entity>(sql, new { Id = id });
            connection.Close();
            return result;
        }
    }

    public void Insert(Entity entity)
    {
        var sql = $"INSERT INTO {typeof(Entity).Name} VALUES (@Id, @Name, @Order, @CreatedBy)";
        using (var connection = dbContext.CreateConnection())
        {
            connection.Open();
            connection.Execute(sql, entity);
            connection.Close();
        }
    }

    public void Update(Entity entity)
    {
        var sql = $"UPDATE {typeof(Entity).Name} SET Name = @Name, UpdatedBy = @UpdatedBy WHERE Id = @Id";
        using (var connection = dbContext.CreateConnection())
        {
            connection.Open();
            connection.Execute(sql, entity);
            connection.Close();
        }
    }

   
}

