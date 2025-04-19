using Microsoft.AspNetCore.Components;
using Product.App.Client.Models;
using Product.App.Client.Services.Interfaces;

namespace Product.App.Client.Pages.Products;

public class ListProductsBase : ComponentBase
{
    #region services
    [Inject]
    protected IProductService ProductService { get; set; }

    [Inject]
    protected NavigationManager NavigationManager { get; set; }
    #endregion

    #region services
    protected List<ProductDto> Products { get; set; } = new();
    protected bool IsLoading { get; set; } = true;
    #endregion

    protected override async Task OnInitializedAsync()
    {
        await LoadProducts();
        await base.OnInitializedAsync();
    }

    protected async Task LoadProducts()
    {
        try
        {
            IsLoading = true;
            Products = await ProductService.GetAllProductsAsync();
        }
        finally
        {
            IsLoading = false;
            StateHasChanged();
        }
    }

    protected void NavigateToEdit(int productId)
    {
        NavigationManager.NavigateTo($"/products/edit/{productId}");
    }
}
