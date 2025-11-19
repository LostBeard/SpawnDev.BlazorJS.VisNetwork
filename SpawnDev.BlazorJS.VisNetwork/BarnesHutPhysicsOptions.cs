using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.VisNetwork
{
    /// <summary>
    /// BarnesHut physics options<br/>
    /// https://visjs.github.io/vis-network/docs/network/physics.html#
    /// </summary>
    public class BarnesHutPhysicsOptions
    {
        /// <summary>
        /// This parameter determines the boundary between consolidated long range forces and individual short range forces. To oversimplify higher values are faster but generate more errors, lower values are slower but with less errors.<br/>
        /// Default: 0.5
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Theta { get; set; }
        /// <summary>
        /// Gravity attracts. We like repulsion. So the value is negative. If you want the repulsion to be stronger, decrease the value (so -10000, -50000).<br/>
        /// Default: -2000
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? GravitationalConstant { get; set; }
        /// <summary>
        /// There is a central gravity attractor to pull the entire network back to the center.<br/>
        /// Default: 0.3
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? CentralGravity { get; set; }
        /// <summary>
        /// The edges are modelled as springs. This springLength here is the rest length of the spring.<br/>
        /// Default: 95
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? SpringLength { get; set; }
        /// <summary>
        /// This is how 'sturdy' the springs are. Higher values mean stronger springs.<br/>
        /// Default: 0.04
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? SpringConstant { get; set; }
        /// <summary>
        /// Accepted range: [0 .. 1]. The damping factor is how much of the velocity from the previous physics simulation iteration carries over to the next iteration.<br/>
        /// Default: 0.09
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Damping { get; set; }
        /// <summary>
        /// Accepted range: [0 .. 1]. When larger than 0, the size of the node is taken into account. The distance will be calculated from the radius of the encompassing circle of the node for both the gravity model. Value 1 is maximum overlap avoidance.<br/>
        /// Default: 0
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? AvoidOverlap { get; set; }
    }
}
