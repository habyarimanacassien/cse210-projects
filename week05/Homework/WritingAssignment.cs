public class WritingAssignment : Assignment
{
    private string _title;

    // Constructor
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    // Properties (Getters)
    public string Title
    {
        get { return _title; }
    }

    // Methods
    public string GetWritingInformation()
    {
        // Now we can use the property instead of the method
        return $"{_title} by {StudentName}";
    }
}