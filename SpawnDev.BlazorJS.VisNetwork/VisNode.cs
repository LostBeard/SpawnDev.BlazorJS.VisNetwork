using System;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.VisNetwork
{
    /// <summary>
    /// vis-network node options<br />
    /// https://visjs.github.io/vis-network/docs/network/nodes.html
    /// </summary>
    public class VisNode : IVisNode
    {
        /// <summary>
        /// Title to be displayed in a pop-up when the user hovers over the node. The title can be an HTML element or a string containing plain text. See HTML in titles example if you want to parse HTML.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Title { get; set; }
        /// <summary>
        /// The size is used to determine the size of node shapes that do not have the label inside of them. These shapes are: image, circularImage, diamond, dot, star, triangle, triangleDown, hexagon, square and icon
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? Size { get; set; }
        /// <summary>
        /// The width of the border of the node.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? BorderWidth { get; set; }
        /// <summary>
        /// The width of the border of the node when it is selected. When undefined, the borderWidth * 2 is used.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? BorderWidthSelected { get; set; }
        /// <summary>
        /// When the shape is set to image or circularImage, this option can be an URL to a backup image in case the URL supplied in the image option cannot be resolved.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? BrokenImage { get; set; }
        /// <summary>
        /// Overall opacity of a node (overrides any opacity on border, background, image, and shadow)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? Opacity { get; set; }
        /// <summary>
        /// When not undefined, the node will belong to the defined group. Styling information of that group will apply to this node. Node specific styling overrides group styling.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Group { get; set; }
        /// <summary>
        /// When true, the node will not be shown. It will still be part of the physics simulation though!
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Hidden { get; set; }
        /// <summary>
        /// The id of the node. The id is mandatory for nodes and they have to be unique. This should obviously be set per node, not globally.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Id { get; set; }
        /// <summary>
        /// The label is the piece of text shown in or under the node, depending on the shape.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Label { get; set; }
        /// <summary>
        /// When the shape is set to image or circularImage, this option should be the URL to an image. If the image cannot be found, the brokenImage option can be used.<br />
        /// Note: Firefox has a SVG drawing bug, there is a workaround - add width/height attributes to root svg element of the SVG.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Image { get; set; }
        /// <summary>
        /// Label font
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VisFont? Font { get; set; }
        /// <summary>
        /// The shape defines what the node looks like. There are three types of nodes. One type has the label inside of it and the other type has the label underneath it. The third type is a custom shape you can draw whatever you want to represent the node.<br />
        /// The shapes with the label inside of it are: ellipse, circle, database, box, text.<br />
        /// The shapes with the label outside of it are: image, circularImage, diamond, dot, star, triangle, triangleDown, hexagon, square and icon.<br />
        /// If none of these shapes suffice, you can use the custom shape which will allow you to create your own shape rendered via ctxRenderer option.<br />
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Shape { get; set; }
        /// <summary>
        /// Colors for the node
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VisNodeColor? Color { get; set; }
        /// <summary>
        /// Optional tag string
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Tag { get; set; }
        /// <summary>
        /// When false, the node is not part of the physics simulation. It will not move except for from manual dragging.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Physics { get; set; }
        /// <summary>
        /// The barnesHut physics model (which is enabled by default) is based on an inverted gravity model. By increasing the mass of a node, you increase it's repulsion.<br />
        /// Values between 0 and 1 are not recommended. Negative or zero values are not allowed.These will generate a console error and will be set to 1.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? Mass { get; set; }
    }
}
