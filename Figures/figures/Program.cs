using System;

namespace figures;

public interface IShape
{
    public double CalculateArea();
    public double CalculatePerimeter();
}

public abstract class Shape : IShape
{
    private double _mainLine;

    public double MainLine
    {
        get => _mainLine;
        set
        {
            ValidateMainLine( value );
            _mainLine = value;
        }
    }

    private void ValidateMainLine( double value )
    {
        if ( value <= 0 )
        {
            throw new ArgumentOutOfRangeException( "value" );
        }
    }

    abstract public double CalculateArea();
    abstract public double CalculatePerimeter();
}

public class Square : Shape
{
    public override double CalculateArea()
    {
        return MainLine * MainLine;
    }

    public override double CalculatePerimeter()
    {
        return MainLine * 4;
    }
}

public class Triangle : Shape
{

    public override double CalculateArea()
    {
        return (MainLine * MainLine * Math.Sqrt(3)) / 2;
    }

    public override double CalculatePerimeter()
    {
        return MainLine * 3;
    }
}

public class Circle : Shape
{
    public override double CalculateArea()
    {
        return (3.14 * MainLine * MainLine) / 2;
    }

    public override double CalculatePerimeter()
    {
        return 3.14 * MainLine;
    }
}

class Program
{
    static void Main( string[] args )
    {
        Console.WriteLine( "start" );
    }
}