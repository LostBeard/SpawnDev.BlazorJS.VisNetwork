using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.VisNetwork
{
    public class VisFont
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Background { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Color { get; set; }
    }
}
