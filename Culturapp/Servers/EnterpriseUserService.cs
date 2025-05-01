
using AutoMapper;
using Culturapp.Data;
using Culturapp.Models;
using Culturapp.Models.Requests;
using Culturapp.Models.Responses;
using Microsoft.EntityFrameworkCore;

namespace Culturapp.Servers
{
  public class EnterpriseUserService
  {

    private readonly CulturappDbContext _context;
    private readonly IMapper _mapper;

    public EnterpriseUserService(CulturappDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<List<EnterpriseUserResponse>> GetEnterpriseUsersAsync()
    {
      var enterpriseList = await _context.EnterpriseUsers.ToListAsync();
      var enterpriseUserResponseList = _mapper.Map<List<EnterpriseUserResponse>>(enterpriseList);
      return enterpriseUserResponseList;
    }

    public async Task<EnterpriseUserResponse?> GetEnterpriseUserByIdAsync(int id)
    {
      var enterpriseUser = await _context.EnterpriseUsers.FindAsync(id);
      var enterpriseUserResponse = _mapper.Map<EnterpriseUserResponse>(enterpriseUser);
      return enterpriseUserResponse;
    }

    public async Task<EnterpriseUserResponse?> AddEnterpriseUserAsync(EnterpriseUserRequest enterpriseUserRequest)
    {
      var userEnterprise = _mapper.Map<EnterpriseUser>(enterpriseUserRequest);
      var existingUser = await _context.EnterpriseUsers.FirstOrDefaultAsync(u => u.CNPJ == userEnterprise.CNPJ || u.Email == userEnterprise.Email);
      if (existingUser != null)
      {
        return null;
      }
      else
      {
        _context.EnterpriseUsers.Add(existingUser);
        await _context.SaveChangesAsync();
        var userEnterpriseResponse = _mapper.Map<EnterpriseUserResponse>(existingUser);
        return userEnterpriseResponse;
      }
    }

    public async Task UpdateEnterpriseUserAsync(EnterpriseUserRequest enterpriseUserRequest)
    {
      var enterpriseUser = _mapper.Map<EnterpriseUser>(enterpriseUserRequest);
      _context.EnterpriseUsers.Update(enterpriseUser);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteEnterpriseUserAsync(int id)
    {
      var userEnterprise = await _context.EnterpriseUsers.FindAsync(id);
      if (userEnterprise != null)
      {
        _context.EnterpriseUsers.Remove(userEnterprise);
        await _context.SaveChangesAsync();
      }
    }

  }
}