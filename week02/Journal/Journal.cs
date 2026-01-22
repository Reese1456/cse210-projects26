using System;
/*
Journal

_entries : List<Entrys>

AddEntry(newEntry : Entry) : void
DisplayAll() : void
SaveToFile(file : string) : void
LoadFromFile(file : string) : void
*/

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (var entry in _entries)
            {
                string date = EscapeCsvField(entry._date);
                string prompt = EscapeCsvField(entry._promptText);
                string text = EscapeCsvField(entry._entryText);
                writer.WriteLine($"{date},{prompt},{text}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile(string file)
    {
        _entries.Clear();
        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(file);
        foreach (var line in lines)
        {
            string[] parts = ParseCsvLine(line);
            if (parts.Length == 3)
            {
                Entry entry = new Entry(parts[0], parts[1], parts[2]);
                _entries.Add(entry);
            }
        }
        Console.WriteLine("Journal loaded successfully.");
    }

    private string EscapeCsvField(string field)
    {
        if (field.Contains(",") || field.Contains("\"") || field.Contains("\n"))
        {
            field = field.Replace("\"", "\"\"");
            field = $"\"{field}\"";
        }
        return field;
    }

    private string[] ParseCsvLine(string line)
    {
        var fields = new List<string>();
        bool inQuotes = false;
        string field = "";

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];
            if (inQuotes)
            {
                if (c == '"')
                {
                    if (i + 1 < line.Length && line[i + 1] == '"')
                    {
                        field += '"';
                        i++;
                    }
                    else
                    {
                        inQuotes = false;
                    }
                }
                else
                {
                    field += c;
                }
            }

            else
            {
                if (c == ',')
                {
                    fields.Add(field);
                    field = "";
                }
                else if (c == '"')
                {
                    inQuotes = true;
                }
                else
                {
                    field += c;
                }
            }
        }

        fields.Add(field);
        return fields.ToArray();
    }
}