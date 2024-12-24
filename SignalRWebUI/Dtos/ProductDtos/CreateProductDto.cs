namespace SignalRWebUI.Dtos.ProductDtos
{
	public class CreateProductDto
	{
		public string ProductName { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string ImageUrl { get; set; }
		public bool ProductStatus { get; set; }
		public string CategoryName { get; set; }
		public int CategoryId { get; set; }
	}
}
