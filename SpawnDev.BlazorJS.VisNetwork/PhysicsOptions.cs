using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.VisNetwork
{
    /// <summary>
    /// Handles the physics simulation, moving the nodes and edges to show them clearly.<br/>
    /// https://visjs.github.io/vis-network/docs/network/physics.html
    /// </summary>
    public class PhysicsOptions
    {
        /// <summary>
        /// Toggle the physics system on or off. This property is optional. If you define any of the options below and enabled is undefined, this will be set to true.<br/>
        /// Default: true
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Enabled { get; set; }
        /// <summary>
        /// BarnesHut is a quadtree based gravity model. This is the fastest, default and recommended solver for non-hierarchical layouts
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BarnesHutPhysicsOptions? BarnesHut { get; set; }
        /// <summary>
        /// The physics module limits the maximum velocity of the nodes to increase the time to stabilization. This is the maximum value.<br/>
        /// Default: 50
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? MaxVelocity { get; set; }
        /// <summary>
        /// Once the minimum velocity is reached for all nodes, we assume the network has been stabilized and the simulation stops.<br/>
        /// Default: 0.1
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? MinVelocity { get; set; }
        /// <summary>
        /// You can select your own solver.<br/>
        /// Possible options: 'barnesHut', 'repulsion', 'hierarchicalRepulsion', 'forceAtlas2Based'.<br/>
        /// When setting the hierarchical layout, the hierarchical repulsion solver is automatically selected, regardless of what you fill in here.<br/>
        /// Default: 'barnesHut'
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Solver { get; set; }
        /// <summary>
        /// The physics simulation is discrete. This means we take a step in time, calculate the forces, move the nodes and take another step. If you increase this number the steps will be too large and the network can get unstable. If you see a lot of jittery movement in the network, you may want to reduce this value a little.<br/>
        /// Default: 0.5
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? TimeStep { get; set; }
        /// <summary>
        /// If this is enabled, the timestep will intelligently be adapted (only during the stabilization stage if stabilization is enabled!) to greatly decrease stabilization times. The timestep configured above is taken as the minimum timestep. This can be further improved by using the improvedLayout algorithm.<br/>
        /// Default: true
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AdaptiveTimestep { get; set; }
    }
}
