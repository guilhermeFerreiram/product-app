using Microsoft.AspNetCore.Components;
using MudBlazor;
using Product.App.Client.Models;
using Product.App.Client.Services.Interfaces;

namespace Product.App.Client.Pages.Products;

public class EditProductBase : ComponentBase
{
    #region services
    [Inject] private IProductService ProductService { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }
    #endregion

    #region parameters
    [Parameter] public int Id { get; set; }
    #endregion

    #region variables
    protected ProductDto Product { get; set; } = new();
    protected bool IsEditMode => Id > 0;
    protected bool IsProcessing { get; set; }
    protected string Title => IsEditMode ? "Editar Produto" : "Novo Produto";
    protected string SubmitButtonText => IsEditMode ? "Salvar Alterações" : "Criar Produto";
    #endregion

    protected override async Task OnParametersSetAsync()
    {
        if (IsEditMode)
        {
            await LoadProduct();
        }
    }

    protected async Task LoadProduct()
    {
        try
        {
            IsProcessing = true;
            Product = await ProductService.GetProductByIdAsync(Id);
        }
        finally
        {
            IsProcessing = false;
        }
    }

    protected async Task HandleValidSubmit()
    {
        try
        {
            IsProcessing = true;

            if (IsEditMode)
            {
                await ProductService.UpdateProductAsync(Product);
            }
            else
            {
                await ProductService.CreateProductAsync(Product);
            }

            NavigationManager.NavigateTo("/products");
        }
        finally
        {
            IsProcessing = false;
        }
    }
}
