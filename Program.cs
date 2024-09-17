using System;
using System.Text.Json;

namespace StoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var productLogic = new ProductLogic();

            Console.WriteLine("Press 1 to add a product");
            Console.WriteLine("Press 2 to view a dog leash by name");
            Console.WriteLine("Type 'exit' to quit");

            string userInput = Console.ReadLine();

            while (userInput.ToLower() != "exit")
            {
                if (userInput == "1")
                {
                    Console.WriteLine("Enter product name:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter product price:");
                    decimal price = decimal.Parse(Console.ReadLine());

                    Console.WriteLine("Enter product quantity:");
                    int quantity = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter product description:");
                    string description = Console.ReadLine();

                    Console.WriteLine("Is it a dog leash or cat food? (d/c)");
                    string type = Console.ReadLine();

                    Product product;

                    if (type.ToLower() == "d")
                    {
                        Console.WriteLine("Enter leash length in inches:");
                        int length = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter leash material:");
                        string material = Console.ReadLine();

                        product = new DogLeash
                        {
                            Name = name,
                            Price = price,
                            Quantity = quantity,
                            Description = description,
                            LengthInches = length,
                            Material = material
                        };
                    }
                    else
                    {
                        Console.WriteLine("Is it kitten food? (true/false)");
                        bool kittenFood = bool.Parse(Console.ReadLine());

                        product = new CatFood
                        {
                            Name = name,
                            Price = price,
                            Quantity = quantity,
                            Description = description,
                            KittenFood = kittenFood
                        };
                    }

                    productLogic.AddProduct(product);
                    Console.WriteLine("Product added!");
                }
                else if (userInput == "2")
                {
                    Console.WriteLine("Enter the name of the dog leash:");
                    string name = Console.ReadLine();

                    DogLeash leash = productLogic.GetDogLeashByName(name);

                    if (leash != null)
                    {
                        Console.WriteLine(JsonSerializer.Serialize(leash));
                    }
                    else
                    {
                        Console.WriteLine("Dog leash not found.");
                    }
                }

                Console.WriteLine("Press 1 to add a product");
                Console.WriteLine("Press 2 to view a dog leash by name");
                Console.WriteLine("Type 'exit' to quit");

                userInput = Console.ReadLine();
            }
        }
    }
}
