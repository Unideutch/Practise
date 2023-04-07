namespace Sample.Domain;

public class Todo
{
    public int Id { get; init; }
    public string Title { get; set; }

    /// <summary>
    /// День, на который заплонирован Todo
    /// </summary>
    public DateTime PlannedDay { get; set; }

    public Todo( int id, string title )
    {
        Id = id;
        Title = title;
        PlannedDay = DateTime.UtcNow;
    }
}

