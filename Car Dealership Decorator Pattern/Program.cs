using System;

namespace CarDealershipDecoratorPattern;
// ============================
// Component Base
// ============================
public interface ICar
{
    string GetDescription();
    double GetCost();
}

// ============================
// Concrete Components
// ============================
public class Sedan : ICar
{
    public string GetDescription()
    {
        return "Sedan";
    }

    public double GetCost()
    {
        return 300000;
    }
}

public class SUV : ICar
{
    public string GetDescription()
    {
        return "SUV";
    }

    public double GetCost()
    {
        return 400000;
    }
}

// ============================
// Decorator Base
// ============================
public abstract class CarDecorator : ICar
{
    protected ICar _car;

    public CarDecorator(ICar car)
    {
        _car = car;
    }

    public virtual string GetDescription()
    {
        return _car.GetDescription();
    }

    public virtual double GetCost()
    {
        return _car.GetCost();
    }
}

// ============================
// Concrete Decorators
// ============================
public class SunroofDecorator : CarDecorator
{
    public SunroofDecorator(ICar car) : base(car) { }

    public override string GetDescription()
    {
        return _car.GetDescription() + " + Sunroof";
    }

    public override double GetCost()
    {
        return _car.GetCost() + 6000;
    }
}

public class LeatherSeatsDecorator : CarDecorator
{
    public LeatherSeatsDecorator(ICar car) : base(car) { }

    public override string GetDescription()
    {
        return _car.GetDescription() + " + Leather Seats";
    }

    public override double GetCost()
    {
        return _car.GetCost() + 15000;
    }
}

public class PremiumSoundDecorator : CarDecorator
{
    public PremiumSoundDecorator(ICar car) : base(car) { }

    public override string GetDescription()
    {
        return _car.GetDescription() + " + Premium Sound System";
    }

    public override double GetCost()
    {
        return _car.GetCost() + 8000;
    }
}

// ============================
// Client
// ============================
class Program
{
    // Constants for displaying feature prices
    const double SunroofCost = 6000;
    const double LeatherSeatsCost = 15000;
    const double PremiumSoundCost = 8000;

    static void Main(string[] args)
    {
        ICar myCar;

        Console.WriteLine("Welcome to the Car Dealership!\n");
        Console.WriteLine("Choose a car type:");
        Console.WriteLine("1. Sedan");
        Console.WriteLine("2. SUV");
        Console.Write("Enter choice (1 or 2): ");
        string? carChoice = Console.ReadLine();

        // Initialize base car (ConcreteComponent)
        if (carChoice == "1")
        {
            myCar = new Sedan();
        }
        else if (carChoice == "2")
        {
            myCar = new SUV();
        }
        else
        {
            Console.WriteLine("Invalid choice. Defaulting to Sedan.");
            myCar = new Sedan();
        }

        Console.WriteLine($"\nYou selected: {myCar.GetDescription()} - Base Price: {myCar.GetCost():C}");

        // Prompt for add-ons (decorators)
        Console.WriteLine("\nAdd features to your car (enter Y/N):");

        Console.Write($"Add Sunroof? {SunroofCost:C} : ");
        string? sunroof = Console.ReadLine();
        if (sunroof == "Y" || sunroof == "y")
        {
            myCar = new SunroofDecorator(myCar);
        }
        Console.WriteLine($"\nCurrent Price: {myCar.GetCost():C}");


        Console.Write($"Add Leather Seats? {LeatherSeatsCost:C} : ");
        string? leather = Console.ReadLine();
        if (leather == "Y" || leather == "y")
        {
            myCar = new LeatherSeatsDecorator(myCar);
        }
        Console.WriteLine($"\nCurrent Price: {myCar.GetCost():C}");

        Console.Write($"Add Premium Sound System? {PremiumSoundCost:C} : ");
        string? sound = Console.ReadLine();
        if (sound == "Y" || sound == "y")
        {
            myCar = new PremiumSoundDecorator(myCar);
        }
        Console.WriteLine($"\nCurrent Price: {myCar.GetCost():C}");
        Console.Clear();

        // Final car summary
        Console.WriteLine("Final Summary");
        Console.WriteLine("==============");
        Console.WriteLine($"\nYour final car: {myCar.GetDescription()}");
        Console.WriteLine($"Total price: {myCar.GetCost():C}");

        Console.WriteLine("\nThank you for your order!");
        Console.ReadLine();
    }
}
