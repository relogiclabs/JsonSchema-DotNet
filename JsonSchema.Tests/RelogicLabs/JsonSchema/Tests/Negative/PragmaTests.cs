using RelogicLabs.JsonSchema.Exceptions;
using static RelogicLabs.JsonSchema.Message.ErrorCode;

namespace RelogicLabs.JsonSchema.Tests.Negative;

[TestClass]
public class PragmaTests
{
    [TestMethod]
    public void When_UnknownPropertyOfObject_ExceptionThrown()
    {
        var schema =
            """
            %pragma IgnoreUnknownProperties: false
            %schema:
            {
                "key1": #integer
            }
            """;
        var json =
            """
            {
                "key1": 10,
                "key2": "value1"
            }
            """;
        
        JsonSchema.IsValid(schema, json);
        var exception = Assert.ThrowsException<JsonSchemaException>(
            () => JsonAssert.IsValid(schema, json));
        Assert.AreEqual(PROP06, exception.ErrorCode);
        Console.WriteLine(exception);
    }
    
    [TestMethod]
    public void When_InvalidUnknownPropertyValueMissing_ExceptionThrown()
    {
        var schema =
            """
            %pragma IgnoreUnknownProperties:
            %schema:
            {
                "key1": #integer
            }
            """;
        var json =
            """
            {
                "key1": 10,
                "key2": "value1"
            }
            """;
        
        //JsonSchema.IsValid(schema, json);
        var exception = Assert.ThrowsException<SchemaParserException>(
            () => JsonAssert.IsValid(schema, json));
        Assert.AreEqual(SPRS01, exception.ErrorCode);
        Console.WriteLine(exception);
    }
    
    [TestMethod]
    public void When_IgnoreUnknownPropertiesInCorrect_ExceptionThrown()
    {
        var schema =
            """
            %pragma IgnoreUnknownProperty: true
            %schema:
            {
                "key1": #integer
            }
            """;
        var json =
            """
            {
                "key1": 10,
                "key2": "value1"
            }
            """;
        
        //JsonSchema.IsValid(schema, json);
        var exception = Assert.ThrowsException<PragmaNotFoundException>(
            () => JsonAssert.IsValid(schema, json));
        Assert.AreEqual(PRAG01, exception.ErrorCode);
        Console.WriteLine(exception);
    }
    
    [TestMethod]
    public void When_InvalidUnknownPropertyValue_ExceptionThrown()
    {
        var schema =
            """
            %pragma IgnoreUnknownProperties: 1
            %schema:
            {
                "key1": #integer
            }
            """;
        var json =
            """
            {
                "key1": 10,
                "key2": "value1"
            }
            """;
        
        //JsonSchema.IsValid(schema, json);
        var exception = Assert.ThrowsException<InvalidPragmaValueException>(
            () => JsonAssert.IsValid(schema, json));
        Assert.AreEqual(PRAG02, exception.ErrorCode);
        Console.WriteLine(exception);
    }
    
    [TestMethod]
    public void When_IgnorePropertyOrderOfObject_ExceptionThrown()
    {
        var schema =
            """
            %pragma IgnoreObjectPropertyOrder: false
            %schema:
            {
                "key1": #integer,
                "key2": #string,
                "key3": #float
            }
            """;
        var json =
            """
            {
                "key1": 10,
                "key3": 2.1,
                "key2": "value1"
            }
            """;
        
        JsonSchema.IsValid(schema, json);
        var exception = Assert.ThrowsException<JsonSchemaException>(
            () => JsonAssert.IsValid(schema, json));
        Assert.AreEqual(PROP07, exception.ErrorCode);
        Console.WriteLine(exception);
    }
    
    [TestMethod]
    public void When_FloatingPointToleranceOfNumber_ExceptionThrown()
    {
        var schema =
            """
            %pragma FloatingPointTolerance: 0.00001
            %schema:
            {
                "key1": 5.00 #float,
                "key2": 10.00E+0 #double
            }
            """;
        var json =
            """
            {
                "key1": 5.00002,
                "key2": 10.0002E+0
            }
            """;
        
        JsonSchema.IsValid(schema, json);
        var exception = Assert.ThrowsException<JsonSchemaException>(
            () => JsonAssert.IsValid(schema, json));
        Assert.AreEqual(FLOT01, exception.ErrorCode);
        Console.WriteLine(exception);
    }
    
    [TestMethod]
    public void When_DuplicatePragmaAssign_ExceptionThrown()
    {
        var schema =
            """
            %pragma IgnoreUnknownProperties: false
            %pragma IgnoreUnknownProperties: false
            
            %schema:
            {
                "key1": #integer
            }
            """;
        var json =
            """
            {
                "key1": 10,
                "key2": "value1"
            }
            """;
        
        //JsonSchema.IsValid(schema, json);
        var exception = Assert.ThrowsException<DuplicatePragmaException>(
            () => JsonAssert.IsValid(schema, json));
        Assert.AreEqual(PRAG03, exception.ErrorCode);
        Console.WriteLine(exception);
    }
}