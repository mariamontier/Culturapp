using AutoMapper;
using Culturapp.Data;
using Culturapp.Models;
using Culturapp.Models.Requests;
using Culturapp.Models.Responses;
using Microsoft.EntityFrameworkCore;

namespace Culturapp.Services
{
  public class ClientUserService
  {
    private readonly CulturappDbContext _context;
    private readonly IMapper _mapper;

    public ClientUserService(CulturappDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
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

    public async Task<ClientUserResponse?> CreateClientUserAsync(ApplicationUser user)
    {

      var userClient = new ClientUser
      {
        Email = user!.Email,
        CPF = user.CPF,
        FullName = user.FullName,
        UserName = user.UserName
      };

      var existingUser = await _context.ClientUsers.FirstOrDefaultAsync(u => u.CPF == userClient.CPF || u.Email == userClient.Email);
      if (existingUser != null)
      {
        return null;
      }
      else
      {
        _context.ClientUsers.Add(userClient);
        await _context.SaveChangesAsync();
        var userClientResponse = _mapper.Map<ClientUserResponse>(userClient);
        return userClientResponse;
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