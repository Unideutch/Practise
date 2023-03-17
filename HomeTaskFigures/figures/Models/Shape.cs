namespace Figures.Models;

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

    private static void ValidateMainLine( double value )
    {
        if ( value <= 0 )
        {
            throw new ArgumentOutOfRangeException( nameof( value ) );
        }
    }

    abstract public double CalculateArea();
    abstract public double CalculatePerimeter();
}
