using Figures.Models;

namespace Figures;

public class Circle : Shape
{
    public override double CalculateArea()
    {
        return Math.PI * MainLine * MainLine;
    }

    public override double CalculatePerimeter()
    {
        return MainLine * 2 * Math.PI;
    }
}
