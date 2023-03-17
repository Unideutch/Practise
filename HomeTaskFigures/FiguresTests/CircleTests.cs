using NUnit.Framework;
using Figures;
using System;

namespace FiguresTests;

public class CircleTests
{
    [Test]
    public void MainLine_ValidData_NoExeption()
    {
        var circle = new Circle();
        Assert.DoesNotThrow( () => circle.MainLine = 5 );
    }

    [Test]
    public void MainLine_WrongData_Exeption()
    {
        var circle = new Circle();
        Assert.Throws<ArgumentOutOfRangeException>( () => circle.MainLine = -5 );
    }

    [Test]
    public void CalculateArea_ValidCircle_ValidArea()
    {
        // Arrange
        var circle = new Circle();
        circle.MainLine = 5;
        var validArea = Math.PI * 5 * 5;

        // Act
        var area = circle.CalculateArea();

        // Assert
        Assert.IsTrue(area == validArea);
    }

    [Test]
    public void CalculatePerimeter_ValidCircle_ValidPerimeter()
    {
        // Arrange
        var circle = new Circle();
        circle.MainLine = 5;
        var validPerimeter = Math.PI * 5 * 2;

        // Act
        var area = circle.CalculatePerimeter();

        // Assert
        Assert.IsTrue( area == validPerimeter );
    }
}
