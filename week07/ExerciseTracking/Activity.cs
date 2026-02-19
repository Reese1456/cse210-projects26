using System;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    protected int Minutes => _minutes;

    public abstract double GetDistance();   // in miles
    public abstract double GetSpeed();      // in mph
    public abstract double GetPace();       // min per mile
    public abstract string GetActivityName();

    public string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetActivityName()} ({_minutes} min) - " +
               $"Distance: {GetDistance():F1} miles, " +
               $"Speed: {GetSpeed():F1} mph, " +
               $"Pace: {GetPace():F2} min per mile";
    }
}