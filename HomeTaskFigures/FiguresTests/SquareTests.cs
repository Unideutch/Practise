using NUnit.Framework;
using Figures;
using System;

namespace FiguresTests;

public class SquareTests
{
    [Test]
    public void MainLine_ValidData_NoExeption()
    {
        var square = new Square();
        Assert.DoesNotThrow( () => square.MainLine = 5 );
    }

    [Test]
    public void MainLine_WrongData_Exeption()
    {
        var square = new Square();
        Assert.Throws<ArgumentOutOfRangeException>( () => square.MainLine = -5 );
    }

    [Test]
    public void CalculateArea_ValidCircle_ValidArea()
    {
        // Arrange
        var square = new Square();
        square.MainLine = 5;
        var validArea = 5 * 5;

        // Act
        var area = square.CalculateArea();

        // Assert
        Assert.IsTrue( area == validArea );
    }

    [Test]
    public void CalculatePerimeter_ValidCircle_ValidPerimeter()
    {
        // Arrange
        var square = new Square();
        square.MainLine = 5;
        var validPerimeter = 5 * 4;

        // Act
        var area = square.CalculatePerimeter();

        // Assert
        Assert.IsTrue( area == validPerimeter );
    }
}
