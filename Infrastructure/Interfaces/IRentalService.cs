using System;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IRentalService
{
    Task<List<Rental>> GetAllRentalsAsync();
    Task<Rental?> GetRentalByIdAsync(int id);
    Task AddRental(Rental rental);
    Task UpdateRental(Rental rental);
    Task DeleteRental(int id);
}
