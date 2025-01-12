using AutoMapper;
using E_CommeerceApp.Data.Interfaces;
using E_CommeerceApp.Dtos.Products;
using E_CommeerceApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_CommeerceApp.Controllers
{
    [ApiController]
    [Route($"api/Product")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetProductsList(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? searchTerm = null)
        {
            // Fetch products with pagination and filtering
            var result = await _repository.GetFilteredProducts(pageNumber, pageSize, searchTerm);

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var models = await _repository.GetProductById(id);
            var mappingModel = _mapper.Map<ProductDto>(models);
            if (mappingModel == null)
            {
                return BadRequest(new Response<ProductDto>
                {
                    Status = false,
                    Message = "Entity Not Found",
                    Data = null
                });
            }

            return Ok(new Response<ProductDto>
            {
                Status = true,
                Message = "Data Reterived Successfully",
                Data = mappingModel
            });
        }
        [HttpPost()]
        public async Task<IActionResult> GetProductsList(CreateProductDto createProductDto)
        {
            var mappingModele = _mapper.Map<Products>(createProductDto);
            await _repository.AddAsync(mappingModele, Guid.Empty);
            var products = await _repository.GetProductById(mappingModele.ProductID);
            return Ok(products);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,UpdateProductDto updateProductDto)
        {
            if (id != updateProductDto.ProductID)
            {
                return BadRequest(new Response<object>
                {
                    Status = false,
                    Message = "Invalid Id",
                    Data = null
                });
            }
            var dbModel = await _repository.GetProductById(id);
            if (dbModel == null)
            {
                return BadRequest(new Response<ProductDto>
                {
                    Status = false,
                    Message = "Entity Not Found",
                    Data = null
                });
            }

            var mappingModel = _mapper.Map(updateProductDto,dbModel);

            await _repository.UpdateAsync(mappingModel, Guid.Empty);
            var products = await _repository.GetProductById(mappingModel.ProductID);
            return Ok(new Response<ProductDto>
            {
                Status = true,
                Message = "Data Reterived Successfully",
                Data = _mapper.Map<ProductDto>(products)
            });
        }
        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            var model = await _repository.GetProductById(productId);
            if (model == null)
            {
                return BadRequest(new Response<ProductDto>
                {
                    Status = false,
                    Message = "Entity Not Found",
                    Data = null
                });
            }
            await _repository.DeleteAsync(model);
            return Ok(new Response<ProductDto>
            {
                Status = true,
                Message = "Entity Deleted Successfully",
                Data = null
            });
        }
    }
}
