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

                var rental = await connection.QuerySingleOrDefaultAsync<Rental>(sql, new { id });

                return rental;
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public async Task AddRentalAsync(Rental rental)
    {
        try
        {
            using (NpgsqlConnection connection = context.GetConnection())
            {
                connection.Open();

                string sql = @"
                INSERT INTO Rentals (CarId, CustomerId, StartDate, EndDate, TotalCost)
                VALUES (@carid, @customerid, @startdate, @enddate, @totalcost)";

                await connection.ExecuteAsync(sql, new
                {
                    rental.CarId,
                    rental.CustomerId,
                    StartDate = rental.StartDate.ToDateTime(TimeOnly.MinValue),
                    EndDate = rental.EndDate.ToDateTime(TimeOnly.MinValue),
                    rental.TotalCost
                });
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return;
        }
    }

    public async Task UpdateRentalAsync(Rental rental)
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

                await connection.ExecuteAsync(sql, new
                {
                    rental.Id,
                    rental.CarId,
                    rental.CustomerId,
                    StartDate = rental.StartDate.ToDateTime(TimeOnly.MinValue),
                    EndDate = rental.EndDate.ToDateTime(TimeOnly.MinValue),
                    rental.TotalCost
                });
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return;
        }
    }

    public async Task DeleteRentalAsync(int id)
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
