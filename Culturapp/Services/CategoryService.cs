using AutoMapper;
using Culturapp.Data;
using Culturapp.Models;
using Culturapp.Models.Requests;
using Culturapp.Models.Responses;
using Microsoft.EntityFrameworkCore;

public class CategoryService
{
  private readonly CulturappDbContext _context;
  private readonly IMapper _mapper;

  public CategoryService(CulturappDbContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public async Task<List<CategoryResponse>> GetAllAsync()
  {
    var category = await _context.Categories.ToListAsync();
    var categoryResponse = _mapper.Map<List<CategoryResponse>>(category);
    return categoryResponse;
  }

  public async Task<CategoryResponse> GetByIdAsync(Guid id)
  {
    var category = await _context.Categories.FindAsync(id);
    var categoryResponse = _mapper.Map<CategoryResponse>(category);
    return categoryResponse;
  }

  public async Task<CategoryResponse> CreateAsync(CategoryRequest categoryRequest)
  {
    var category = _mapper.Map<Category>(categoryRequest);
    _context.Categories.Add(category);
    await _context.SaveChangesAsync();
    var categoryResponse = _mapper.Map<CategoryResponse>(category);
    return categoryResponse;
  }

  public async Task<Category?> UpdateAsync(CategoryRequest categoryRequest)
  {
    if (categoryRequest == null) return null;

    var categoryInDb = await _context.Categories.FindAsync(categoryRequest.Id);
    if (categoryInDb == null)
      return null; 

    _mapper.Map(categoryRequest, categoryInDb);

    await _context.SaveChangesAsync();

    return categoryInDb;
  }


  public async Task<bool> DeleteAsync(Guid id)
  {
    var category = await _context.Categories.FindAsync(id);
    if (category == null)
      return false;

    _context.Categories.Remove(category);
    await _context.SaveChangesAsync();
    return true;
  }

  public async Task<List<EventResponse>?> GetEventsByCategoryIdAsync(Guid categoryId)
  {
    var category = await _context.Categories
                                 .Include(c => c.Events)
                                 .FirstOrDefaultAsync(c => c.Id == categoryId);

    if (category == null || category.Events == null || !category.Events.Any())
    {
      return null;
    }

    var eventsResponse = _mapper.Map<List<EventResponse>>(category.Events);
    return eventsResponse;
  }

}
