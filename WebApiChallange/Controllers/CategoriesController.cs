using Microsoft.AspNetCore.Mvc;
using WebApiChallange.Context;
using WebApiChallange.Data.Dtos;
using WebApiChallange.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace WebApiChallange.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ApiDbContext _context;
		private readonly IMapper _mapper;

		public CategoriesController(ApiDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		/// <summary>
		/// Retrieves all categories.
		/// </summary>
		/// <returns>A list of categories.</returns>
		[HttpGet]
		public IEnumerable<ReadCategoryDto> GetAllCategories()
		{
			var categories = _context.Categories.ToList();
			return _mapper.Map<List<ReadCategoryDto>>(categories);
		}

		/// <summary>
		/// Retrieves a category by its name.
		/// </summary>
		/// <param name="name">The name of the category.</param>
		/// <returns>The category with the specified name.</returns>
		[HttpGet("Name")]
		public IActionResult GetCategoryByName([FromQuery] string name)
		{
			try
			{
				var category = _context.Categories.FirstOrDefault(c => c.Name == name);
				if (category == null)
					return NotFound($"Category with the name '{name}' not found");

				return Ok(category);
			}
			catch
			{
				return BadRequest("Invalid request");
			}
		}

		/// <summary>
		/// Creates a new category.
		/// </summary>
		/// <param name="categoryDto">The category data.</param>
		/// <returns>Ok if the category was created successfully.</returns>
		[HttpPost]
		public IActionResult CreateCategory(CreateCategoryDto categoryDto)
		{
			try
			{
				var newCategory = _mapper.Map<Category>(categoryDto);
				_context.Categories.Add(newCategory);
				_context.SaveChanges();
				return Ok();
			}
			catch
			{
				return BadRequest("Invalid request");
			}
		}

		/// <summary>
		/// Deletes a category by its ID.
		/// </summary>
		/// <param name="id">The ID of the category to delete.</param>
		/// <returns>A response indicating the success of the deletion.</returns>
		[HttpDelete("{id}")]
		public IActionResult DeleteCategory(int id)
		{
			try
			{
				var category = _context.Categories.FirstOrDefault(c => c.Id == id);
				if (category == null)
					return NotFound();

				_context.Remove(category);
				_context.SaveChanges();
				return Ok($"Category with ID: {id} was deleted");
			}
			catch
			{
				return NotFound($"The category with ID {id} could not be found. (Delete)");
			}
		}
	}
}
