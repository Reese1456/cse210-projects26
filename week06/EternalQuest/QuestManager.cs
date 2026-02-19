class QuestManager
{
    private List<Goal> _goals = new();
    private int        _score;
    private int        _level = 1;

    // ---------- score / level helpers ----------

    private int PointsToNextLevel => _level * 500;

    private void AddScore(int pts)
    {
        if (pts == 0) return;
        _score += pts;
        if (pts > 0)
        {
            Console.WriteLine($"  +{pts} points!  Total: {_score}");
            CheckLevelUp();
        }
        else
        {
            Console.WriteLine($"  Score is now: {_score}");
        }
    }

    private void CheckLevelUp()
    {
        int newLevel = (_score / 500) + 1;
        if (newLevel > _level)
        {
            _level = newLevel;
            Console.WriteLine($"\n  !  LEVEL UP!  You are now Level {_level}!  !\n");
        }
    }

    // ---------- menu ----------

    public void Run()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\n══════════════════════════════════════");
            Console.WriteLine($"  ETERNAL QUEST   Score: {_score}   Level: {_level}");
            Console.WriteLine($"  Next level in: {Math.Max(0, _level * 500 - _score)} pts");
            Console.WriteLine("══════════════════════════════════════");
            Console.WriteLine("  1. Show goals");
            Console.WriteLine("  2. Create new goal");
            Console.WriteLine("  3. Record an event");
            Console.WriteLine("  4. Save goals");
            Console.WriteLine("  5. Load goals");
            Console.WriteLine("  6. Quit");
            Console.Write("Choose: ");

            switch (Console.ReadLine()?.Trim())
            {
                case "1": ShowGoals();    break;
                case "2": CreateGoal();   break;
                case "3": RecordEvent();  break;
                case "4": SaveGoals();    break;
                case "5": LoadGoals();    break;
                case "6": running = false; break;
                default:  Console.WriteLine("  Invalid choice."); break;
            }
        }
        Console.WriteLine("  Thanks for questing! Goodbye!");
    }

    // ---------- show ----------

    private void ShowGoals()
    {
        if (_goals.Count == 0) { Console.WriteLine("  No goals yet!"); return; }
        Console.WriteLine();
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"  {i + 1}. {_goals[i].StatusLine()}");
    }

    // ---------- create ----------

    private void CreateGoal()
    {
        Console.WriteLine("\n  Goal types:");
        Console.WriteLine("    1. Simple      (complete once)");
        Console.WriteLine("    2. Eternal     (never ends)");
        Console.WriteLine("    3. Checklist   (complete N times)");
        Console.WriteLine("    4. Negative    (lose points for bad habits)");
        Console.WriteLine("    5. Progress    (work toward a big goal)");
        Console.Write("  Choose type: ");
        string type = Console.ReadLine()?.Trim() ?? "";

        Console.Write("  Name: ");
        string name = Console.ReadLine() ?? "Goal";

        Console.Write("  Description: ");
        string desc = Console.ReadLine() ?? "";

        Console.Write("  Points per event: ");
        int.TryParse(Console.ReadLine(), out int pts);

        Goal g = null;
        switch (type)
        {
            case "1":
                g = new SimpleGoal(name, desc, pts);
                break;

            case "2":
                g = new EternalGoal(name, desc, pts);
                break;

            case "3":
                Console.Write("  How many times must it be completed? ");
                int.TryParse(Console.ReadLine(), out int target);
                Console.Write("  Bonus points on completion: ");
                int.TryParse(Console.ReadLine(), out int bonus);
                g = new ChecklistGoal(name, desc, pts, target, bonus);
                break;

            case "4":
                g = new NegativeGoal(name, desc, pts);
                break;

            case "5":
                Console.Write("  Target units (e.g. 26 for a marathon): ");
                int.TryParse(Console.ReadLine(), out int tUnits);
                Console.Write("  Unit label (e.g. miles): ");
                string unit = Console.ReadLine() ?? "units";
                g = new ProgressGoal(name, desc, pts, tUnits, unit);
                break;

            default:
                Console.WriteLine("  Unknown type – goal not created.");
                return;
        }

        _goals.Add(g);
        Console.WriteLine($"  Goal '{name}' created!");
    }

    // ---------- record ----------

    private void RecordEvent()
    {
        ShowGoals();
        if (_goals.Count == 0) return;
        Console.Write("  Choose goal number: ");
        if (!int.TryParse(Console.ReadLine(), out int idx) || idx < 1 || idx > _goals.Count)
        {
            Console.WriteLine("  Invalid choice.");
            return;
        }
        Goal g = _goals[idx - 1];
        int earned = g.RecordEvent();
        AddScore(earned);
    }

    // ---------- save ----------

    private void SaveGoals()
    {
        Console.Write("  Filename (default: quest.txt): ");
        string file = Console.ReadLine()?.Trim() ?? "";
        if (string.IsNullOrEmpty(file)) file = "quest.txt";

        using var sw = new StreamWriter(file);
        sw.WriteLine(_score);
        sw.WriteLine(_level);
        foreach (var g in _goals)
            sw.WriteLine(g.Serialise());

        Console.WriteLine($"  Saved {_goals.Count} goal(s) to '{file}'.");
    }

    // ---------- load ----------

    private void LoadGoals()
    {
        Console.Write("  Filename (default: quest.txt): ");
        string file = Console.ReadLine()?.Trim() ?? "";
        if (string.IsNullOrEmpty(file)) file = "quest.txt";

        if (!File.Exists(file)) { Console.WriteLine("  File not found."); return; }

        var lines = File.ReadAllLines(file);
        if (lines.Length < 2) { Console.WriteLine("  File is corrupt."); return; }

        _score = int.Parse(lines[0]);
        _level = int.Parse(lines[1]);
        _goals.Clear();

        for (int i = 2; i < lines.Length; i++)
        {
            var p = lines[i].Split('|');
            Goal g = p[0] switch
            {
                "Simple"    => new SimpleGoal(p[1], p[2], int.Parse(p[3]), bool.Parse(p[4])),
                "Eternal"   => new EternalGoal(p[1], p[2], int.Parse(p[3]), int.Parse(p[4])),
                "Checklist" => new ChecklistGoal(p[1], p[2], int.Parse(p[3]),
                                   int.Parse(p[4]), int.Parse(p[5]), int.Parse(p[6])),
                "Negative"  => new NegativeGoal(p[1], p[2], int.Parse(p[3]), int.Parse(p[4])),
                "Progress"  => new ProgressGoal(p[1], p[2], int.Parse(p[3]),
                                   int.Parse(p[4]), p[5], int.Parse(p[6])),
                _           => null
            };
            if (g != null) _goals.Add(g);
        }

        Console.WriteLine($"  Loaded {_goals.Count} goal(s). Score: {_score}  Level: {_level}");
    }
}