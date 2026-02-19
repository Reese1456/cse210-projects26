class NegativeGoal : Goal
{
    private int _timesRecorded;

    public NegativeGoal(string name, string description, int pointValue, int timesRecorded = 0)
        : base(name, description, pointValue)
    {
        _timesRecorded = timesRecorded;
    }

    public override bool IsComplete => false;

    public override int RecordEvent()
    {
        _timesRecorded++;
        Console.WriteLine($"  😬 Oops! You lost {PointValue} points for: {Name}");
        return -PointValue;   // negative!
    }

    public override string StatusLine()
        => $"[–] {Name} – {Description}  (slipped {_timesRecorded}×, -{PointValue} pts each)";

    public override string Serialise()
        => $"Negative|{Name}|{Description}|{PointValue}|{_timesRecorded}";
}