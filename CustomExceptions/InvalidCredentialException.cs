namespace CustomExceptions;

[System.Serializable]
public class InvalidCredentialException : System.Exception
{
    public InvalidCredentialException() { }
    public InvalidCredentialException(string message) : base(message) { }
    public InvalidCredentialException(string message, System.Exception inner) : base(message, inner) { }
    protected InvalidCredentialException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}