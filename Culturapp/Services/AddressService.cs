using AutoMapper;
using Culturapp.Data;
using Culturapp.Models;
using Culturapp.Models.Requests;
using Microsoft.EntityFrameworkCore;

namespace Culturapp.Services
{
  public class AddressService
  {
    private readonly CulturappDbContext _context;
    private readonly IMapper _mapper;

    public AddressService(CulturappDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<Address?> GetAddressByIdAsync(int id)
    {
      return await _context.Addresses.FindAsync(id);
    }

    public async Task CreateAddressAsync(AddressRequest addressRequest)
    {
      var address = _mapper.Map<Address>(addressRequest);
      _context.Addresses.Add(address);
      await _context.SaveChangesAsync();
    }

    public async Task<Address?> UpdateAddressAsync(int id, AddressRequest? addressRequest)
    {
      var address = await _context.Addresses.FindAsync(id);

      if (address == null || addressRequest == null)
      {
        return null;
      }

      // Map updated fields from request to entity
      _mapper.Map(addressRequest, address);

      _context.Addresses.Update(address);
      await _context.SaveChangesAsync();

      return address;
    }

    public async Task DeleteAddressAsync(int id)
    {
      var address = await _context.Addresses.FindAsync(id);
      if (address != null)
      {
        _context.Addresses.Remove(address);
        await _context.SaveChangesAsync();
      }
    }
  }
}