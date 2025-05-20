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

  public async Task<CategoryResponse> GetByIdAsync(int id)
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

    var category = _mapper.Map<Category>(categoryRequest);
    var categoryUpdate = await _context.Categories.FindAsync(category.Id);
    _context.Categories.Update(categoryUpdate!);
    await _context.SaveChangesAsync();
    return category;
  }

  public async Task<bool> DeleteAsync(int id)
  {
    var category = await _context.Categories.FindAsync(id);
    if (category == null)
      return false;

    _context.Categories.Remove(category);
    await _context.SaveChangesAsync();
    return true;
  }
}
