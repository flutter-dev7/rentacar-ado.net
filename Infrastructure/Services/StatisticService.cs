using System;
using Dapper;
using Domain.DTOs;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Npgsql;

namespace Infrastructure.Services;

public class StatisticService : IStatisticService
{
    private readonly DataContext context = new();

    public async Task<decimal> GetTotalRentalIncome()
    {
        try
        {
            using (NpgsqlConnection connection = context.GetConnection())
            {
                connection.Open();

                string sql = @"SELECT SUM(TotalCost) FROM Rentals";

                var res = await connection.ExecuteScalarAsync<decimal>(sql);

                return res;
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public async Task<PopularCarDTO> GetPopularCar()
    {
        try
        {
            using (NpgsqlConnection connection = context.GetConnection())
            {
                connection.Open();

                string sql = @"
                SELECT c.Model, COUNT(r.CarId) AS RentalsCount
                FROM Cars AS c
                JOIN Rentals AS r ON c.Id = r.CarId
                GROUP BY c.Model
                ORDER BY RentalsCount DESC
                LIMIT 1";

                var popularCar = await connection.QuerySingleOrDefaultAsync<PopularCarDTO>(sql);

                return popularCar!;
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public async Task<TopCustomerWithRentalCount> GetTopCustomerWithRentalCount()
    {
        try
        {
            using (NpgsqlConnection connection = context.GetConnection())
            {
                connection.Open();

                string sql = @"
                SELECT c.FullName, COUNT(r.CustomerId) AS RentalsCount
                FROM Customers AS c
                JOIN Rentals AS r ON c.Id = r.CustomerId
                GROUP BY c.FullName
                ORDER BY RentalsCount DESC
                LIMIT 1";

                var topCustomer = await connection.QuerySingleOrDefaultAsync<TopCustomerWithRentalCount>(sql);

                return topCustomer!;
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public async Task<decimal> GetAverageRentalTotalCost()
    {
        try
        {
            using (NpgsqlConnection connection = context.GetConnection())
            {
                connection.Open();

                string sql = "SELECT AVG(TotalCost) FROM Rentals";

                var res = await connection.ExecuteScalarAsync<decimal>(sql);

                return res;
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public async Task<int> GetActiveRentalToday()
    {
        try
        {
            using (NpgsqlConnection connection = context.GetConnection())
            {
                connection.Open();

                string sql = @"
                SELECT COUNT(*) FROM Rentals
                WHERE StartDate <= CURRENT_DATE AND EndDate >= CURRENT_DATE";

                var res = await connection.ExecuteScalarAsync<int>(sql);

                return res;
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }
}
