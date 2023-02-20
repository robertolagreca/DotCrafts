using DotCrafts.Models;
using DotCrafts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotCrafts.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		//It's like the API written in program.
		public ProductsController(JsonFileProductService productService) 
		{ 
			this.ProductService= productService;
		}

		public JsonFileProductService ProductService { get; }

		[HttpGet]
		public IEnumerable<Product> Get()
	    {
			return ProductService.GetProducts();
		}

		//[HttpPatch] "[FromBody]"
		[Route("Rate")]
		[HttpGet]
		public ActionResult Get(
			[FromQuery]string ProductId, 
			[FromQuery] int Rating)
		{
			ProductService.AddRating(ProductId, Rating);
			return Ok();
		}
	}
}
