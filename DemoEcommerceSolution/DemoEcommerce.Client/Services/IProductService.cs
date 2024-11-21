using DemoEcommerce.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEcommerce.Client.Services
{
    public interface IProductService
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<ServiceResponse> AddProductAsync(Product product);
        Task<List<Product>> GetProductsAsync();
    }
}
