using AutoMapper;
using Culturapp.Data;
using Culturapp.Models;
using Culturapp.Models.Requests;
using Microsoft.EntityFrameworkCore;

namespace Culturapp.Services
{
  public class ClientUserService
  {
    private readonly CulturappDbContext _context;
    private readonly IMapper _mapper;
    private readonly AuthService _authService;

    public ClientUserService(CulturappDbContext context, IMapper mapper, AuthService authService)
    {
      _context = context;
      _mapper = mapper;
      _authService = authService;
    }

    public async Task<List<ClientUserResponse>> GetClientUsersAsync()
    {
      var clientList = await _context.ClientUsers.ToListAsync();
      var clientUserResponseList = _mapper.Map<List<ClientUserResponse>>(clientList);
      return clientUserResponseList;
    }

    public async Task<ClientUserResponse?> GetClientUserByIdAsync(int id)
    {
      var clientUser = await _context.ClientUsers.FindAsync(id);
      var clientUserResponse = _mapper.Map<ClientUserResponse>(clientUser);
      return clientUserResponse;
    }

    public async Task<ClientUser?> CreateClientUserAsync(ClientUserRequest clientUserRequest)
    {
      var user = await _authService.FindUser(clientUserRequest.Email!);

      var userClient = _mapper.Map<ClientUser>(clientUserRequest);

      userClient.CPF = user!.CPF;
      userClient.FullName = user.FullName;
      userClient.UserName = user.UserName;

      var existingUser = await _context.ClientUsers.FirstOrDefaultAsync(u => u.CPF == userClient.CPF || u.Email == userClient.Email);
      if (existingUser != null)
      {
        return null;
      }
      else
      {
        _context.ClientUsers.Add(userClient);
        await _context.SaveChangesAsync();
        return userClient;
      }

    }

    public async Task<ClientUser?> UpdateClientUserAsync(ClientUserRequest clientUserRequest)
    {
      var clientUser = _mapper.Map<ClientUser>(clientUserRequest);
      _context.ClientUsers.Update(clientUser);
      await _context.SaveChangesAsync();
      return clientUser;
    }

    public async Task<ClientUser?> DeleteClientUserAsync(int id)
    {
      var user = await _context.ClientUsers.FindAsync(id);
      if (user != null)
      {
        _context.ClientUsers.Remove(user);
        await _context.SaveChangesAsync();
      }

      return user;
    }

  }
}