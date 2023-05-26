using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiChallange.Context;
using WebApiChallange.Data.Dtos;
using WebApiChallange.Models;
using AutoMapper;
using System.Linq;

namespace WebApiChallange.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VideosController : ControllerBase
	{
		private readonly ApiDbContext _context;
		private readonly IMapper _mapper;

		public VideosController(ApiDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		/// <summary>
		/// Retrieves all videos.
		/// </summary>
		/// <returns>A list of videos.</returns>
		[HttpGet]
		public IEnumerable<ReadVideoDto> GetAllVideos()
		{
			var videos = _context.Videos.ToList();
			return _mapper.Map<List<ReadVideoDto>>(videos);
		}

		/// <summary>
		/// Retrieves a video by its title.
		/// </summary>
		/// <param name="title">The title of the video.</param>
		/// <returns>The video with the specified title.</returns>
		[HttpGet("Title")]
		public IActionResult GetVideoByTitle([FromQuery] string title)
		{
			try
			{
				var video = _context.Videos.FirstOrDefault(v => v.Title == title);
				if (video == null)
					return NotFound($"Video with the title '{title}' not found");

				return Ok(video);
			}
			catch
			{
				return BadRequest("Invalid request");
			}
		}

		/// <summary>
		/// Retrieves a video by its ID.
		/// </summary>
		/// <param name="id">The ID of the video.</param>
		/// <returns>The video with the specified ID.</returns>
		[HttpGet("{id:int}", Name = "GetVideoById")]
		public IActionResult GetVideoById(int id)
		{
			try
			{
				var video = _context.Videos.FirstOrDefault(v => v.Id == id);
				if (video == null)
					return NotFound($"The video with ID {id} could not be found");

				return Ok(video);
			}
			catch
			{
				return BadRequest();
			}
		}

		/// <summary>
		/// Creates a new video.
		/// </summary>
		/// <param name="videoDto">The video data.</param>
		/// <returns>The created video.</returns>
		[HttpPost]
		public IActionResult CreateVideo(CreateVideoDto videoDto)
		{
			try
			{
				var newVideo = _mapper.Map<Video>(videoDto);
				_context.Videos.Add(newVideo);
				_context.SaveChanges();
				return CreatedAtRoute(nameof(GetVideoById), new { id = newVideo.Id }, newVideo);
			}
			catch
			{
				return BadRequest("Invalid request");
			}
		}

		/// <summary>
		/// Edits the information of a video.
		/// </summary>
		/// <param name="id">The ID of the video to edit.</param>
		/// <param name="videoDto">The updated video data.</param>
		/// <returns>No content.</returns>
		[HttpPut("{id:int}")]
		public IActionResult EditVideoInfo(int id, [FromBody] CreateVideoDto videoDto)
		{
			try
			{
				var existingVideo = _context.Videos.FirstOrDefault(v => v.Id == id);
				if (existingVideo != null)
				{
					_mapper.Map(videoDto, existingVideo);
					_context.SaveChanges();
					return NoContent();
				}
				return BadRequest("No video was found");
			}
			catch
			{
				return BadRequest("Invalid request");
			}
		}

		/// <summary>
		/// Deletes a video by its ID.
		/// </summary>
		/// <param name="id">The ID of the video to delete.</param>
		/// <returns>A response indicating the success of the deletion.</returns>
		[HttpDelete("{id}")]
		public IActionResult DeleteVideo(int id)
		{
			try
			{
				var video = _context.Videos.FirstOrDefault(v => v.Id == id);
				if (video == null)
					return NotFound();

				_context.Remove(video);
				_context.SaveChanges();
				return Ok($"Video with ID: {id} was deleted");
			}
			catch
			{
				return NotFound($"The video with ID {id} could not be found. (Delete)");
			}
		}
	}
}
