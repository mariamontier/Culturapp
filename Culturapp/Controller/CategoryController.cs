using Culturapp.Models.Requests;
using Culturapp.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Culturapp.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CategoryController : ControllerBase
  {
    private readonly CategoryService _categoryService;

    public CategoryController(CategoryService categoryService)
    {
      _categoryService = categoryService;
    }

    [HttpGet("GetCategories")]
    public async Task<ActionResult<IEnumerable<CategoryResponse>>> GetCategories()
    {
      var categories = await _categoryService.GetAllAsync();
      return Ok(categories);
    }

    [HttpGet("GetCategory/{id}")]
    public async Task<ActionResult<CategoryResponse>> GetCategory(int id)
    {
      var category = await _categoryService.GetByIdAsync(id);
      if (category == null)
      {
        return NotFound();
      }
      return Ok(category);
    }

    [Authorize]
    [HttpPost("PostCategory")]
    public async Task<ActionResult<CategoryResponse>> PostCategory([FromBody] CategoryRequest categoryRequest)
    {
      if (categoryRequest == null)
      {
        return BadRequest();
      }

      var createdCategory = await _categoryService.CreateAsync(categoryRequest);

      return Created();
    }


    [Authorize]
    [HttpPut("PutCategory/{id}")]
    public async Task<IActionResult> PutCategory(int? id, [FromBody] CategoryRequest model)
    {
      if (id == null)
        return BadRequest();

      var updatedCategory = await _categoryService.UpdateAsync(id, model);
      if (updatedCategory == null)
        return NotFound();

      return NoContent();
    }

    [Authorize]
    [HttpDelete("DeleteCategory/{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
      var deleted = await _categoryService.DeleteAsync(id);
      if (!deleted)
      {
        return NotFound();
      }
      return NoContent();
    }

    [HttpGet("GetEventsByCategory/{categoryId}")]
    public async Task<ActionResult<List<EventResponse>>> GetEventsByCategory(int? categoryId)
    {
      var events = await _categoryService.GetEventsByCategoryIdAsync(categoryId);
      if (events == null)
      {
        return NotFound();
      }
      return Ok(events);
    }

  }
}
