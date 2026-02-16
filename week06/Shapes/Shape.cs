/*
class Shape

_color: string

GetColor(): string
SetColor(string): void

GetArea(): double

*/

using System;
using System.Collections.Generic;

public abstract class Shape
{
    private string _color;

    public Shape(string color)
    {
        _color = color;
    }

    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string color)
    {
        _color = color;
    }

    public abstract double GetArea();
}