using Domain.Entities;
using Infrastructure.Services;

CarService carService = new CarService();
CustomerService customerService = new CustomerService();
RentalService rentalService = new RentalService();
StatisticService statisticService = new StatisticService();

while (true)
{
    System.Console.WriteLine();
    System.Console.WriteLine("==== MENU ====");
    System.Console.WriteLine("1. Car Menu");
    System.Console.WriteLine("2. Customer Menu");
    System.Console.WriteLine("3. Rental Menu");
    System.Console.WriteLine("4. Statistic Menu");
    System.Console.WriteLine("0. Exit");
    System.Console.WriteLine();

    Console.Write("Enter number: ");
    string choice = Console.ReadLine()!;
    switch (choice)
    {
        case "1":
            await CarMenu();
            break;
        case "2":
            await CustomerMenu();
            break;
        case "3":
            await RentalMenu();
            break;
        case "4":
            await StatisticMenu();
            break;
        case "0":
            return;
        default:
            break;
    }
}

async Task CarMenu()
{
    while (true)
    {
        System.Console.WriteLine();
        System.Console.WriteLine("==== CAR MENU ====");
        System.Console.WriteLine("1. Get All Cars");
        System.Console.WriteLine("2. Get Car By Id");
        System.Console.WriteLine("3. Add Car");
        System.Console.WriteLine("4. Update Car");
        System.Console.WriteLine("5. Delete Car");
        System.Console.WriteLine("0. Exit");
        System.Console.WriteLine();

        Console.Write("Enter number: ");
        string choice = Console.ReadLine()!;

        switch (choice)
        {
            case "1":
                await GetAllCars();
                break;
            case "2":
                await GetCarById();
                break;
            case "3":
                await AddCar();
                break;
            case "4":
                await UpdateCar();
                break;
            case "5":
                await DeleteCar();
                break;
            case "0":
                return;
            default:
                break;
        }
    }

    async Task GetAllCars()
    {
        List<Car> cars = await carService.GetAllCarsAsync();
        foreach (var item in cars)
        {
            System.Console.WriteLine($"CarId: {item.Id}, Model: {item.Model}, Manufacturer: {item.Manufacturer}, Year: {item.Year}, PricePerDay: {item.PricePerDay}");
        }
    }

    async Task GetCarById()
    {
        Console.Write("Enter Id for get car: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var car = await carService.GetCarByIdAsync(id);

        System.Console.WriteLine($"CarId: {car!.Id}, Model: {car.Model}, Manufacturer: {car.Manufacturer}, Year: {car.Year}, PricePerDay: {car.PricePerDay}");
    }

    async Task AddCar()
    {
        Console.Write("Enter Model: ");
        string model = Console.ReadLine()!;

        Console.Write("Enter Manufacturer: ");
        string manufacturer = Console.ReadLine()!;

        Console.Write("Enter Year: ");
        int year = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Price per day: ");
        decimal priceperday = Convert.ToDecimal(Console.ReadLine());

        Car car = new Car()
        {
            Model = model,
            Manufacturer = manufacturer,
            Year = year,
            PricePerDay = priceperday
        };

        await carService.AddCarAsync(car);
    }

    async Task UpdateCar()
    {
        Console.Write("Enter CarId for update car: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Model: ");
        string model = Console.ReadLine()!;

        Console.Write("Enter Manufacturer: ");
        string manufacturer = Console.ReadLine()!;

        Console.Write("Enter Year: ");
        int year = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Price per day: ");
        decimal priceperday = Convert.ToDecimal(Console.ReadLine());

        Car car = new Car()
        {
            Id = id,
            Model = model,
            Manufacturer = manufacturer,
            Year = year,
            PricePerDay = priceperday
        };

        await carService.UpdateCarAsync(car);
    }

    async Task DeleteCar()
    {
        Console.Write("Enter CarId for delete car: ");
        int id = Convert.ToInt32(Console.ReadLine());

        await carService.DeleteCarAsync(id);
    }
}

async Task CustomerMenu()
{
    while (true)
    {
        System.Console.WriteLine();
        System.Console.WriteLine("==== Customer MENU ====");
        System.Console.WriteLine("1. Get All Customers");
        System.Console.WriteLine("2. Get Customer By Id");
        System.Console.WriteLine("3. Add Customer");
        System.Console.WriteLine("4. Update Customer");
        System.Console.WriteLine("5. Delete Customer");
        System.Console.WriteLine("0. Exit");
        System.Console.WriteLine();

        Console.Write("Enter number: ");
        string choice = Console.ReadLine()!;

        switch (choice)
        {
            case "1":
                await GetAllCustomers();
                break;
            case "2":
                await GetCustomerById();
                break;
            case "3":
                await AddCustomer();
                break;
            case "4":
                await UpdateCustomer();
                break;
            case "5":
                await DeleteCustomer();
                break;
            case "0":
                return;
            default:
                break;
        }
    }

    async Task GetAllCustomers()
    {
        List<Customer> customers = await customerService.GetAllCustomersAsync();
        foreach (var item in customers)
        {
            System.Console.WriteLine($"CustomerId: {item.Id}, FullName: {item.FullName}, Phone: {item.Phone}, Email: {item.Phone}");
        }
    }

    async Task GetCustomerById()
    {
        Console.Write("Enter CustomerId for get customer: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var customer = await customerService.GetCustomerByIdAsync(id);

        System.Console.WriteLine($"CustomerId: {customer!.Id}, FullName: {customer.FullName}, Phone: {customer.Phone}, Email: {customer.Phone}");
    }

    async Task AddCustomer()
    {
        Console.Write("Enter FullName: ");
        string fullname = Console.ReadLine()!;

        Console.Write("Enter Phone: ");
        string phone = Console.ReadLine()!;

        Console.Write("Enter Email: ");
        string email = Console.ReadLine()!;

        Customer customer = new Customer()
        {
            FullName = fullname,
            Phone = phone,
            Email = email
        };

        await customerService.AddCustomerAsync(customer);
    }

    async Task UpdateCustomer()
    {
        Console.Write("Enter CustomerId for update: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter FullName: ");
        string fullname = Console.ReadLine()!;

        Console.Write("Enter Phone: ");
        string phone = Console.ReadLine()!;

        Console.Write("Enter Email: ");
        string email = Console.ReadLine()!;

        Customer customer = new Customer()
        {
            Id = id,
            FullName = fullname,
            Phone = phone,
            Email = email
        };

        await customerService.UpdateCustomerAsync(customer);
    }

    async Task DeleteCustomer()
    {
        Console.Write("Enter CustomerId for delete: ");
        int id = Convert.ToInt32(Console.ReadLine());

        await customerService.DeleteCustomerAsync(id);
    }
}

async Task RentalMenu()
{
    while (true)
    {
        Console.WriteLine();
        Console.WriteLine("==== RENTAL MENU ====");
        Console.WriteLine("1. Get All Rentals");
        Console.WriteLine("2. Get Rental By Id");
        Console.WriteLine("3. Add Rental");
        Console.WriteLine("4. Update Rental");
        Console.WriteLine("5. Delete Rental");
        Console.WriteLine("0. Exit");
        Console.WriteLine();

        Console.Write("Enter number: ");
        string choice = Console.ReadLine()!;

        switch (choice)
        {
            case "1":
                await GetAllRentals();
                break;
            case "2":
                await GetRentalById();
                break;
            case "3":
                await AddRental();
                break;
            case "4":
                await UpdateRental();
                break;
            case "5":
                await DeleteRental();
                break;
            case "0":
                return;
        }
    }

    async Task GetAllRentals()
    {
        var rentals = await rentalService.GetAllRentalsAsync();

        foreach (var item in rentals)
        {
            Console.WriteLine($"RentalId: {item.Id}, CarId: {item.CarId}, CustomerId: {item.CustomerId}, Start: {item.StartDate}, End: {item.EndDate}, Total: {item.TotalCost}");
        }
    }

    async Task GetRentalById()
    {
        Console.Write("Enter RentalId: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var rental = await rentalService.GetRentalByIdAsync(id);

        Console.WriteLine($"RentalId: {rental!.Id}, CarId: {rental.CarId}, CustomerId: {rental.CustomerId}, Start: {rental.StartDate}, End: {rental.EndDate}, Total: {rental.TotalCost}");
    }

    async Task AddRental()
    {
        Console.Write("Enter CarId: ");
        int carId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter CustomerId: ");
        int customerId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter StartDate: ");
        DateOnly start = DateOnly.Parse(Console.ReadLine()!);

        Console.Write("Enter EndDate: ");
        DateOnly end = DateOnly.Parse(Console.ReadLine()!);

        Console.Write("Enter TotalCost: ");
        decimal total = Convert.ToDecimal(Console.ReadLine());

        Rental rental = new Rental()
        {
            CarId = carId,
            CustomerId = customerId,
            StartDate = start,
            EndDate = end,
            TotalCost = total
        };

        await rentalService.AddRentalAsync(rental);
    }

    async Task UpdateRental()
    {
        Console.Write("Enter RentalId: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter CarId: ");
        int carId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter CustomerId: ");
        int customerId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter StartDate: ");
        DateOnly start = DateOnly.Parse(Console.ReadLine()!);

        Console.Write("Enter EndDate: ");
        DateOnly end = DateOnly.Parse(Console.ReadLine()!);

        Console.Write("Enter TotalCost: ");
        decimal total = Convert.ToDecimal(Console.ReadLine());

        Rental rental = new Rental()
        {
            Id = id,
            CarId = carId,
            CustomerId = customerId,
            StartDate = start,
            EndDate = end,
            TotalCost = total
        };

        await rentalService.UpdateRentalAsync(rental);
    }

    async Task DeleteRental()
    {
        Console.Write("Enter RentalId: ");
        int id = Convert.ToInt32(Console.ReadLine());

        await rentalService.DeleteRentalAsync(id);
    }
}

async Task StatisticMenu()
{
    while (true)
    {
        Console.WriteLine();
        Console.WriteLine("==== STATISTIC MENU ====");
        Console.WriteLine("1. Total revenue");
        Console.WriteLine("2. Most rented car");
        Console.WriteLine("3. Top customer");
        Console.WriteLine("4. Average rental cost");
        Console.WriteLine("5. Active rentals today");
        Console.WriteLine("0. Exit");
        Console.WriteLine();

        Console.Write("Enter number: ");
        string choice = Console.ReadLine()!;

        switch (choice)
        {
            case "1":
                await GetTotalRevenue();
                break;
            case "2":
                await GetMostRentedCar();
                break;
            case "3":
                await GetTopCustomer();
                break;
            case "4":
                await GetAverageRentalCost();
                break;
            case "5":
                await GetActiveRentalsToday();
                break;
            case "0":
                return;
        }
    }

    async Task GetTotalRevenue()
    {
        var res = await statisticService.GetTotalRentalIncome();
        Console.WriteLine($"Total revenue from rentals: {res}");
    }

    async Task GetMostRentedCar()
    {
        var car = await statisticService.GetPopularCar();
        Console.WriteLine($"Model: {car.Model}, RentalsCount: {car.RentalsCount}");
    }

    async Task GetTopCustomer()
    {
        var customer = await statisticService.GetTopCustomerWithRentalCount();

        Console.WriteLine($"FullName: {customer.FullName}, RentalsCount: {customer.RentalsCount} rentals");
    }

    async Task GetAverageRentalCost()
    {
        var avg = await statisticService.GetAverageRentalTotalCost();
        Console.WriteLine($"Average rental cost: {avg}");
    }

    async Task GetActiveRentalsToday()
    {
        var res = await statisticService.GetActiveRentalToday();
        Console.WriteLine($"Active rentals today: {res}");
    }
}