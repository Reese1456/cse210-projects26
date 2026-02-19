class EternalGoal : Goal
{
    private int _timesRecorded;

    public EternalGoal(string name, string description, int pointValue, int timesRecorded = 0)
        : base(name, description, pointValue)
    {
        _timesRecorded = timesRecorded;
    }

    public override bool IsComplete => false;   // eternal – never done!

    public override int RecordEvent()
    {
        _timesRecorded++;
        return PointValue;
    }

    public override string StatusLine()
        => $"[*] {Name} – {Description}  (recorded {_timesRecorded}×)";

    public override string Serialise()
        => $"Eternal|{Name}|{Description}|{PointValue}|{_timesRecorded}";
}