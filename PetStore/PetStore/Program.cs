using PetStore;
using System.Text.Json;
using System.Text.Json.Serialization;

var productLogic = new ProductLogic();

Console.WriteLine("Press 1 to add a Dog Leash product");
Console.WriteLine("Press 2 to view a Dog Leash Product");
Console.WriteLine("Press 3 to get the total price of in-stock inventory");
Console.WriteLine("Type 'exit' to quit");

string? userInput = Console.ReadLine();

while (userInput?.ToLower() != "exit") // Check if userInput is null
{
    if (userInput == "1")
    {
        var dogLeash = new DogLeash();

        Console.WriteLine("Creating a dog leash...");

        Console.Write("Enter the material the leash is made out of: ");
        dogLeash.Material = Console.ReadLine() ?? "Unknown"; // Default if null

        Console.Write("Enter the length in inches: ");
        string? lengthInput = Console.ReadLine();
        if (int.TryParse(lengthInput, out int length))
        {
            dogLeash.LengthInches = length;
        }
        else
        {
            Console.WriteLine("Invalid input. Length set to 0.");
            dogLeash.LengthInches = 0;
        }

        Console.Write("Enter the name of the leash: ");
        dogLeash.Name = Console.ReadLine() ?? "Unknown"; // Default if null

        Console.Write("Give the product a short description: ");
        dogLeash.Description = Console.ReadLine() ?? "No description"; // Default if null

        Console.Write("Give the product a price: ");
        string? priceInput = Console.ReadLine();
        if (decimal.TryParse(priceInput, out decimal price))
        {
            dogLeash.Price = price;
        }
        else
        {
            Console.WriteLine("Invalid input. Price set to 0.");
            dogLeash.Price = 0;
        }

        Console.Write("How many products do you have on hand? ");
        string? quantityInput = Console.ReadLine();
        if (int.TryParse(quantityInput, out int quantity))
        {
            dogLeash.Quantity = quantity;
        }
        else
        {
            Console.WriteLine("Invalid input. Quantity set to 0.");
            dogLeash.Quantity = 0;
        }

        productLogic.AddProduct(dogLeash);
        Console.WriteLine("Added a dog leash");
    }
    else if (userInput == "2")
    {
        Console.Write("What is the name of the dog leash you would like to view? ");
        var dogLeashName = Console.ReadLine();
        
        if (!string.IsNullOrEmpty(dogLeashName)) // Check if the input is not null or empty
        {
            var dogLeash = productLogic.GetDogLeashByName(dogLeashName);
            Console.WriteLine(JsonSerializer.Serialize(dogLeash));
        }
        else
        {
            Console.WriteLine("Invalid input. Name cannot be null or empty.");
        }
        Console.WriteLine();
    }
    else if (userInput == "3")
    {
        var totalPrice = productLogic.GetTotalPriceOfInventory();
        Console.WriteLine($"Total price of in-stock inventory: {totalPrice:C}");
    }

    Console.WriteLine("Press 1 to add a product");
    Console.WriteLine("Press 2 to view a Dog Leash Product");
    Console.WriteLine("Press 3 to get the total price of in-stock inventory");
    Console.WriteLine("Type 'exit' to quit");
    userInput = Console.ReadLine();
}
