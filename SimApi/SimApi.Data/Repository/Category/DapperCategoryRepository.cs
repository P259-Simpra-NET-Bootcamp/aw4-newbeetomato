using Dapper;
using SimApi.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace SimApi.Data.Repository.Category
{
    public class DapperCategoryRepository : IDapperRepository<Data.Category>
    {
        private readonly SimDapperDbContext context;

        public DapperCategoryRepository(SimDapperDbContext context)
        {
            this.context = context;
        }

        public void DeleteById(int id)
        {
            var sql = "DELETE FROM dbo.\"Category\" WHERE \"Id\" = @Id";
            using (var connection = context.CreateConnection())
            {
                connection.Open();
                connection.Execute(sql, new { Id = id });
                connection.Close();
            }
        }

        public List<Data.Category> Filter(string sql)
        {
            using (var connection = context.CreateConnection())
            {
                connection.Open();
                var result = connection.Query<Data.Category>(sql);
                connection.Close();
                return result.ToList();
            }
        }

        public List<Data.Category> GetAll()
        {
            var sql = "SELECT * FROM dbo.\"Category\"";
            using (var connection = context.CreateConnection())
            {
                connection.Open();
                var result = connection.Query<Data.Category>(sql);
                connection.Close();
                return result.ToList();
            }
        }

        public Data.Category GetById(int id)
        {
            var sql = "SELECT * FROM dbo.\"Category\" WHERE \"Id\" = @Id";
            using (var connection = context.CreateConnection())
            {
                connection.Open();
                var result = connection.QueryFirstOrDefault<Data.Category>(sql, new { Id = id });
                connection.Close();
                return result;
            }
        }

        public void Insert(Data.Category entity)
        {
            var sql = "INSERT INTO dbo.\"Category\" (\"Name\", \"Order\") VALUES (@Name, @Order)";

            using (var connection = context.CreateConnection())
            {
                connection.Open();
                connection.Execute(sql, entity);
                connection.Close();
            }
        }

        public void Update(Data.Category entity)
        {
            var sql = "UPDATE dbo.\"Category\" SET \"Name\" = @Name, \"Order\" = @Order WHERE \"Id\" = @Id";

            using (var connection = context.CreateConnection())
            {
                connection.Open();
                connection.Execute(sql, entity);
                connection.Close();
            }
        }
    }
}
