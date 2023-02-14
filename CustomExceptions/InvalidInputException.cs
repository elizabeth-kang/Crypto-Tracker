namespace CustomExceptions;

[System.Serializable]
public class InvalidInputException : System.Exception
{
    public InvalidInputException() { }
    public InvalidInputException(string message) : base(message) { }
    public InvalidInputException(string message, System.Exception inner) : base(message, inner) { }
    protected InvalidInputException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}