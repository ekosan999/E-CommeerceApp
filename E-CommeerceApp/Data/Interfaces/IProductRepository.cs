using E_CommeerceApp.Dtos.Products;
using E_CommeerceApp.Models;

namespace E_CommeerceApp.Data.Interfaces
{
    public interface IProductRepository
    {
        Task<Products> GetProductById(int producId);
        Task<PaginatedResult<Products>> GetFilteredProducts(int pageNumber, int pageSize, string? searchTerm);
        Task AddAsync(Products product, Guid userId);
        Task UpdateAsync(Products product, Guid userId);
        Task DeleteAsync(Products product);
        Task SaveChangeAsync();
    } 
}
