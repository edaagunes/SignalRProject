using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly IMapper _mapper;

		public ProductController(IProductService productService, IMapper mapper)
		{
			_productService = productService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult ProductList()
		{
			return Ok(_productService.TGetAll());
		}
		[HttpGet("ProductListWithCategory")]
		public IActionResult ProductListWithCategory()
		{
			var context = new SignalRContext();
			var values = context.Products.Include(x => x.Category);
			var items = _mapper.Map<List<ResultProductWithCategory>>(values);
			return Ok(items.ToList());
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
				CategoryId = createProductDto.CategoryId
			};
			_productService.TAdd(product);
			return Ok("Ekleme Başarılı");
		}
		[HttpDelete("{id}")]
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
				CategoryId = updateProductDto.CategoryId
			};
			_productService.TUpdate(product);
			return Ok("Güncelleme Başarılı");
		}
		[HttpGet("{id}")]
		public IActionResult GetProduct(int id)
		{
			return Ok(_productService.TGetById(id));
		}
		[HttpGet("ProductCount")]
		public IActionResult ProductCount()
		{
			return Ok(_productService.TProductCount());
		}
		[HttpGet("ProductCountByCategoryNameDrink")]
		public IActionResult ProductCountByCategoryNameDrink()
		{
			return Ok(_productService.TProductCountByCategoryNameDrink());
		}
		[HttpGet("ProductCountByCategoryNameHamburger")]
		public IActionResult ProductCountByCategoryNameHamburger()
		{
			return Ok(_productService.TProductCountByCategoryNameHamburger());
		}
		[HttpGet("ProductPriceAvg")]
		public IActionResult ProductPriceAvg()
		{
			return Ok(_productService.TProductPriceAvg());
		}
		[HttpGet("ProductNameByMaxPrice")]
		public IActionResult ProductNameByMaxPrice()
		{
			return Ok(_productService.TProductNameByMaxPrice());
		}
		[HttpGet("ProductNameByMinPrice")]
		public IActionResult ProductNameByMinPrice()
		{
			return Ok(_productService.TProductNameByMinPrice());
		}
		[HttpGet("ProductAvgByHamburger")]
		public IActionResult ProductAvgByHamburger()
		{
			return Ok(_productService.TProductAvgByHamburger());
		}
	}
}
