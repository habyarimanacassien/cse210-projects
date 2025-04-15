using System;

public class Circle : Shape
{
    private float _radius;

    public Circle(string color, float radius) : base(color)
    {
        _radius = radius;
    }

    public override float GetArea()
    {
        return (float)(Math.PI * _radius * _radius);
    }
}