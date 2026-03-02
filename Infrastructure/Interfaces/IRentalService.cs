using System;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IRentalService
{
    Task<List<Rental>> GetAllRentalsAsync();
    Task<Rental?> GetRentalByIdAsync(int id);
    Task AddRentalAsync(Rental rental);
    Task UpdateRentalAsync(Rental rental);
    Task DeleteRentalAsync(int id);
}
