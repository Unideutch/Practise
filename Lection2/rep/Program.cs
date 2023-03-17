namespace Practice;

public class Person
{
    public string FirstName
    { get; set; }

    public string LastName
    { get; set; }

    private int _age;

    public int Age
    {
        get => _age;
        set
        {
            ValidateAge( value );
            _age = value;
        }
    }


    private void ValidateAge( int value )
    {
        if ( value < 0 )
        {
            throw new ArgumentException( nameof( value ) );
        }
    }
}

public class Student : Person
{
    public int StudentId { get; set; }

    public override string ToString()
    {
        return $"Student: name: {FirstName}, last name : {LastName}, id: {StudentId}";
    }
}

class Program
{
    static void Main( string[] args )
    {
        var person = new Person()
        {
            FirstName = "F",
            LastName = "L"
        };

        Console.WriteLine( person.FirstName );
        Console.WriteLine( person.LastName );

        var student = new Student()
        {
            FirstName = "Alex",
            LastName = "Pshkov",
            StudentId = 123
        };
    
    }
}
