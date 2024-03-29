using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.VisNetwork
{
    /// <summary>
    /// VisEdge arrows options
    /// </summary>
    public class VisEdgeArrows
    {
        /// <summary>
        /// When true, an arrowhead on the 'to' side of the edge is drawn, pointing to the 'to' node with default settings. To customize the size of the arrow, supply an object.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VisEdgeArrowOptions? To { get; set; }
        /// <summary>
        /// Similar to the 'to' object, but with an arrowhead in the center of the edge. The direction of the arrow can be flipped by using a negative value for arrows.middle.scaleFactor.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VisEdgeArrowOptions? Middle { get; set; }
        /// <summary>
        /// Exactly the same as the to object but with an arrowhead at the from node of the edge.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VisEdgeArrowOptions? From { get; set; }
    }
}
