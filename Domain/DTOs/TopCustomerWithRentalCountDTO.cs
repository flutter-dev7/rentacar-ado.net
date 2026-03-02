using System;

namespace Domain.DTOs;

public class TopCustomerWithRentalCount
{
    public string FullName { get; set; } = string.Empty;
    public int RentalCount { get; set; }
}
