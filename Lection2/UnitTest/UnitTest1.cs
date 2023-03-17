using System;
using NUnit.Framework;
using Practice;

namespace UnitTest;

public class StudentTests
{

    [Test]
    public void SetAge_ValidAge_NoExeption()
    {
        //Arrange
        var person = new Student();

        //Act & Assert
        Assert.DoesNotThrow( () => person.Age = 5 );
    }


    [Test]
    public void SetAge_NegativeAge_Exeption()
    {
        //Arrange
        var person = new Student();

        //Act & Assert
        Assert.Throws<ArgumentException>( () => person.Age = -5 );
    }
}