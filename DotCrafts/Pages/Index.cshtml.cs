using DotCrafts.Models;
using DotCrafts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotCrafts.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileProductService ProductsService;
        public IEnumerable<Product> Products { get; private set; }

        //Ask a logger by simply listening the arguments.
        //we put the json service in the constructor.
        public IndexModel(ILogger<IndexModel> logger, 
            JsonFileProductService productService)
        {
            _logger = logger;
            ProductsService = productService;
        }

        //A special get. OnGet. Retreive the products.
        public void OnGet()
        {
            Products = ProductsService.GetProducts();
        }
    }
}