using CommunityToolkit.Mvvm.ComponentModel;
using DemoEcommerce.Client.Models;
using DemoEcommerce.Client.Services;
using DemoEcommerce.Library.ClientModels;
using MvvmHelpers;

namespace DemoEcommerce.Client.ViewModels;

public partial class DesktopHomePageViewModel : BaseViewModel
{
    private readonly IProductService productService;

    public ObservableRangeCollection<ProductModel> Products { get; set; } = new();
    public DesktopHomePageViewModel(IProductService productService)
    {
        this.productService = productService;
        Title = "Available Products";
        GetProducts();
    }

    private async void GetProducts()
    {
        try
        {
            var products = await productService.GetProductsAsync();
            if (products is null)
                return;

            if (Products.Count > 0)
                Products.Clear();

            foreach (var product in products)
            {
                string ProductDescription = product.Description.Count() > 40 ? product.Description.Substring(0, 40) + "..." : product.Description;
                Products.Add(new ProductModel()
                {
                    Id = product.Id,
                    CategoryId = product.CategoryId,
                    Image = product.Image,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    Description = ProductDescription
                });
            }


        }
        catch (Exception) { }
    }
}
