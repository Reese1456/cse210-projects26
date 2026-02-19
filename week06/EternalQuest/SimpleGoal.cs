class SimpleGoal : Goal
{
    private bool _complete;

    public SimpleGoal(string name, string description, int pointValue, bool complete = false)
        : base(name, description, pointValue)
    {
        _complete = complete;
    }

    public override bool IsComplete => _complete;

    public override int RecordEvent()
    {
        if (_complete)
        {
            Console.WriteLine("  (Goal already completed – no points awarded.)");
            return 0;
        }
        _complete = true;
        return PointValue;
    }

    public override string StatusLine()
    {
        string box = _complete ? "[X]" : "[ ]";
        return $"{box} {Name} – {Description}";
    }

    public override string Serialise()
        => $"Simple|{Name}|{Description}|{PointValue}|{_complete}";
}