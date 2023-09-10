using System.Text.RegularExpressions;
using RelogicLabs.JsonSchema.Time;
using RelogicLabs.JsonSchema.Exceptions;
using RelogicLabs.JsonSchema.Message;
using RelogicLabs.JsonSchema.Types;
using RelogicLabs.JsonSchema.Utilities;
using static RelogicLabs.JsonSchema.Message.ErrorCode;

namespace RelogicLabs.JsonSchema.Functions;

public partial class CoreFunctions
{
    public bool Elements(JArray target, params JNode[] items)
    {
        return items.Where(n => !target.Elements.Contains(n))
            .Select(FailWithNode).ForEachTrue();
        
        bool FailWithNode(JNode node)
        {
            return FailWith(new JsonSchemaException(new ErrorDetail(ELEM01,
                    "Value is not an element of array"),
                new ExpectedDetail(Function, $"array with value {node}"),
                new ActualDetail(target, $"not found in {target.ToOutline()}")));
        }
    }

    public bool Keys(JObject target, params JString[] items)
    {
        return items.Where(n => !target.Properties.ContainsKey(n))
            .Select(FailWithNode).ForEachTrue();
        
        bool FailWithNode(JNode node)
        {
            return FailWith(new JsonSchemaException(new ErrorDetail(KEYS01,
                    "Object does not contain the key"),
                new ExpectedDetail(Function, $"object with key {node}"),
                new ActualDetail(target, $"does not contain in {target.ToOutline()}")));
        }
    }
    
    public bool Values(JObject target, params JNode[] items)
    {
        return items.Where(n => !target.Properties.ContainsValue(n))
            .Select(FailWithNode).ForEachTrue();
        
        bool FailWithNode(JNode node)
        {
            return FailWith(new JsonSchemaException(new ErrorDetail(VALU01,
                    $"Object does not contain the value"),
                new ExpectedDetail(Function, $"object with value {node}"),
                new ActualDetail(target, $"does not contain in {target.ToOutline()}")));
        }
    }

    public bool Regex(JString target, JString pattern)
    {
        var regex = new Regex(((string) pattern).ToString("^", "$"));
        bool result = regex.IsMatch(target);
        if(!result) return FailWith(new JsonSchemaException(new ErrorDetail(REGX01,
                $"Regex pattern does not match"),
            new ExpectedDetail(Function, $"string of pattern {pattern}"),
            new ActualDetail(target, $"found {target.ToOutline()} that mismatches with pattern")));
        return true;
    }

    public bool Email(JString target)
    {
        var result = EmailRegex().IsMatch(target);
        if(!result) return FailWith(new JsonSchemaException(new ErrorDetail(EMAL01,
            "Invalid email address"),
            new ExpectedDetail(Function, "a valid email address"),
            new ActualDetail(target, $"found {target} that is invalid")));
        return true;
    }

    public bool Url(JString target)
    {
        // Handle Uri based on RFC 3986
        bool result = Uri.TryCreate(target, UriKind.Absolute, out Uri? uriResult);
        if(!result || uriResult == null) return FailWith(new JsonSchemaException(
            new ErrorDetail(URLA01, $"Invalid url address"),
            new ExpectedDetail(Function, "a valid url address"),
            new ActualDetail(target, $"found {target} that is invalid")));
        result &= uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps;
        if(!result) return FailWith(new JsonSchemaException(
            new ErrorDetail(URLA02, $"Invalid url address scheme"),
            new ExpectedDetail(Function, "HTTP or HTTPS scheme"),
            new ActualDetail(target, $"found {uriResult.Scheme.DoubleQuote()} from {
                target} that has invalid scheme")));
        return true;
    }
    
    public bool Url(JString target, JString scheme)
    {
        bool result = Uri.TryCreate(target, UriKind.Absolute, out Uri? uriResult);
        if(!result || uriResult == null) return FailWith(
            new JsonSchemaException(new ErrorDetail(URLA03, $"Invalid url address"),
            new ExpectedDetail(Function, "a valid url address"),
            new ActualDetail(target, $"found {target} that is invalid")));
        result &= uriResult.Scheme.Equals(scheme);
        if(!result) return FailWith(new JsonSchemaException(
            new ErrorDetail(URLA04, "Mismatch url address scheme"),
            new ExpectedDetail(Function, $"scheme {scheme} for url address"),
            new ActualDetail(target, $"found {uriResult.Scheme.DoubleQuote()} from {
                target} that does not matched")));
        return true;
    }

    public bool Phone(JString target)
    {
        // Based on ITU-T E.163 and E.164 (extended)
        Regex phone = new Regex(@"^\+?[0-9\s-()]+$");
        bool result = phone.IsMatch(target);
        if(!result) return FailWith(new JsonSchemaException(
            new ErrorDetail(PHON01, "Invalid phone number format"),
            new ExpectedDetail(Function, "a valid phone number"),
            new ActualDetail(target, $"found {target} that is invalid")));
        return true;
    }

    public bool Date(JString target, JString pattern) 
        => DateTime(target, pattern, DateTimeType.DATE_TYPE);

    public bool Time(JString target, JString pattern) 
        => DateTime(target, pattern, DateTimeType.TIME_TYPE);

    private bool DateTime(JString target, JString pattern, DateTimeType type)
    {
        try
        {
            var validator = new DateTimeValidator(pattern);
            if(type == DateTimeType.DATE_TYPE) validator.ValidateDate(target);
            else if(type == DateTimeType.TIME_TYPE) validator.ValidateTime(target);
            else throw new ArgumentException($"Invalid {nameof(DateTimeType)} value");
            return true;
        }
        catch(DateTimeLexerException ex)
        {
            return FailWith(new JsonSchemaException(
                new ErrorDetail(ex.ErrorCode, ex.Message),
                new ExpectedDetail(Function, $"a valid {type} pattern"),
                new ActualDetail(target, $"found {pattern.DoubleQuote()} that is invalid"), 
                ex));
        }
        catch(InvalidDateTimeException ex)
        {
            return FailWith(new JsonSchemaException(
                new ErrorDetail(ex.ErrorCode, ex.Message),
                new ExpectedDetail(Function, $"a valid {type} formatted as {pattern.DoubleQuote()}"),
                new ActualDetail(target, $"found {target.DoubleQuote()} that is invalid or malformatted"), 
                ex));
        }
    }
    
    // Based on SMTP protocol RFC 5322
    [GeneratedRegex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$")]
    private static partial Regex EmailRegex();
}