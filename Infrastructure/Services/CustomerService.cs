using System;
using Dapper;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Npgsql;

namespace Infrastructure.Services;

public class CustomerService : ICustomerService
{
    private readonly DataContext context = new();

    public async Task<List<Customer>> GetAllCustomersAsync()
    {
        try
        {
            using (NpgsqlConnection connection = context.GetConnection())
            {
                connection.Open();

                string sql = "SELECT * FROM Customers";

                var customers = await connection.QueryAsync<Customer>(sql);

                return customers.ToList();
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public async Task<Customer?> GetCustomerByIdAsync(int id)
    {
        try
        {
            using (NpgsqlConnection connection = context.GetConnection())
            {
                connection.Open();

                string sql = @"
                SELECT * FROM Customers
                WHERE Id = @id";

                var customer = await connection.QuerySingleOrDefaultAsync(sql, new { id });

                return customer;
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public async Task AddCustomer(Customer customer)
    {
        try
        {
            using (NpgsqlConnection connection = context.GetConnection())
            {
                connection.Open();

                string sql = @"
                INSERT INTO Customers (FullName, Phone, Email)
                VALUES (@fullname, phone, email)";

                await connection.ExecuteAsync(sql, customer);
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public async Task UpdateCustomer(Customer customer)
    {
        try
        {
            using (NpgsqlConnection connection = context.GetConnection())
            {
                connection.Open();

                string sql = @"
                UPDATE Customers SET
                FullName = @fullname,
                Phone = @phone,
                Email = @email
                WHERE Id = @id";

                await connection.ExecuteAsync(sql, customer);
            }
        }
        catch (System.Exception ex)
        {
            Console.Write($"Error: {ex.Message}");
            throw;
        }
    }

    public async Task DeleteCustomer(int id)
    {
        try
        {
            using (NpgsqlConnection connection = context.GetConnection())
            {
                connection.Open();

                string sql = @"
                DELETE FROM Customers
                WHERE Id = @id";

                await connection.ExecuteAsync(sql, new { id });
            }
        }
        catch (System.Exception ex)
        {
            Console.Write($"Error: {ex.Message}");
            throw;
        }
    }
}
