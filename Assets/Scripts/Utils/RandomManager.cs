using System;
using System.Threading;

public class RandomManager
{
    public static int GetRandomInt()
    {
        return new Random().Next();
    }

    public static double GetRandomDouble()
    {
        return new Random().NextDouble();
    }
    
    public static double GetRandomDouble(double minimumDouble, double maximumDouble)
    {
        return new Random().NextDouble() * (minimumDouble - maximumDouble) + minimumDouble;
    }
}