using System;

class Program
{
    static void Main()
    {
        Pet myPet = CreatePet(); //pet created for the game app
        Console.WriteLine($"Welcome to the Pet Care Simulator! Your pet is a {myPet.Type} named {myPet.Name}.");

        while (true) //user's choice for selecting the type of project
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
        Console.Write("Enter your pet's name: "); //user enter's the name according to wish
        string name = Console.ReadLine();

        Console.WriteLine("Choose a pet type (cat, dog, rabbit, bird): ");
        string type = Console.ReadLine().ToLower();

        return new Pet(name, type);
    }

    static void DisplayStats(Pet pet)  //status of pet's condition out of maximuma scale 10
    {
        Console.WriteLine("\nPet Status:");
        Console.WriteLine($"Hunger: {pet.Hunger}/10 | Happiness: {pet.Happiness}/10 | Health: {pet.Health}/10");
    }

    static void DisplayInstructions()
    {
        Console.WriteLine("\nChoose an action:");
        Console.WriteLine("1. Feed\n2. Play\n3. Rest\n4. Bath\n5. Quit");
    }

    static void PerformAction(string choice, Pet pet)
    {
        switch (choice.ToLower())       //choose the actions to implemented on pet 
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
            case "5":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice. Please choose a valid action.");
                break;
        }
    }

    static void SimulateTimePassage(Pet pet)  //simulating the time passage
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
    //status of pet will change as per actions as well as scale for the same
    public void Feed()
    {
        Hunger = Math.Max(0, Hunger - 2);
        Health = Math.Min(10, Health + 1);
        Happiness = Math.Min(10, Happiness + 1);

        Console.WriteLine($"{Name} has been fed. Hunger decreased, health and happiness increased.");
        Console.WriteLine($"{Name} is happy and content");  
    }

    public void Play()
    {
        Hunger = Math.Min(10, Hunger + 1);
        Happiness = Math.Min(10, Happiness + 2);
        Health = Math.Max(0, Health - 1);

        Console.WriteLine($"{Name} played. Hunger increased slightly, happiness increased, and health decreased slightly.");
        Console.WriteLine($" \n {Name} got energetic!.");
    }

    public void Rest()
    {
        Health = Math.Min(10, Health + 2);
        Happiness = Math.Max(0, Happiness - 1);

        Console.WriteLine($"{Name} rested. Health increased, and happiness decreased slightly.");
        Console.WriteLine($"\n {Name} got refreshed!.");
    }
    public void Bath()
    {
        Happiness = Math.Max(0, Happiness +2);
        Health = Math.Min(0, Health + 1);


        Console.WriteLine($"{Name} took Bath. Health increased and happiness increased slightly.");
        Console.WriteLine($"{Name} got clean and tidy, I am happy!.");
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
