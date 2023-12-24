using System.ComponentModel.DataAnnotations;

namespace WebApiChallange.Data.Dtos
{
	public class CreateVideoDto
	{
		[Required(ErrorMessage = "Please provide a title for the video.")]
		public string Title { get; set; }

		[Required(ErrorMessage = "The video must have a URL.")]
		public string Url { get; set; }
		public string Description { get; set; }
		public int? CategoryId { get; set; }
	}
}
