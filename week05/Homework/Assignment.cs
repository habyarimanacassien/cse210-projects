public class Assignment
{
    private string _studentName;
    private string _topic;

    // Constructor
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Properties (Getters)
    public string StudentName
    {
        get { return _studentName; }
    }

    public string Topic
    {
        get { return _topic; }
    }

    // Methods
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}