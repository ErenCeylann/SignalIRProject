using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.Dtos.CategoryDto
{
	public class CreateCategoryDto
	{

		[Key]
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public bool CategoryStatus { get; set; }
	}
}
