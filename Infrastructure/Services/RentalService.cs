using System;
using Dapper;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Npgsql;

namespace Infrastructure.Services;

public class RentalService : IRentalService
{
    private readonly DataContext context = new();

    public async Task<List<Rental>> GetAllRentalsAsync()
    {
        try
        {
            using (NpgsqlConnection connection = context.GetConnection())
            {
                connection.Open();

                string sql = "SELECT * FROM Rentals";

                var rentals = await connection.QueryAsync<Rental>(sql);

                return rentals.ToList();
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public async Task<Rental?> GetRentalByIdAsync(int id)
    {
        try
        {
            using (NpgsqlConnection connection = context.GetConnection())
            {
                connection.Open();

                string sql = @"
                SELECT * FROM Rentals
                WHERE Id = @id";

                var rental = await connection.QuerySingleOrDefaultAsync(sql, new { id });

                return rental;
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public async Task AddRental(Rental rental)
    {
        try
        {
            using (NpgsqlConnection connection = context.GetConnection())
            {
                connection.Open();

                string sql = @"
                SELECT * FROM Rentals (CarId, CustomerId, StartDate, EndDate, TotalCost)
                VALUES (@carid, @customerid, @startdate, @enddate, @totalcost)";

                await connection.ExecuteAsync(sql);
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return;
        }
    }

    public async Task UpdateRental(Rental rental)
    {
        try
        {
            using (NpgsqlConnection connection = context.GetConnection())
            {
                connection.Open();

                string sql = @"
                UPDATE Rentals SET
                CarId = @carid,
                CustomerId = @customerid,
                StartDate = @startdate,
                EndDate = @enddate,
                TotalCost = @totalcost
                WHERE Id = @id";

                await connection.ExecuteAsync(sql, rental);
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return;
        }
    }

    public async Task DeleteRental(int id)
    {
        try
        {
            using (NpgsqlConnection connection = context.GetConnection())
            {
                connection.Open();

                string sql = @"
                DELETE FROM Rentals
                WHERE Id = @id";

                await connection.ExecuteAsync(sql, new { id });
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return;
        }
    }
}
