using Figures.Models;

namespace Figures;

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
