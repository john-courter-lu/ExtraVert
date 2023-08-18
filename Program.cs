
string greeting = @"Welcome to Extra Vert
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
    Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. View All Plants
                        2. View Plant Details
                        3. View Latest Plants");
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
        ViewPlantDetails();
    }
    else if (choice == "3")
    {
        ViewLatestPlants();
    }
}

void ListPlants()
{
       Console.WriteLine("Plants Inventory:");
    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {plants[i].Species}");
    }

};

void  ViewPlantDetails(){
foreach (var plant in plants)
            {
                Console.WriteLine($"Plant: {plant.Species}, Light Needs: {plant.LightNeeds}, Price: {plant.AskingPrice:C}, City: {plant.City}, ZIP: {plant.ZIP}, Sold: {plant.Sold}");
            }
};

void ViewLatestPlants(){};