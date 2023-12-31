using RelogicLabs.JsonSchema.Exceptions;
using RelogicLabs.JsonSchema.Message;
using RelogicLabs.JsonSchema.Tree;
using RelogicLabs.JsonSchema.Types;
using static RelogicLabs.JsonSchema.Message.ErrorCode;

namespace RelogicLabs.JsonSchema.Functions;

public sealed partial class CoreFunctions : FunctionBase
{
    public CoreFunctions(RuntimeContext runtime) : base(runtime) { }

    public bool Length(JString target, JInteger length)
    {
        var _length = target.Value.Length;
        if(_length != length) return FailWith(new JsonSchemaException(
                new ErrorDetail(SLEN01, $"Invalid length of string {target}"),
                new ExpectedDetail(Function, $"a string of length {length}"),
                new ActualDetail(target, $"found {_length} which does not match")));
        return true;
    }

    public bool Length(JArray target, JInteger length)
    {
        var _length = target.Elements.Count;
        if(_length != length) return FailWith(new JsonSchemaException(
                new ErrorDetail(ALEN01, $"Invalid length of array {target.GetOutline()}"),
                new ExpectedDetail(Function, $"an array of length {length}"),
                new ActualDetail(target, $"found {_length} which does not match")));
        return true;
    }

    public bool Length(JObject target, JInteger length)
    {
        var _length = target.Properties.Count;
        if(_length != length) return FailWith(new JsonSchemaException(
                new ErrorDetail(OLEN01, $"Invalid size or length of object {target.GetOutline()}"),
                new ExpectedDetail(Function, $"an object of length {length}"),
                new ActualDetail(target, $"found {_length} which does not match")));
        return true;
    }

    public bool Length(JString target, JInteger minimum, JInteger maximum)
    {
        var length = target.Value.Length;
        if(length < minimum)
            return FailWith(new JsonSchemaException(new ErrorDetail(SLEN02,
                    $"String {target.GetOutline()} length is outside of range"),
                new ExpectedDetail(Function, $"length in range [{minimum}, {maximum}]"),
                new ActualDetail(target, $"found {length} that is less than {minimum}")));
        if(length > maximum)
            return FailWith(new JsonSchemaException(new ErrorDetail(SLEN03,
                    $"String {target.GetOutline()} length is outside of range"),
                new ExpectedDetail(Function, $"length in range [{minimum}, {maximum}]"),
                new ActualDetail(target, $"found {length} that is greater than {maximum}")));
        return true;
    }

    public bool Length(JString target, JInteger minimum, JUndefined undefined)
    {
        var length = target.Value.Length;
        if(length < minimum)
            return FailWith(new JsonSchemaException(new ErrorDetail(SLEN04,
                    $"String {target.GetOutline()} length is outside of range"),
                new ExpectedDetail(Function, $"length in range [{minimum}, {undefined}]"),
                new ActualDetail(target, $"found {length} that is less than {minimum}")));
        return true;
    }

    public bool Length(JString target, JUndefined undefined, JInteger maximum)
    {
        var length = target.Value.Length;
        if(length > maximum)
            return FailWith(new JsonSchemaException(new ErrorDetail(SLEN05,
                    $"String {target.GetOutline()} length is outside of range"),
                new ExpectedDetail(Function, $"length in range [{undefined}, {maximum}]"),
                new ActualDetail(target, $"found {length} that is greater than {maximum}")));
        return true;
    }

    public bool Length(JArray target, JInteger minimum, JInteger maximum)
    {
        var length = target.Elements.Count;
        if(length < minimum)
            return FailWith(new JsonSchemaException(new ErrorDetail(ALEN02,
                    $"Array {target.GetOutline()} length is outside of range"),
                new ExpectedDetail(Function, $"length in range [{minimum}, {maximum}]"),
                new ActualDetail(target, $"found {length} that is less than {minimum}")));
        if(length > maximum)
            return FailWith(new JsonSchemaException(new ErrorDetail(ALEN03,
                    $"Array {target.GetOutline()} length is outside of range"),
                new ExpectedDetail(Function, $"length in range [{minimum}, {maximum}]"),
                new ActualDetail(target, $"found {length} that is greater than {maximum}")));
        return true;
    }

    public bool Length(JArray target, JInteger minimum, JUndefined undefined)
    {
        var length = target.Elements.Count;
        if(length < minimum)
            return FailWith(new JsonSchemaException(new ErrorDetail(ALEN04,
                    $"Array {target.GetOutline()} length is outside of range"),
                new ExpectedDetail(Function, $"length in range [{minimum}, {undefined}]"),
                new ActualDetail(target, $"found {length} that is less than {minimum}")));
        return true;
    }

    public bool Length(JArray target, JUndefined undefined, JInteger maximum)
    {
        var length = target.Elements.Count;
        if(length > maximum)
            return FailWith(new JsonSchemaException(new ErrorDetail(ALEN05,
                    $"Array {target.GetOutline()} length is outside of range"),
                new ExpectedDetail(Function, $"length in range [{undefined}, {maximum}]"),
                new ActualDetail(target, $"found {length} that is greater than {maximum}")));
        return true;
    }

    public bool Length(JObject target, JInteger minimum, JInteger maximum)
    {
        var length = target.Properties.Count;
        if(length < minimum)
            return FailWith(new JsonSchemaException(new ErrorDetail(OLEN02,
                    $"Object {target.GetOutline()} size or length is outside of range"),
                new ExpectedDetail(Function, $"length in range [{minimum}, {maximum}]"),
                new ActualDetail(target, $"found {length} that is less than {minimum}")));
        if(length > maximum)
            return FailWith(new JsonSchemaException(new ErrorDetail(OLEN03,
                    $"Object {target.GetOutline()} size or length is outside of range"),
                new ExpectedDetail(Function, $"length in range [{minimum}, {maximum}]"),
                new ActualDetail(target, $"found {length} that is greater than {maximum}")));
        return true;
    }

    public bool Length(JObject target, JInteger minimum, JUndefined undefined)
    {
        var length = target.Properties.Count;
        if(length < minimum)
            return FailWith(new JsonSchemaException(new ErrorDetail(OLEN04,
                    $"Object {target.GetOutline()} size or length is outside of range"),
                new ExpectedDetail(Function, $"length in range [{minimum}, {undefined}]"),
                new ActualDetail(target, $"found {length} that is less than {minimum}")));
        return true;
    }

    public bool Length(JObject target, JUndefined undefined, JInteger maximum)
    {
        var length = target.Properties.Count;
        if(length > maximum)
            return FailWith(new JsonSchemaException(new ErrorDetail(OLEN05,
                    $"Object {target.GetOutline()} size or length is outside of range"),
                new ExpectedDetail(Function, $"length in range [{undefined}, {maximum}]"),
                new ActualDetail(target, $"found {length} that is greater than {maximum}")));
        return true;
    }
}