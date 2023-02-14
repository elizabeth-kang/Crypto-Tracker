namespace CustomExceptions;

[System.Serializable]
public class NotSupportedException : System.Exception
{
    public NotSupportedException() { }
    public NotSupportedException(string message) : base(message) { }
    public NotSupportedException(string message, System.Exception inner) : base(message, inner) { }
    protected NotSupportedException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}