using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.VisNetwork
{
    /// <summary>
    /// Color options for VisEdge
    /// </summary>
    public class VisEdgeColor
    {
        /// <summary>
        /// The color of the edge when it is not selected or hovered over (assuming hover is enabled in the interaction module).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Color { get; set; }
        /// <summary>
        /// The color the edge when it is selected.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Highlight { get; set; }
        /// <summary>
        /// The color the edge when the mouse hovers over it (assuming hover is enabled in the interaction module).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Hover { get; set; }
        /// <summary>
        /// When color, highlight or hover are defined, inherit is set to false!<br />
        /// Supported options are: true, false, 'from','to','both'.<br />
        /// The default value is 'from' which does the same as true: the edge will inherit the color from the border of the node on the 'from' side.<br />
        /// When set to 'to', the border color from the 'to' node will be used.<br />
        /// When set to 'both', the color will fade from the from color to the to color. 'both' is computationally intensive because the gradient is recomputed every redraw.This is required because the angles change when the nodes move.<br />
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Inherit { get; set; }
        /// <summary>
        /// It can be useful to set the opacity of an edge without manually changing all the colors. The opacity option will convert all colors (also when using inherit) to adhere to the supplied opacity. The allowed range of the opacity option is between 0 and 1. This is only done once so the performance impact is not too big.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? Opacity { get; set; }

    }
}
