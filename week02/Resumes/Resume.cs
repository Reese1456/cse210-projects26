using System;

/*
Resume

_name : string
_jobs : List<Job>

Display() : void
*/

public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs: ");

        foreach (Job job in _jobs)
        {
            job.DisplayJobDetails();
        }
    }
}