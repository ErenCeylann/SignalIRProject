using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.Dtos.ProductDto
{
    public class CreateProductDto
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ImageUrl { get; set; }
        public bool ProductStatus { get; set; }
        public int CategoryId { get; set; }
    }
}
