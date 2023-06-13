using SimApi.Base;
using SimApi.Data.Repository;
using SimApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimApi.Data.Uow;
using AutoMapper;
using SimApi.Schema;
using Serilog;
using SimApi.Data.Migrations;

namespace SimApi.Operation.Dapper.Category
{
    public class DapperCategoryService : BaseService<Data.Category, CategoryRequest, CategoryResponse>, IDapperCategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DapperCategoryService(IMapper mapper, IUnitOfWork unitOfWork) : base(unitOfWork, mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public override ApiResponse<List<CategoryResponse>> GetAll()
        {
            try
            {
                var categories = unitOfWork.DapperCategoryRepository.GetAll();
            var mapped = mapper.Map<List<CategoryResponse>>(categories);
            return new ApiResponse<List<CategoryResponse>>(mapped);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "GetAll Exception");
            return new ApiResponse<List<CategoryResponse>>(ex.Message);
        }
}

        public ApiResponse<CategoryResponse> GetById(int id)
        {
            try
            {
                var entity = unitOfWork.DapperCategoryRepository.GetById(id);
                if (entity is null)
                {
                    Log.Warning("Record not found for Id " + id);
                    return new ApiResponse<CategoryResponse>("Record not found");
                }

                var mapped = mapper.Map<Data.Category, CategoryResponse>(entity);
                return new ApiResponse<CategoryResponse>(mapped);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetById Exception");
                return new ApiResponse<CategoryResponse>(ex.Message);
            }

        }

        public ApiResponse Insert(CategoryRequest category)
        {
            try
            {
                var entity = mapper.Map<CategoryRequest, Data.Category>(category);
                unitOfWork.DapperCategoryRepository.Insert(entity);
                return new ApiResponse();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Insert Exception");
                return new ApiResponse(ex.Message);
            }
            

        }

        public ApiResponse Update(int id, CategoryRequest category)
        {
            try
            {
                var entity = mapper.Map<CategoryRequest, Data.Category>(category);
                var exist = unitOfWork.DapperCategoryRepository.GetById(id);
                if (exist is null)
                {
                    Log.Warning("Record not found for Id " + id);
                    return new ApiResponse("Record not found");
                }

                entity.Id = id;
                entity.UpdatedAt = DateTime.UtcNow;

                unitOfWork.DapperCategoryRepository.Update(entity);
                return new ApiResponse();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Update Exception");
                return new ApiResponse(ex.Message);
            }

        }

        public ApiResponse DeleteById(int id)
        {
            try
            {
                unitOfWork.DapperCategoryRepository.DeleteById(id);
                return new ApiResponse();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Delete Exception");
                return new ApiResponse(ex.Message);
            }

        }
    }
}