using SimApi.Base;
using SimApi.Data;
using SimApi.Schema;



namespace SimApi.Operation.Dapper.Category
{
    public interface IDapperCategoryService
    {

        ApiResponse<List<CategoryResponse>> GetAll();
        ApiResponse<CategoryResponse> GetById(int id);
        ApiResponse Insert(CategoryRequest category);
        ApiResponse Update(int id, CategoryRequest category);
        ApiResponse DeleteById(int id);

    }
}
