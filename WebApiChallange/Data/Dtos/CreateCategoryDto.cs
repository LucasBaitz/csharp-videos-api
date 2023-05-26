using System.ComponentModel.DataAnnotations;

namespace WebApiChallange.Data.Dtos
{
	public class CreateCategoryDto
	{
		[Required(ErrorMessage = "A category name must be provided.")]
		public string Name { get; set; }
	}
}
