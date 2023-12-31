using RelogicLabs.JsonSchema.Message;

namespace RelogicLabs.JsonSchema.Exceptions;

public class ClassNotFoundException : CommonException
{
    public ClassNotFoundException(string code, string message) : base(code, message) { }
    public ClassNotFoundException(string code, string message, Exception? innerException)
        : base(code, message, innerException) { }
    public ClassNotFoundException(ErrorDetail detail) : base(detail) { }
    public ClassNotFoundException(ErrorDetail detail, Exception? innerException)
        : base(detail, innerException) { }
}