using Google.Protobuf;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ModelLibrary.Data;

public class ProtobufJsonConverter : JsonConverter<IMessage>
{
    public override bool CanConvert(Type objectType)
    {
        return typeof(IMessage).IsAssignableFrom(objectType);
    }

    public override IMessage Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var jsonText = doc.RootElement.GetRawText();

        var message = (IMessage)Activator.CreateInstance(typeToConvert);

        var parser = new JsonParser(JsonParser.Settings.Default.WithIgnoreUnknownFields(true));
        return parser.Parse(jsonText, message.Descriptor);
    }

    public override void Write(Utf8JsonWriter writer, IMessage value, JsonSerializerOptions options)
    {
        var json = JsonFormatter.Default.Format(value);
        writer.WriteRawValue(json);
    }
}
