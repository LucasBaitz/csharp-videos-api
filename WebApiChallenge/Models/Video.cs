using System.ComponentModel.DataAnnotations;

namespace WebApiChallange.Models
{
	
	public class Video
	{
		[Key]
        public int Id { get; set; }
		
		[Required]
		[StringLength(50, ErrorMessage = "Please provide a title for the video.")]
		public string Title { get; set; }
		
		[Required]
		[StringLength(75, ErrorMessage = "The video must have a URL.")]
		public string Url { get; set; }
		public string Description { get; set; }

		public int? CategoryId { get; set; }
	}
}
