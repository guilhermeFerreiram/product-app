using Microsoft.AspNetCore.Components;

namespace Product.App.Client.Pages.Products;

public class EditProductBase : ComponentBase
{
    [Parameter] public int? Id { get; set; }
}
