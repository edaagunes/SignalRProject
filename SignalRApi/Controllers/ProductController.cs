using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}
		[HttpGet]
		public IActionResult ProductList()
		{
			return Ok(_productService.TGetAll());
		}

		[HttpPost]
		public IActionResult CreateProduct(CreateProductDto createProductDto)
		{
			Product product = new Product()
			{
				ImageUrl = createProductDto.ImageUrl,
				Price = createProductDto.Price,
				ProductName = createProductDto.ProductName,
				ProductStatus = createProductDto.ProductStatus,
				Description = createProductDto.Description,
			};
			_productService.TAdd(product);
			return Ok("Ekleme Başarılı");
		}
		[HttpDelete]
		public IActionResult DeleteProduct(int id)
		{
			var value = _productService.TGetById(id);
			_productService.TDelete(value);
			return Ok("Silme Başarılı");
		}
		[HttpPut]
		public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
		{
			Product product = new Product()
			{
				ProductId = updateProductDto.ProductId,
				ImageUrl = updateProductDto.ImageUrl,
				Price = updateProductDto.Price,
				ProductName = updateProductDto.ProductName,
				ProductStatus = updateProductDto.ProductStatus,
				Description = updateProductDto.Description,
			};
			_productService.TUpdate(product);
			return Ok("Güncelleme Başarılı");
		}
		[HttpGet("GetProduct")]
		public IActionResult GetProduct(int id)
		{
			return Ok(_productService.TGetById(id));
		}
	}
}
