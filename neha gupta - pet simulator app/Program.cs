using System;

class Program
{
    static void Main()
    {
        Pet myPet = CreatePet();
        Console.WriteLine($"Welcome to the Pet Care Simulator! Your pet is a {myPet.Type} named {myPet.Name}.");

        while (true)
        {
            DisplayStats(myPet);
            DisplayInstructions();

            string userChoice = Console.ReadLine();
            PerformAction(userChoice, myPet);
            SimulateTimePassage(myPet);
        }
    }

    static Pet CreatePet()
    {
        Console.Write("Enter your pet's name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Choose a pet type (cat, dog, rabbit, bird): ");
        string type = Console.ReadLine().ToLower();

        return new Pet(name, type);
    }

    static void DisplayStats(Pet pet)
    {
        Console.WriteLine("\nPet Status:");
        Console.WriteLine($"Hunger: {pet.Hunger}/10 | Happiness: {pet.Happiness}/10 | Health: {pet.Health}/10");
    }

    static void DisplayInstructions()
    {
        Console.WriteLine("\nChoose an action:");
        Console.WriteLine("1. Feed\n2. Play\n3. Rest\n4. Bath\n5 Quit");
    }

    static void PerformAction(string choice, Pet pet)
    {
        switch (choice.ToLower())
        {
            case "1":
                pet.Feed();
                break;
            case "2":
                pet.Play();
                break;
            case "3":
                pet.Rest();
                break;
            case "4":
                pet.Bath(); 
                break; 
            case "5";
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice. Please choose a valid action.");
                break;
        }
    }

    static void SimulateTimePassage(Pet pet)
    {
        pet.IncreaseHungerOverTime();
        pet.DecreaseHappinessOverTime();
    }
}

class Pet
{
    public string Name { get; }
    public string Type { get; }
    public int Hunger { get; private set; }
    public int Happiness { get; private set; }
    public int Health { get; private set; }

    public Pet(string name, string type)
    {
        Name = name;
        Type = type;
        Hunger = 5;
        Happiness = 7;
        Health = 8;
    }

    public void Feed()
    {
        Hunger = Math.Max(0, Hunger - 2);
        Health = Math.Min(10, Health + 1);
        Happiness = Math.Min(10, Happiness + 1);

        Console.WriteLine($"{Name} has been fed. Hunger decreased, health and happiness increased.");
    }

    public void Play()
    {
        Hunger = Math.Min(10, Hunger + 1);
        Happiness = Math.Min(10, Happiness + 2);
        Health = Math.Max(0, Health - 1);

        Console.WriteLine($"{Name} played. Hunger increased slightly, happiness increased, and health decreased slightly.");
    }

    public void Rest()
    {
        Health = Math.Min(10, Health + 2);
        Happiness = Math.Max(0, Happiness - 1);

        Console.WriteLine($"{Name} rested. Health increased, and happiness decreased slightly.");
    }

    public void IncreaseHungerOverTime()
    {
        Hunger = Math.Min(10, Hunger + 1);
    }

    public void DecreaseHappinessOverTime()
    {
        Happiness = Math.Max(0, Happiness - 1);
    }
}
