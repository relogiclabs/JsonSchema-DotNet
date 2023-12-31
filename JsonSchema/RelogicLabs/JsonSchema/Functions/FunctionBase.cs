using RelogicLabs.JsonSchema.Tree;
using RelogicLabs.JsonSchema.Types;

namespace RelogicLabs.JsonSchema.Functions;

public abstract class FunctionBase
{
    public RuntimeContext Runtime { get; }
    public JFunction Function { get; set; } = null!;

    protected FunctionBase(RuntimeContext runtime) => Runtime = runtime;

    protected bool FailWith(Exception exception)
        => Runtime.Exceptions.FailWith(exception);
}