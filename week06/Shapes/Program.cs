using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Square("red", 5.0));
        shapes.Add(new Rectangle("blue", 4.0, 6.0));
        shapes.Add(new Circle("green", 3.0));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"The {shape.GetColor()} shape has an area of {shape.GetArea():F2}");
        }
    }
}