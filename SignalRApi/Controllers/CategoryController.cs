using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet]
		public IActionResult CategoryList()
		{
			return Ok(_categoryService.TGetAll());
		}

		[HttpPost]
		public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
		{
			Category category = new Category()
			{
				CategoryName = createCategoryDto.CategoryName,
				CategoryStatus = createCategoryDto.CategoryStatus
			};
			_categoryService.TAdd(category);
			return Ok("Ekleme Başarılı");
		}
		[HttpDelete]
		public IActionResult DeleteCategory(int id)
		{
			var value = _categoryService.TGetById(id);
			_categoryService.TDelete(value);
			return Ok("Silme Başarılı");
		}
		[HttpPut]
		public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
		{
			Category category = new Category()
			{
				CategoryId = updateCategoryDto.CategoryId,
				CategoryName = updateCategoryDto.CategoryName,
				CategoryStatus = updateCategoryDto.CategoryStatus
			};
			_categoryService.TUpdate(category);
			return Ok("Güncelleme Başarılı");
		}
		[HttpGet("GetCategory")]
		public IActionResult GetCategory(int id)
		{
			return Ok(_categoryService.TGetById(id));
		}
	}
}
