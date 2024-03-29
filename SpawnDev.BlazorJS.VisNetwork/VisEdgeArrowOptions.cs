using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.VisNetwork
{
    public class VisEdgeArrowOptions
    {
        /// <summary>
        /// When true, an arrowhead on the 'to' side of the edge is drawn, pointing to the 'to' node with default settings. To customize the size of the arrow, supply an object.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Enabled { get; set; }
        /// <summary>
        /// The height of the image arrow. The height of the image file is used if this isn't defined.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? ImageHeight { get; set; }
        /// <summary>
        /// The width of the image arrow. The width of the image file is used if this isn't defined.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? ImageWidth { get; set; }
        /// <summary>
        /// The scale factor allows you to change the size of the arrowhead.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? ScaleFactor { get; set; }
        /// <summary>
        /// The URL for the image arrow type.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Src { get; set; }
        /// <summary>
        /// The type of endpoint. Possible values are: arrow, bar, circle and image. The default is arrow
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Type { get; set; }
    }
}
