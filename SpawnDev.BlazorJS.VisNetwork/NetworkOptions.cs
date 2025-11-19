using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.VisNetwork
{
    public class NetworkData
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DataSet<VisNode>? Nodes { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DataSet<VisEdge>? Edges { get; set; }
    }

    //https://visjs.github.io/vis-network/docs/network/
    public class NetworkOptions
    {
        /// <summary>
        /// If true, the Network will automatically detect when its container is resized, and redraw itself accordingly. If false, the Network can be forced to repaint after its container has been resized using the function redraw() and setSize().
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AutoResize { get; set; }
        /// <summary>
        /// the width of the canvas. Can be in percentages or pixels (ie. '400px').
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Width { get; set; }
        /// <summary>
        /// the height of the canvas. Can be in percentages or pixels (ie. '400px').
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Height { get; set; }
        /// <summary>
        /// Options for nodes
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public NetworkNodeOptions? Nodes { get; set; }
        /// <summary>
        /// Options for edges
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public NetworkEdgeOptions? Edges { get; set; }
        /// <summary>
        /// All options in this object are explained in the physics module.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PhysicsOptions? Physics { get; set; }
    }

    public class NetworkNodeOptions
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? BorderWidth { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Size { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public NodeColorOptions? Color { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public NodeFontOptions? Font { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Shadow { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Shape { get; set; }
    }

    public class NodeColorOptions
    {

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Border { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Background { get; set; }
    }

    public class NodeFontOptions
    {

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Border { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Background { get; set; }
    }

    public class NetworkEdgeOptions
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Color { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Shadow { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Width { get; set; }
    }
}
