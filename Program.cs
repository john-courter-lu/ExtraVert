
string greeting = @">>>
Welcome to Extra Vert
Your one-stop shop for used plants";

Console.WriteLine(greeting);

List<Plant> plants = new List<Plant>()
{
       new Plant
       {
       Species = "Rose",
       LightNeeds = 4,
       AskingPrice = 12.99M,
       City = "Los Angeles",
       ZIP = 90001,
       Sold = false
       },
       new Plant
       {
       Species = "Fern",
       LightNeeds = 2,
       AskingPrice = 8.49M,
       City = "New York",
       ZIP = 10001,
       Sold = true
       },
       new Plant
       {
       Species = "Lavender",
       LightNeeds = 3,
       AskingPrice = 9.99M,
       City = "Chicago",
       ZIP = 60601,
       Sold = false
       },
       new Plant
       {
       Species = "Succulent",
       LightNeeds = 5,
       AskingPrice = 6.99M,
       City = "San Francisco",
       ZIP = 94101,
       Sold = true
       },
       new Plant
       {
       Species = "Palm",
       LightNeeds = 4,
       AskingPrice = 19.99M,
       City = "Miami",
       ZIP = 33101,
       Sold = false
       }
};

string choice = null;
while (choice != "0")
{
       InitialOptions();

       choice = Console.ReadLine();
       if (choice == "0")
       {
              Console.WriteLine("Goodbye!");
       }
       else if (choice == "1")
       {
              ListPlants();
       }
       else if (choice == "2")
       {
              PostAPlant ();
       }
       else if (choice == "3")
       {
              AdoptAPlant ();
       }
       else if (choice == "4")
       {
              throw new NotImplementedException("Delist a plant");
       }
       else
       {
              Console.WriteLine("Choose a number between 0 and 4!");
       }
}

void InitialOptions()
{
       Console.WriteLine(@">>>
                     Choose an option:
                        0. Exit
                        1. View All Plants
                        2. Post a plant to be adopted
                        3. Adopt a plant
                        4. Delist a plant");
};

void ListPlants()
{
       Console.WriteLine(@">>>
                     Plants Inventory:");

       for (int i = 0; i < plants.Count; i++)
       {
              Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} {(plants[i].Sold ? "was sold" : "is available")} for {plants[i].AskingPrice:C} ");

       }

};

void PostAPlant ()
{
       {
            Console.Write("Enter plant species: ");
            string species = Console.ReadLine();

            Console.Write("Enter light needs (1-5): ");
            int lightNeeds = int.Parse(Console.ReadLine());

            Console.Write("Enter asking price: ");
            decimal askingPrice = decimal.Parse(Console.ReadLine());

            Console.Write("Enter city: ");
            string city = Console.ReadLine();

            Console.Write("Enter ZIP: ");
            int zip = int.Parse(Console.ReadLine());

            Plant newPlant = new Plant
            {
                Species = species,
                LightNeeds = lightNeeds,
                AskingPrice = askingPrice,
                City = city,
                ZIP = zip,
                Sold = false // New plants are not sold by default
            };

            plants.Add(newPlant);

            Console.WriteLine("Plant added successfully!");
        }
    }

void AdoptAPlant ()
{
    Console.WriteLine("Plants available for adoption:");
    for (int i = 0; i < plants.Count; i++)
    {
        if (!plants[i].Sold)
        {
            Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} for {plants[i].AskingPrice:C}");
        }
    }

    Console.Write("Enter the index of the plant you want to adopt: ");
    int index = int.Parse(Console.ReadLine()) - 1;

    if (index >= 0 && index < plants.Count && !plants[index].Sold)
    {
        plants[index].Sold = true;
        Console.WriteLine($"Congratulations! You have adopted {plants[index].Species}.");
    }
    else
    {
        Console.WriteLine("Invalid selection. Please choose an available plant.");
    }
}