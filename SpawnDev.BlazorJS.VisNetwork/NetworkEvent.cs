using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.VisNetwork
{
    /// <summary>
    /// A common network event object
    /// </summary>
    public class NetworkEvent : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public NetworkEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Edges related to this event
        /// </summary>
        public List<string> Edges => JSRef!.Get<List<string>>("edges");
        /// <summary>
        /// Event
        /// </summary>
        public Event Event => JSRef!.Get<Event>("event");
        /// <summary>
        /// Return the event property as type T
        /// </summary>
        public T EventAs<T>() => JSRef!.Get<T>("event");
        /// <summary>
        /// Items related to this event
        /// </summary>
        public JSObject Items => JSRef!.Get<JSObject>("items");
        /// <summary>
        /// Nodes related to this event
        /// </summary>
        public List<string> Nodes => JSRef!.Get<List<string>>("nodes");
        /// <summary>
        /// Pointer information for this event
        /// </summary>
        public NetworkEventPointer Pointer => JSRef!.Get<NetworkEventPointer>("pointer");
    }
}
