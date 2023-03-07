namespace hello
{
    public static class Program
    {
        public static void Main()
        {
            Person person = new Person("chebupel");
            person.Name = "forto";
            Console.WriteLine( person.Name );
        }
    }
}

