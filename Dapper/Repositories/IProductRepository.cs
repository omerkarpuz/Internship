using Dapper.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Repositories
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>>GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(int productId);
        Task GetByProductIdAsync(int productId);


    }
}
