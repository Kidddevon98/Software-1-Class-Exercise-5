﻿using PetStore;
using System.Text.Json;

var productLogic = new ProductLogic();

Console.WriteLine("Press 1 to add a Dog Leash product");
Console.WriteLine("Press 2 to view a Dog Leash Product");
Console.WriteLine("Press 3 to view only in-stock products");
Console.WriteLine("Press 4 to get total price of in-stock inventory");
Console.WriteLine("Type 'exit' to quit");

string? userInput = Console.ReadLine();

while (userInput?.ToLower() != "exit")
{
    if (userInput == "1")
    {
        var dogLeash = new DogLeash();

        Console.Write("Enter the material the leash is made out of: ");
        dogLeash.Material = Console.ReadLine() ?? "Unknown";

        Console.Write("Enter the length in inches: ");
        if (int.TryParse(Console.ReadLine(), out int length))
        {
            dogLeash.LengthInches = length;
        }

        Console.Write("Enter the name of the leash: ");
        dogLeash.Name = Console.ReadLine() ?? "Unknown";

        Console.Write("Enter a short description: ");
        dogLeash.Description = Console.ReadLine() ?? "No description";

        Console.Write("Enter the price: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            dogLeash.Price = price;
        }

        Console.Write("Enter quantity: ");
        if (int.TryParse(Console.ReadLine(), out int quantity))
        {
            dogLeash.Quantity = quantity;
        }

        productLogic.AddProduct(dogLeash);
        Console.WriteLine("Dog Leash added.");
    }
    else if (userInput == "2")
    {
        Console.Write("Enter the name of the leash: ");
        var dogLeashName = Console.ReadLine();
        var dogLeash = productLogic.GetDogLeashByName(dogLeashName!);
        Console.WriteLine(JsonSerializer.Serialize(dogLeash));
    }
    else if (userInput == "3")
    {
        var inStockProducts = productLogic.GetOnlyInStockProducts();
        Console.WriteLine(JsonSerializer.Serialize(inStockProducts));
    }
    else if (userInput == "4")
    {
        var totalPrice = productLogic.GetTotalPriceOfInventory();
        Console.WriteLine($"Total price of in-stock inventory: {totalPrice:C}");
    }

    Console.WriteLine("Press 1 to add a Dog Leash product");
    Console.WriteLine("Press 2 to view a Dog Leash Product");
    Console.WriteLine("Press 3 to view only in-stock products");
    Console.WriteLine("Press 4 to get total price of in-stock inventory");
    Console.WriteLine("Type 'exit' to quit");

    userInput = Console.ReadLine();
}
