/*

child class of Shape: Circle

_radius: double

GetArea(): double
*/

using System;
using System.Collections.Generic;

public class Circle : Shape
{
    private double _radius;

    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}