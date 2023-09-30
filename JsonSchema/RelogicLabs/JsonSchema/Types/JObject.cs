using RelogicLabs.JsonSchema.Collections;
using RelogicLabs.JsonSchema.Exceptions;
using RelogicLabs.JsonSchema.Message;
using RelogicLabs.JsonSchema.Utilities;
using static RelogicLabs.JsonSchema.Message.ErrorCode;
using static RelogicLabs.JsonSchema.Message.ErrorDetail;

namespace RelogicLabs.JsonSchema.Types;

public class JObject : JComposite
{
    public override IEnumerable<JNode> Children => Properties.Values;
    public required IIndexMap<string, JProperty> Properties { get; init; }

    internal JObject(IDictionary<JNode, JNode> relations) : base(relations) { }

    public override bool Match(JNode node)
    {
        var other = CastType<JObject>(node);
        if(other == null) return false;
        var result = true;
        HashSet<string> unresolved = new(other.Properties.Keys);
        for(var i = 0; i < Properties.Count; i++)
        {
            var thisProp = Properties[i];
            var otherProp = GetOtherProp(other, i);
            if(otherProp != null)
            {
                result &= thisProp.Value.Match(other.Properties[thisProp.Key].Value);
                unresolved.Remove(thisProp.Key);
                continue;
            }
            if(!((JValidator) thisProp.Value).Optional)
                return FailWith(new JsonSchemaException(
                        new ErrorDetail(PROP05, PropertyNotFound),
                        ExpectedDetail.AsPropertyNotFound(thisProp),
                        ActualDetail.AsPropertyNotFound(node, thisProp)));
        }
        if(unresolved.Count > 0 && !Runtime.IgnoreUndefinedProperties)
        {
            foreach(var key in unresolved)
            {
                var property = other.Properties[key];
                result &= FailWith(new JsonSchemaException(
                    new ErrorDetail(PROP06, UndefinedPropertyFound),
                    ExpectedDetail.AsUndefinedProperty(this, property),
                    ActualDetail.AsUndefinedProperty(property)));
            }
        }
        return result;
    }

    private JProperty? GetOtherProp(JObject other, int index)
    {
        var thisProp = Properties[index];
        JProperty? otherProp = null;
        if(!Runtime.IgnoreObjectPropertyOrder)
        {
            var atProp = GetPropAt(other.Properties, index);
            if(AreKeysEqual(atProp, thisProp)) otherProp = atProp;
            JProperty? existing = null;
            if(otherProp == null) other.Properties.TryGetValue(thisProp.Key, out existing);
            if(otherProp == null && existing != null)
                FailWith(new JsonSchemaException(
                    new ErrorDetail(PROP07, PropertyOrderMismatch),
                    ExpectedDetail.AsPropertyOrderMismatch(thisProp),
                    ActualDetail.AsPropertyOrderMismatch(atProp ?? (JNode) other)));
        }
        else other.Properties.TryGetValue(thisProp.Key, out otherProp);
        return otherProp;
    }

    private static bool AreKeysEqual(JProperty? p1, JProperty? p2) {
        if(p1 == null || p2 == null) return false;
        return p1.Key == p2.Key;
    }

    private JProperty? GetPropAt(IIndexMap<string, JProperty> properties, int index)
        => index >= properties.Count ? null : properties[index];

    public override IList<JNode> GetComponents() => Properties.Select(p => p.Value)
        .ToList().AsReadOnly();

    public override bool Equals(object? obj)
    {
        if(ReferenceEquals(null, obj)) return false;
        if(ReferenceEquals(this, obj)) return true;
        if(obj.GetType() != this.GetType()) return false;
        var other = (JObject) obj;
        if(Properties.Count != other.Properties.Count) return false;
        return Runtime.IgnoreObjectPropertyOrder? UnorderedEquals(other.Properties)
            : OrderedEquals(other.Properties);
    }

    private bool UnorderedEquals(IEnumerable<JProperty> properties)
    {
        foreach(var p in properties)
            if(!p.Equals(Properties[p.Key])) return false;
        return true;
    }

    private bool OrderedEquals(IList<JProperty> properties)
    {
        for(int i = 0; i < Properties.Count; i++)
            if(!Properties[i].Equals(properties[i])) return false;
        return true;
    }

    public override JsonType Type => JsonType.OBJECT;
    public override int GetHashCode() => Properties.GetHashCode();
    public override string ToString() => Properties.ToString(", ", "{", "}");
}