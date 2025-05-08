
using AutoMapper;
using Culturapp.Data;
using Culturapp.Models;
using Culturapp.Models.Requests;
using Culturapp.Models.Responses;
using Microsoft.EntityFrameworkCore;

namespace Culturapp.Services
{
  public class EnterpriseUserService
  {

    private readonly CulturappDbContext _context;
    private readonly IMapper _mapper;
    private readonly AuthService _authService;

    public EnterpriseUserService(CulturappDbContext context, IMapper mapper, AuthService authService)
    {
      _context = context;
      _mapper = mapper;
      _authService = authService;
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

    public async Task<EnterpriseUserResponse?> CreateEnterpriseUserAsync(EnterpriseUserRequest enterpriseUserRequest)
    {

      var user = await _authService.FindUser(enterpriseUserRequest.Email!);

      var userEnterprise = _mapper.Map<EnterpriseUser>(enterpriseUserRequest);

      userEnterprise.CNPJ = user!.CNPJ;
      userEnterprise.UserName = user.UserName;
      userEnterprise.FullName = user.FullName;

      var existingUser = await _context.EnterpriseUsers.FirstOrDefaultAsync(u => u.CNPJ == userEnterprise.CNPJ || u.Email == userEnterprise.Email);

      if (existingUser != null)
      {
        return null;
      }
      else
      {
        _context.EnterpriseUsers.Add(userEnterprise);
        await _context.SaveChangesAsync();
        var userEnterpriseResponse = _mapper.Map<EnterpriseUserResponse>(userEnterprise);
        return userEnterpriseResponse;
      }
    }

    public async Task<EnterpriseUser?> UpdateEnterpriseUserAsync(EnterpriseUserRequest enterpriseUserRequest)
    {
      var enterpriseUser = _mapper.Map<EnterpriseUser>(enterpriseUserRequest);
      _context.EnterpriseUsers.Update(enterpriseUser);
      await _context.SaveChangesAsync();
      return enterpriseUser;
    }

    public async Task<EnterpriseUser?> DeleteEnterpriseUserAsync(int id)
    {
      var userEnterprise = await _context.EnterpriseUsers.FindAsync(id);
      if (userEnterprise != null)
      {
        _context.EnterpriseUsers.Remove(userEnterprise);
        await _context.SaveChangesAsync();
      }
      return userEnterprise;
    }

  }
}