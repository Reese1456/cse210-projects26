using System;

public class Cycling : Activity
{
    private double _speed; // in mph

    public Cycling(DateTime date, int minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    // Distance derived from speed: distance = (speed / 60) * minutes
    public override double GetDistance() => (_speed / 60) * Minutes;

    public override double GetSpeed() => _speed;

    // Pace = 60 / speed
    public override double GetPace() => 60.0 / _speed;

    public override string GetActivityName() => "Cycling";
}