using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebApi.Models;

public class ErrorResponse
{
    [JsonProperty("error")]
    public string? Error { get; set; }

    [JsonProperty("description")]
    public string? Description { get; set; }

    public string Serialize()
    {
        return JsonConvert.SerializeObject(
            this,
            Formatting.None,
            new Newtonsoft.Json.Converters.StringEnumConverter()
        );
    }
}