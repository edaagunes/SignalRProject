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
			var value=_mapper.Map<Product>(createProductDto);
			_productService.TAdd(value);
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
			var value = _mapper.Map<Product>(updateProductDto);
			_productService.TUpdate(value);
			return Ok("Güncelleme Başarılı");
		}

		[HttpGet("{id}")]
		public IActionResult GetProduct(int id)
		{
			var value= _productService.TGetById(id);
			return Ok(_mapper.Map<GetProductDto>(value));
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
		[HttpGet("ProductPriceBySteakBurger")]
		public IActionResult ProductPriceBySteakBurger()
		{
			return Ok(_productService.TProductPriceBySteakBurger());
		}
		[HttpGet("TotalPriceByDrinkCategory")]
		public IActionResult TotalPriceByDrinkCategory()
		{
			return Ok(_productService.TTotalPriceByDrinkCategory());
		}

		[HttpGet("TotalPriceBySaladCategory")]
		public IActionResult TotalPriceBySaladCategory()
		{
			return Ok(_productService.TTotalPriceBySaladCategory());
		}
		[HttpGet("GetTake9Products")]
		public IActionResult GetTake9Products()
		{
			var values=_productService.TGetLast9Products();
			return Ok(values);
		}
	}
}
