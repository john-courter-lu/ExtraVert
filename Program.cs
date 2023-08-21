
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
       Sold = false,
       AvailableUntil = new DateTime(2023,5,3)
       },
       new Plant
       {
       Species = "Fern",
       LightNeeds = 2,
       AskingPrice = 8.49M,
       City = "New York",
       ZIP = 10001,
       Sold = true,
       AvailableUntil = new DateTime(2023,12,3)
       },
       new Plant
       {
       Species = "Lavender",
       LightNeeds = 3,
       AskingPrice = 9.99M,
       City = "Chicago",
       ZIP = 60601,
       Sold = false,
       AvailableUntil = DateTime.Now.AddDays(7)
       },
       new Plant
       {
       Species = "Succulent",
       LightNeeds = 5,
       AskingPrice = 6.99M,
       City = "San Francisco",
       ZIP = 94101,
       Sold = true,
       AvailableUntil = DateTime.Now.AddMonths(3)
       },
       new Plant
       {
       Species = "Palm",
       LightNeeds = 4,
       AskingPrice = 19.99M,
       City = "Miami",
       ZIP = 33101,
       Sold = false,
       AvailableUntil = DateTime.Now.AddYears(1)
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
       else if (choice == "7")
       {
              ViewAppStats();
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
                        6. Search for Plants by Light Needs
                        7. View app statistics");
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
    Console.Clear();

    Console.Write("Enter plant species: ");
    string species = Console.ReadLine();

    int? lightNeeds = null;
    while (lightNeeds == null)
    {
        Console.Write("Enter light needs (1-5): ");
        try
        {
            int input = int.Parse(Console.ReadLine());

            if (input >= 1 && input <= 5)
            {
                lightNeeds = input;
            }
            else
            {
                Console.WriteLine("Invalid light needs input. Please enter a number between 1 and 5.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input format. Please enter a valid number.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    decimal? askingPrice = null;
    while (askingPrice == null)
    {
        Console.Write("Enter asking price: ");
        try
        {
            askingPrice = decimal.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input format. Please enter a valid number.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    Console.Write("Enter city: ");
    string city = Console.ReadLine();

    int? zip = null;
    while (zip == null)
    {
        Console.Write("Enter ZIP: ");
        try
        {
            zip = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input format. Please enter a valid number.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    DateTime? expirationDate = null;
    while (expirationDate == null)
    {
        try
        {
            Console.WriteLine("Enter the expiration date (Year, Month, Day):");
            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Month: ");
            int month = int.Parse(Console.ReadLine());

            Console.Write("Day: ");
            int day = int.Parse(Console.ReadLine());

            expirationDate = new DateTime(year, month, day);
           
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input format. Please enter a valid number.");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Invalid date input. Please enter a valid date.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    try
    {
        Plant newPlant = new Plant
        {
            Species = species,
            LightNeeds = lightNeeds.Value,
            AskingPrice = askingPrice.Value,
            City = city,
            ZIP = zip.Value,
            Sold = false,
            AvailableUntil = expirationDate.Value
        };

        plants.Add(newPlant);

        Console.WriteLine("Plant added successfully!");
        Console.WriteLine("New Plant Details:");
        Console.WriteLine($"Species: {newPlant.Species}");
        Console.WriteLine($"Light Needs: {newPlant.LightNeeds}");
        Console.WriteLine($"Asking Price: {newPlant.AskingPrice:C}");
        Console.WriteLine($"City: {newPlant.City}");
        Console.WriteLine($"ZIP: {newPlant.ZIP}");
        Console.WriteLine($"Available Until: {newPlant.AvailableUntil.ToShortDateString()}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
    Console.Clear();
}


void AdoptAPlant()
{
       Console.WriteLine("Plants available for adoption:");
       for (int i = 0; i < plants.Count; i++)
       {
              if (!plants[i].Sold && plants[i].AvailableUntil > DateTime.Now)
              {
                     Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} for {plants[i].AskingPrice:C}");
                     Console.WriteLine($"Available Until: {plants[i].AvailableUntil.ToShortDateString()}");
              }
       }

       Console.Write("Enter the index of the plant you want to adopt: ");
       int index = int.Parse(Console.ReadLine()) - 1;

       if (index >= 0 && index < plants.Count)
       {
              plants[index].Sold = true;
              Console.WriteLine($"Congratulations! You have adopted {plants[index].Species}.");
       }
       else
       {
              Console.WriteLine("Invalid selection. Please choose an available plant.");
       }

       Console.WriteLine("\nPress any key to continue...");
       Console.ReadKey();
       Console.Clear();
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

/* uses LINQ methods like Min, First, Max, Average, and Count to retrieve the required values from the plants List. 

void ViewAppStats()
{
       Console.Clear();

       if (plants.Count == 0)
       {
              Console.WriteLine("No statistics available as there are no plants.");
       }
       else
       {
              decimal lowestPrice = plants.Min(plant => plant.AskingPrice);
              string lowestPricePlantName = plants.First(plant => plant.AskingPrice == lowestPrice).Species;

              int availablePlantsCount = plants.Count(plant => !plant.Sold && plant.AvailableUntil > DateTime.Now);

              int highestLightNeeds = plants.Max(plant => plant.LightNeeds);
              string highestLightNeedsPlantName = plants.First(plant => plant.LightNeeds == highestLightNeeds).Species;

              double averageLightNeeds = plants.Average(plant => plant.LightNeeds);

              double percentageAdopted = (double)plants.Count(plant => plant.Sold) / plants.Count * 100;

              Console.WriteLine("Application Statistics:");
              Console.WriteLine($"Lowest price plant name: {lowestPricePlantName}");
              Console.WriteLine($"Number of Plants Available: {availablePlantsCount}");
              Console.WriteLine($"Name of plant with highest light needs: {highestLightNeedsPlantName}");
              Console.WriteLine($"Average light needs: {averageLightNeeds:F2}");
              Console.WriteLine($"Percentage of plants adopted: {percentageAdopted:F2}%");
       }

       Console.WriteLine("\nPress any key to continue...");
       Console.ReadKey();
       Console.Clear();
} 

*/

void ViewAppStats()
{
    Console.Clear();

    if (plants.Count == 0)
    {
        Console.WriteLine("No statistics available as there are no plants.");
    }
    else
    {
        decimal lowestPrice = decimal.MaxValue;
        string lowestPricePlantName = "";
        int availablePlantsCount = 0;
        int highestLightNeeds = 0;
        string highestLightNeedsPlantName = "";
        int totalLightNeeds = 0;
        int soldPlantsCount = 0;

        foreach (Plant plant in plants)
        {
            if (plant.AskingPrice < lowestPrice)
            {
                lowestPrice = plant.AskingPrice;
                lowestPricePlantName = plant.Species;
            }

            if (!plant.Sold && plant.AvailableUntil > DateTime.Now)
            {
                availablePlantsCount++;
            }

            if (plant.LightNeeds > highestLightNeeds)
            {
                highestLightNeeds = plant.LightNeeds;
                highestLightNeedsPlantName = plant.Species;
            }

            totalLightNeeds += plant.LightNeeds;

            if (plant.Sold)
            {
                soldPlantsCount++;
            }
        }

        double averageLightNeeds = (double)totalLightNeeds / plants.Count;
        double percentageAdopted = (double)soldPlantsCount / plants.Count * 100;

        Console.WriteLine("Application Statistics:");
        Console.WriteLine($"Lowest price plant name: {lowestPricePlantName}");
        Console.WriteLine($"Number of Plants Available: {availablePlantsCount}");
        Console.WriteLine($"Name of plant with highest light needs: {highestLightNeedsPlantName}");
        Console.WriteLine($"Average light needs: {averageLightNeeds:F2}");
        Console.WriteLine($"Percentage of plants adopted: {percentageAdopted:F2}%");
    }

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
    Console.Clear();
}
