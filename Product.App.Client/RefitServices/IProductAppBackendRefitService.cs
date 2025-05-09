﻿using Product.App.Client.Models;
using Refit;

namespace Product.App.Client.RefitServices;

public interface IProductAppBackendRefitService
{
    [Get("/api/products")]
    Task<List<ProductDto>> GetAllProductsAsync();

    [Get("/api/products/{productId}")]
    Task<ProductDto> GetProductByIdAsync(int productId);

    [Post("/products")]
    Task<ProductDto> CreateProduct([Body] ProductDto product);

    [Put("/products/{id}")]
    Task UpdateProduct(int id, [Body] ProductDto product);
}
