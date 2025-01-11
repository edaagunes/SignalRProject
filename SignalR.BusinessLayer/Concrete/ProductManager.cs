using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
	public class ProductManager : IProductService
	{
		private readonly IProductDal _productDal;

		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;
		}

		public void TAdd(Product entity)
		{
			_productDal.Add(entity);
		}

		public void TDelete(Product entity)
		{
			_productDal.Delete(entity);
		}

		public List<Product> TGetAll()
		{
			return _productDal.GetAll();
		}

		public Product TGetById(int id)
		{
			return _productDal.GetById(id);
		}

		public List<Product> TGetProductsWithCategories()
		{
			return _productDal.GetProductsWithCategories();
		}

		public int TProductCount()
		{
			return _productDal.ProductCount();
		}

		public int TProductCountByCategoryNameDrink()
		{
			return _productDal.ProductCountByCategoryNameDrink();
		}

		public int TProductCountByCategoryNameHamburger()
		{
			return _productDal.ProductCountByCategoryNameHamburger();
		}

		public string TProductNameByMaxPrice()
		{
			return _productDal.ProductNameByMaxPrice();
		}

		public string TProductNameByMinPrice()
		{
			return _productDal.ProductNameByMinPrice();
		}

		public decimal TProductPriceAvg()
		{
			return _productDal.ProductPriceAvg();
		}

		public decimal TProductAvgByHamburger()
		{
			return _productDal.ProductAvgByHamburger();
		}

		public void TUpdate(Product entity)
		{
			_productDal.Update(entity);
		}

		public decimal TProductPriceBySteakBurger()
		{
			return _productDal.ProductPriceBySteakBurger();
		}

		public decimal TTotalPriceByDrinkCategory()
		{
			return _productDal.TotalPriceByDrinkCategory();
		}

		public decimal TTotalPriceBySaladCategory()
		{
			return _productDal.TotalPriceBySaladCategory();
		}

		public List<Product> TGetLast9Products()
		{
			return _productDal.GetLast9Products();
		}
	}
}
