using NUnit.Framework;
using Figures;
using System;

namespace FiguresTests;

public class TriangleTests
{
    [Test]
    public void MainLine_ValidData_NoExeption()
    {
        var triangle = new Triangle();
        Assert.DoesNotThrow( () => triangle.MainLine = 5 );
    }

    [Test]
    public void MainLine_WrongData_Exeption()
    {
        var triangle = new Triangle();
        Assert.Throws<ArgumentOutOfRangeException>( () => triangle.MainLine = -5 );
    }

    [Test]
    public void CalculateArea_ValidCircle_ValidArea()
    {
        // Arrange
        var triangle = new Triangle();
        triangle.MainLine = 5;
        var validArea = 5 * 5 * Math.Sqrt(3) / 2;

        // Act
        var area = triangle.CalculateArea();

        // Assert
        Assert.IsTrue( area == validArea );
    }

    [Test]
    public void CalculatePerimeter_ValidCircle_ValidPerimeter()
    {
        // Arrange
        var triangle = new Triangle();
        triangle.MainLine = 5;
        var validPerimeter = 5 * 3;

        // Act
        var area = triangle.CalculatePerimeter();

        // Assert
        Assert.IsTrue( area == validPerimeter );
    }
}
