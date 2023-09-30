using RelogicLabs.JsonSchema.Exceptions;
using static RelogicLabs.JsonSchema.Message.ErrorCode;

namespace RelogicLabs.JsonSchema.Tests.Negative;

[TestClass]
public class FunctionTests
{

    [TestMethod]
    public void When_ExternalIncludeNotInheritBaseClass_ExceptionThrown()
    {
        var schema =
            """
            %include: RelogicLabs.JsonSchema.Tests.Negative.ExternalFunctions1,
                    RelogicLabs.JsonSchema.Tests
            %schema: @odd #integer
            """;
        var json = "10";

        //JsonSchema.IsValid(schema, json);
        var exception = Assert.ThrowsException<InvalidIncludeException>(
            () => JsonAssert.IsValid(schema, json));
        Assert.AreEqual(CLAS03, exception.Code);
        Console.WriteLine(exception);
    }

    [TestMethod]
    public void When_ExternalIncludeNotExisting_ExceptionThrown()
    {
        var schema =
            """
            %include: RelogicLabs.JsonSchema.Tests.Negative.NotExisting,
                    RelogicLabs.JsonSchema.Tests
            %schema: @odd #integer
            """;
        var json = "10";

        //JsonSchema.IsValid(schema, json);
        var exception = Assert.ThrowsException<ClassNotFoundException>(
            () => JsonAssert.IsValid(schema, json));
        Assert.AreEqual(CLAS02, exception.Code);
        Console.WriteLine(exception);
    }

    [TestMethod]
    public void When_ExternalIncludeDuplicationOccurred_ExceptionThrown()
    {
        var schema =
            """
            %include: RelogicLabs.JsonSchema.Tests.Positive.ExternalFunctions,
                    RelogicLabs.JsonSchema.Tests
            %include: RelogicLabs.JsonSchema.Tests.Positive.ExternalFunctions,
                    RelogicLabs.JsonSchema.Tests
            %schema: @odd #integer
            """;
        var json = "10";

        //JsonSchema.IsValid(schema, json);
        var exception = Assert.ThrowsException<DuplicateIncludeException>(
            () => JsonAssert.IsValid(schema, json));
        Assert.AreEqual(CLAS01, exception.Code);
        Console.WriteLine(exception);
    }

    [TestMethod]
    public void When_ExternalIncludeInstantiationNotCompleted_ExceptionThrown()
    {
        var schema =
            """
            %include: RelogicLabs.JsonSchema.Tests.Negative.ExternalFunctions5,
                    RelogicLabs.JsonSchema.Tests
            %schema: @odd #integer
            """;
        var json = "10";

        //JsonSchema.IsValid(schema, json);
        var exception = Assert.ThrowsException<ClassInstantiationException>(
            () => JsonAssert.IsValid(schema, json));
        Assert.AreEqual(CLAS05, exception.Code);
        Console.WriteLine(exception);
    }

    [TestMethod]
    public void When_ExternalFunctionWrongReturnType_ExceptionThrown()
    {
        var schema =
            """
            %include: RelogicLabs.JsonSchema.Tests.Negative.ExternalFunctions2,
                    RelogicLabs.JsonSchema.Tests
            %schema: @odd #integer
            """;
        var json = "10";

        //JsonSchema.IsValid(schema, json);
        var exception = Assert.ThrowsException<InvalidFunctionException>(
            () => JsonAssert.IsValid(schema, json));
        Assert.AreEqual(FUNC01, exception.Code);
        Console.WriteLine(exception);
    }

    [TestMethod]
    public void When_ExternalFunctionWrongParameterNumber_ExceptionThrown()
    {
        var schema =
            """
            %include: RelogicLabs.JsonSchema.Tests.Negative.ExternalFunctions3,
                    RelogicLabs.JsonSchema.Tests
            %schema: @odd #integer
            """;
        var json = "10";

        //JsonSchema.IsValid(schema, json);
        var exception = Assert.ThrowsException<InvalidFunctionException>(
            () => JsonAssert.IsValid(schema, json));
        Assert.AreEqual(FUNC02, exception.Code);
        Console.WriteLine(exception);
    }

    [TestMethod]
    public void When_ExternalFunctionNotExists_ExceptionThrown()
    {
        var schema =
            """
            %include: RelogicLabs.JsonSchema.Tests.Negative.ExternalFunctions4,
                    RelogicLabs.JsonSchema.Tests
            %schema: @odd #integer
            """;
        var json = "10";

        //JsonSchema.IsValid(schema, json);
        var exception = Assert.ThrowsException<FunctionNotFoundException>(
            () => JsonAssert.IsValid(schema, json));
        Assert.AreEqual(FUNC05, exception.Code);
        Console.WriteLine(exception);
    }
}