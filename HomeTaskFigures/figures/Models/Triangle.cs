using Figures.Models;

namespace Figures;

public class Triangle : Shape
{
    public override double CalculateArea()
    {
        return MainLine * MainLine * Math.Sqrt( 3 ) / 2;
    }

    public override double CalculatePerimeter()
    {
        return MainLine * 3;
    }
}
