using System;

public class Running : Activity
{
    private double _distance; // in kilometers

    public Running(string date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        // Speed (kph) = (distance / minutes) * 60
        return (GetDistance() / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        // Pace (min per km) = minutes / distance
        return GetMinutes() / GetDistance();
    }
}
