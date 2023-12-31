using RelogicLabs.JsonSchema.Message;

namespace RelogicLabs.JsonSchema.Exceptions;

public class DuplicateDefinitionException : CommonException
{
    public DuplicateDefinitionException(string code, string message) : base(code, message) { }
    public DuplicateDefinitionException(string code, string message, Exception? innerException)
        : base(code, message, innerException) { }
    public DuplicateDefinitionException(ErrorDetail detail) : base(detail) { }
    public DuplicateDefinitionException(ErrorDetail detail, Exception? innerException)
        : base(detail, innerException) { }
}