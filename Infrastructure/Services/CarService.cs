using System;
using Dapper;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Npgsql;

namespace Infrastructure.Services;

public class CarService : ICarService
{
    private readonly DataContext context = new();

    public async Task<List<Car>> GetAllCarsAsync()
    {
        try
        {
            using (NpgsqlConnection connection = context.GetConnection())
            {
                connection.Open();

                string sql = "SELECT * FROM Cars";

                var cars = await connection.QueryAsync<Car>(sql);

                return cars.ToList();
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public async Task<Car?> GetCarByIdAsync(int id)
    {
        try
        {
            using (NpgsqlConnection connection = context.GetConnection())
            {
                connection.Open();

                string sql = @"
                SELECT * FROM Cars
                WHERE Id = @id";

                var car = await connection.QuerySingleOrDefaultAsync<Car>(sql, new { id });

                return car;
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public async Task AddCarAsync(Car car)
    {
        try
        {
            using (NpgsqlConnection connection = context.GetConnection())
            {
                connection.Open();

                string sql = @"
                INSERT INTO Cars (Model, Manufacturer, Year, PricePerDay)
                VALUES (@model, @manufacturer, @year, @priceperday)";

                await connection.ExecuteAsync(sql, car);
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return;
        }
    }

    public async Task UpdateCarAsync(Car car)
    {
        try
        {
            using (NpgsqlConnection connection = context.GetConnection())
            {
                connection.Open();

                string sql = @"
                UPDATE Cars SET
                Model = @model,
                Manufacturer = @manufacturer,
                Year = @year,
                PricePerDay = @priceperday
                WHERE Id = @id";

                await connection.ExecuteAsync(sql, car);
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return;
        }
    }

    public async Task DeleteCarAsync(int id)
    {
        try
        {
            using (NpgsqlConnection connection = context.GetConnection())
            {
                connection.Open();

                string sql = @"
                DELETE FROM Cars
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
