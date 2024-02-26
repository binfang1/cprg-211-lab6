namespace Lab6;

class Event
{
    private int _eventNumber;
    private string _location;
    public string Location
    {
        get { return _location; }
        set { _location = value; }
    }
    public int EventNumber
    {
        get { return _eventNumber; }
        set { _eventNumber = value; }
    }

    public Event(int eventNumber, string location)
    {
        this.EventNumber = eventNumber;
        this.Location = location;
    }

    public override string ToString()
    {
        return $"Event Number: {this.EventNumber}\nLocation: {this.Location}";
    }
}