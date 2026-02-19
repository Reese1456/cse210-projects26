class ChecklistGoal : Goal
{
    private int _target;
    private int _bonus;
    private int _timesCompleted;

    public ChecklistGoal(string name, string description, int pointValue,
                         int target, int bonus, int timesCompleted = 0)
        : base(name, description, pointValue)
    {
        _target         = target;
        _bonus          = bonus;
        _timesCompleted = timesCompleted;
    }

    public override bool IsComplete => _timesCompleted >= _target;

    public override int RecordEvent()
    {
        if (IsComplete)
        {
            Console.WriteLine("  (Checklist goal already fully completed – no points awarded.)");
            return 0;
        }
        _timesCompleted++;
        int earned = PointValue;
        if (IsComplete)
        {
            earned += _bonus;
            Console.WriteLine($"  GOAL COMPLETE! Bonus of {_bonus} points awarded!");
        }
        return earned;
    }

    public override string StatusLine()
    {
        string box = IsComplete ? "[X]" : "[ ]";
        return $"{box} {Name} – {Description}  (Completed {_timesCompleted}/{_target} times)";
    }

    public override string Serialise()
        => $"Checklist|{Name}|{Description}|{PointValue}|{_target}|{_bonus}|{_timesCompleted}";
}