public class Status
{
    public TicketStatus Value { get; }

    private Status(TicketStatus value)
    {
        Value = value;
    }

    public static Status From(TicketStatus status)
    {
        return new Status(status);
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public override bool Equals(object obj)
    {
        if (obj is Status other)
        {
            return Value == other.Value;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(Status a, Status b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (ReferenceEquals(a, null)) return false;
        if (ReferenceEquals(b, null)) return false;
        return a.Value == b.Value;
    }

    public static bool operator !=(Status a, Status b)
    {
        return !(a == b);
    }
}
