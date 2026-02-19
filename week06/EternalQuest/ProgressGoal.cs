class ProgressGoal : Goal
{
    private int _targetUnits;
    private int _currentUnits;
    private string _unit;

    public ProgressGoal(string name, string description, int pointsPerUnit,
                        int targetUnits, string unit, int currentUnits = 0)
        : base(name, description, pointsPerUnit)
    {
        _targetUnits  = targetUnits;
        _currentUnits = currentUnits;
        _unit         = unit;
    }

    public override bool IsComplete => _currentUnits >= _targetUnits;

    public override int RecordEvent()
    {
        if (IsComplete)
        {
            Console.WriteLine("  (Progress goal already complete – no points awarded.)");
            return 0;
        }
        Console.Write($"  How many {_unit} did you complete? ");
        if (!int.TryParse(Console.ReadLine(), out int added) || added <= 0)
        {
            Console.WriteLine("  Invalid input – no progress recorded.");
            return 0;
        }
        _currentUnits = Math.Min(_currentUnits + added, _targetUnits);
        int earned = added * PointValue;
        if (IsComplete)
            Console.WriteLine($"  🏆 Progress goal COMPLETE!");
        return earned;
    }

    public override string StatusLine()
    {
        string box = IsComplete ? "[X]" : "[ ]";
        int pct = (int)(100.0 * _currentUnits / _targetUnits);
        return $"{box} {Name} – {Description}  [{_currentUnits}/{_targetUnits} {_unit} – {pct}%]";
    }

    public override string Serialise()
        => $"Progress|{Name}|{Description}|{PointValue}|{_targetUnits}|{_unit}|{_currentUnits}";
}