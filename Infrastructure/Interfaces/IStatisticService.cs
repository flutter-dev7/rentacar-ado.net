using System;
using Domain.DTOs;

namespace Infrastructure.Interfaces;

public interface IStatisticService
{
    Task<decimal> GetTotalRentalIncome();
    Task<PopularCarDTO> GetPopularCar();
    Task<TopCustomerWithRentalCount> GetTopCustomerWithRentalCount();
    Task<decimal> GetAverageRentalTotalCost();
    Task<int> GetActiveRentalToday();
}
