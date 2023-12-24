using System.ComponentModel.DataAnnotations;

namespace WebApiChallange.Data.Dtos
{
	public class UpdateCategoryDto
	{
		[Required(ErrorMessage = "A company name must be provided.")]
		public string Name { get; set; }
	}
}
