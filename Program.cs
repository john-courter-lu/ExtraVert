
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

       Console.WriteLine("\nPress any key to enter the main menu...");
       Console.ReadKey();
       Console.Clear();

       InitialOptions();

       choice = Console.ReadLine().Trim();
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
              PostAPlant();
       }
       else if (choice == "3")
       {
              AdoptAPlant();
       }
       else if (choice == "4")
       {
              DelistAPlant();
       }
       else if (choice == "5")
       {
              PlantOfTheDay();
       }
       else if (choice == "6")
       {
              SearchForPlants();
       }
       else
       {
              Console.WriteLine($"Choose a number in the option menu!");
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
                        4. Delist a plant
                        5. Choose Plant of the Day
                        6. Search for Plants by Light Needs");
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

void PostAPlant()
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

void AdoptAPlant()
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

void DelistAPlant()
{
       Console.WriteLine("Plants available for delisting:");
       for (int i = 0; i < plants.Count; i++)
       {
              Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} {(plants[i].Sold ? " (Sold)" : "")} for {plants[i].AskingPrice:C}");
       }

       Console.Write("Enter the index of the plant you want to delist: ");
       int index = int.Parse(Console.ReadLine()) - 1;

       if (index >= 0 && index < plants.Count)
       {
              Plant plantToRemove = plants[index];
              plants.RemoveAt(index);
              Console.WriteLine($"{plantToRemove.Species} has been delisted.");
       }
       else
       {
              Console.WriteLine("Invalid selection. Please choose a valid plant to delist.");
       }
}

void PlantOfTheDay()
{
       Random random = new Random();
       int randomIndex;

       Plant selectedPlant = null;

       while (selectedPlant == null)
       {
              randomIndex = random.Next(0, plants.Count);
              Plant potentialPlant = plants[randomIndex];

              if (!potentialPlant.Sold)
              {
                     selectedPlant = potentialPlant;
              }
       }

       Console.WriteLine("Plant of the Day:");
       Console.WriteLine($"Species: {selectedPlant.Species}");
       Console.WriteLine($"Location: {selectedPlant.City}");
       Console.WriteLine($"Light Needs: {selectedPlant.LightNeeds}");
       Console.WriteLine($"Price: {selectedPlant.AskingPrice:C}");


}


void SearchForPlants()
{
    Console.Clear();

    Console.Write("Enter the maximum light needs (1-5): ");
    int maxLightNeeds = int.Parse(Console.ReadLine());

    List<Plant> matchingPlants = new List<Plant>();

    foreach (Plant plant in plants)
    {
        if (plant.LightNeeds <= maxLightNeeds)
        {
            matchingPlants.Add(plant);
        }
    }

    if (matchingPlants.Count == 0)
    {
        Console.WriteLine("No plants match the specified light needs.");
    }
    else
    {
        Console.WriteLine("Plants matching the specified light needs:");
        for (int i = 0; i < matchingPlants.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {matchingPlants[i].Species} in {matchingPlants[i].City} for {matchingPlants[i].AskingPrice:C}");
            Console.WriteLine($"Light Needs: {matchingPlants[i].LightNeeds}");
        }
    }

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
    Console.Clear();
}
