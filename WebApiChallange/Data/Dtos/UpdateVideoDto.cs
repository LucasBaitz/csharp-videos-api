using System.ComponentModel.DataAnnotations;

namespace WebApiChallange.Data.Dtos
{
	public class UpdateVideoDto
	{
		[Required]
		public string Title { get; set; }

		[Required]
		public string Url { get; set; }
		public string Description { get; set; }

		public int? CategoryId { get; set; }
	}
}
