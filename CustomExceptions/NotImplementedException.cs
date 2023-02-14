namespace CustomExceptions;

[System.Serializable]
public class NotImplementedException : System.Exception
{
    public NotImplementedException() { }
    public NotImplementedException(string message) : base(message) { }
    public NotImplementedException(string message, System.Exception inner) : base(message, inner) { }
    protected NotImplementedException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}