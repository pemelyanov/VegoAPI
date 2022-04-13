﻿using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VegoAPI.Models.RequestModels;
using VegoAPI.Models.ResponseModels;
using VegoAPI.Utils;
using VegoAPI.VegoAPI.Models.DBEntities;
using VegoAPI.VegoAPI.Services.DBContext;

namespace VegoAPI.Services.ProductTypesRepository
{
    public class ProductTypesRealRepository : IProductTypesRepository
    {
        private readonly VegoCityServerDBContext _dao;

        public ProductTypesRealRepository(VegoCityServerDBContext dao)
        {
            _dao = dao;
        }

        public async Task AddProductTypeAsync(AddProductTypeRequest addProductRequest)
        {
            var productType = new Category
            {
                Name = addProductRequest.Name
            };

            await _dao.Categories.AddAsync(productType);
            await _dao.SaveChangesAsync();
        }

        public async Task DeleteProductTypeAsync(int productTypeId)
        {
            var productType = await _dao.Categories.FindAsync(productTypeId);

            if(productType is null)
                return;

            _dao.Categories.Remove(productType);
            await _dao.SaveChangesAsync();
        }

        public async Task EditProductTypeAsync(EditEntityWithIntIdRequest editProductTypeRequest)
        {
            var productType = await _dao.Categories.FindAsync(editProductTypeRequest.EntityId);

            if (productType is null)
                return;

            editProductTypeRequest.ChangedFields["Name"]
            ?.Let(name => productType.Name = name);

            await _dao.SaveChangesAsync();
        }

        public async Task<ProductTypeResponse[]> GetAllProductTypesAsync()
            => await _dao.Categories
            .Select(pt =>
            new ProductTypeResponse
            {
                Id = pt.Id,
                Name = pt.Name
            })
            .ToArrayAsync();

        public async Task<ProductTypeResponse> GetProductTypeByIdAsync(int id)
        {
            var productType = await _dao.Categories.FindAsync(id);

            return new ProductTypeResponse 
            { 
                Id = productType.Id,
                Name = productType.Name 
            };
        }
    }
}
