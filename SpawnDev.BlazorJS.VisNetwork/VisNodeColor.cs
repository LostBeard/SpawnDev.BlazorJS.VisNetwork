using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.VisNetwork
{
    public class VisNodeColor
    {

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Background { get; set; } = null;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Border { get; set; } = null;

    }
}
