using E_CommeerceApp.Data.Interfaces;
using E_CommeerceApp.Dtos.Products;
using E_CommeerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace E_CommeerceApp.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Products product, Guid userId)
        {
            try
            {
                product.CreatedBy = userId;
                product.CreatedOn = DateTimeOffset.Now;
                await _context.Products.AddAsync(product);
                await SaveChangeAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task DeleteAsync(Products product)
        {
            _context.Products.Remove(product);
            await SaveChangeAsync();
        }

      

        public async Task<Products> GetProductById(int producId)
        {
            var model = await  _context.Products.FirstOrDefaultAsync(x => x.ProductID == producId);
            return model;
        }


        public async Task UpdateAsync(Products product, Guid userId)
        {
            product.UpdatedBy = userId;
            product.UpdatedOn = DateTimeOffset.Now;
            _context.Products.Update(product);
            await SaveChangeAsync();
        }
        public async Task SaveChangeAsync()
        {
           await _context.SaveChangesAsync();
        }

        public async Task<PaginatedResult<Products>> GetFilteredProducts(int pageNumber, int pageSize, string searchTerm)
        {
            var query = _context.Products.AsQueryable();

            // Apply filtering
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm));
            }

            // Get total count for pagination metadata
            var totalRecords = await query.CountAsync();

            // Apply pagination
            var products = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Return paginated result
            return new PaginatedResult<Products>
            {
                Data = products,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}
