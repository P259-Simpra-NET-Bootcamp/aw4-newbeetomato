
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimApi.Base;
using SimApi.Data;
using SimApi.Operation.Dapper.Category;
using SimApi.Schema;

namespace SimApi.Service.DapperCategoryContoller;
[EnableMiddlewareLogger]
[ResponseGuid]
[ApiController]
[Route("simapi/v2/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IDapperCategoryService _categoryService;
    private IMapper mapper;


    public CategoryController(IDapperCategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService;
        this.mapper = mapper;
    }

    [HttpGet]
    public ApiResponse<List<CategoryResponse>> GetAll()
    {

        var categories = _categoryService.GetAll();
        return categories;
    }

    [HttpGet("{id}")]
    public ApiResponse<CategoryResponse> GetById(int id)
    {
        var category = _categoryService.GetById(id);

        return category;
    }

    [HttpPost]
    public ApiResponse Insert(CategoryRequest category)
    {
        var response = _categoryService.Insert(category);
        return response;
    }

    [HttpPut("{id}")]
    public ApiResponse Update(int id, CategoryRequest category)
    {
        var response = _categoryService.Update(id, category);
        return response;

    }

    [HttpDelete("{id}")]
    public ApiResponse DeleteById(int id)
    {
        var response = _categoryService.DeleteById(id);
        return response;
    }
}

