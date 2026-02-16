/*

child class of Shape: Square

_side: double

GetAread(): double
*/

using System;
using System.Collections.Generic;

public class Square : Shape
{
    private double _side;

    public Square(string color,double side) : base(color)
    {
        _side = side;
    }

    public override double GetArea()
    {
        return _side * _side;
    }
}