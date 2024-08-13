using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyWebApp.Pages;

public class Product : PageModel
{
    private readonly ProductRepository _productRepository;
    public ProductModel ProductModel { get; set; }

    public Product(ProductRepository productRepository)
    {
        _productRepository = productRepository;
        ProductModel = new ProductModel();
    }
    public void OnGet()
    {
        ProductModel =_productRepository.GetById(0);
    }

    public void OnPost()
    {
        
        string name = Request.Form["name"];
        string price = Request.Form["price"];

        ProductModel.Name = name;
        ProductModel.Price = price;
    }
}