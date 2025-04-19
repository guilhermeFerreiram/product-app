using Product.App.Client.Models;
using Product.App.Client.RefitServices;
using Product.App.Client.Services.Interfaces;

namespace Product.App.Client.Services;

public class ProductService(
    IProductAppBackendRefitService productAppBackendRefitService
) : IProductService
{
    public async Task<List<ProductDto>> GetAllProductsAsync()
    {
        var products = new List<ProductDto>()
        {
            new ProductDto { Id = 1, Name = "Product 1", Price = 10 },
            new ProductDto { Id = 2, Name = "Product 2", Price = 20 },
        };
         
        return await Task.FromResult(products);

        //usar refit
    }
    public async Task<ProductDto> GetProductByIdAsync(int productId)
    {
        var product = new ProductDto { Id = productId, Name = $"Product {productId}", Price = productId * 10 };

        return await Task.FromResult(product);

        //usar refit
    }

    public async Task<ProductDto> CreateProductAsync(ProductDto product)
    {
        return await Task.FromResult(product);

        //usar refit
    }

    public async Task<ProductDto> UpdateProductAsync(ProductDto product)
    {
        return await Task.FromResult(product);

        //usar refit
    }
}
