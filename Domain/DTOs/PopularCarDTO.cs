using System;

namespace Domain.DTOs;

public class PopularCarDTO
{
    public string Model { get; set; } = string.Empty;
    public int RentalCount { get; set; }
}
