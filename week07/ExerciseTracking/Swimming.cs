using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    // Each lap is 50 meters; convert to miles: laps * 50 / 1000 * 0.62
    public override double GetDistance() => _laps * 50.0 / 1000.0 * 0.62;

    public override double GetSpeed() => (GetDistance() / Minutes) * 60;

    public override double GetPace() => Minutes / GetDistance();

    public override string GetActivityName() => "Swimming";
}