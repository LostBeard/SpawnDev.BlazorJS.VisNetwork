using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.VisNetwork
{
    /// <summary>
    /// vis-network edge options<br />
    /// https://visjs.github.io/vis-network/docs/network/edges.html
    /// </summary>
    public class VisEdge : IVisEdge
    {
        /// <summary>
        /// Arrows options
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VisEdgeArrows? Arrows { get; set; }
        /// <summary>
        /// Title to be displayed in a pop-up when the user hovers over the edge. The title can be an HTML element or a string containing plain text. See HTML in titles example if you want to parse HTML.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Title { get; set; }
        /// <summary>
        /// Edges are between two nodes, one to and one from. This is where you define the from node. You have to supply the corresponding node ID. This naturally only applies to individual edges.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? From { get; set; }
        /// <summary>
        /// Edges are between two nodes, one to and one from. This is where you define the to node. You have to supply the corresponding node ID. This naturally only applies to individual edges.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? To { get; set; }
        /// <summary>
        /// The id of the edge. The id is optional for edges. When not supplied, an UUID will be assigned to the edge. This naturally only applies to individual edges.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Id { get; set; }
        /// <summary>
        /// Edge font
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VisFont? Font { get; set; }
        /// <summary>
        /// The label of the edge. HTML does not work in here because the network uses HTML5 Canvas.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Label { get; set; }
        /// <summary>
        /// When true, the edge will be drawn as a dashed line. You can customize the dashes by supplying an Array. Array formart: Array of numbers, gap length, dash length, gap length, dash length, ... etc. The array is repeated until the distance is filled. When using dashed lines in IE versions older than 11, the line will be drawn straight, not smooth.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Dashes { get; set; }
        /// <summary>
        /// Edge background options
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VisEdgeBackground? Background { get; set; }
        /// <summary>
        /// Edge color options
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VisEdgeColor? Color { get; set; }
        /// <summary>
        /// Optional tag string
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Tag { get; set; }
        /// <summary>
        /// The width of the edge. If value is set, this is not used.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? Width { get; set; }
        /// <summary>
        /// When true, the edge is part of the physics simulation. When false, it will not act as a spring.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Physics { get; set; }
        /// <summary>
        /// The physics simulation gives edges a spring length. This value can override the length of the spring in rest.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? Length { get; set; }
        /// <summary>
        /// When true, the edge is not drawn. It is part still part of the physics simulation however!
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Hidden { get; set; }
    }
}
