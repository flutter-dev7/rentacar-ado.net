using System;

namespace Domain.Entities;

public class Car
{
    public int Id { get; set; }
    public string Model { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public int Year { get; set; }
    public decimal PricePerDay { get; set; }
}
