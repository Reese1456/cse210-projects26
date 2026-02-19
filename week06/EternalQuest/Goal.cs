using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// ============================================================
//  BASE CLASS
// ============================================================
abstract class Goal
{
    public string Name        { get; protected set; }
    public string Description { get; protected set; }
    public int    PointValue  { get; protected set; }

    protected Goal(string name, string description, int pointValue)
    {
        Name        = name;
        Description = description;
        PointValue  = pointValue;
    }

    // Returns points earned on record; 0 if nothing (already complete, etc.)
    public abstract int RecordEvent();

    // Whether the goal is finished forever
    public abstract bool IsComplete { get; }

    // One-line status string shown in the goal list
    public abstract string StatusLine();

    // Serialise to a single CSV-style line for save/load
    public abstract string Serialise();
}