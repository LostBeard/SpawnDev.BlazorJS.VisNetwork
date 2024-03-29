using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.VisNetwork
{
    public class NetworkEvent : JSObject
    {
        public NetworkEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public List<string> Edges => JSRef.Get<List<string>>("edges");
        public Event Event => JSRef.Get<Event>("event");
        public T EventAs<T>() => JSRef.Get<T>("event");
        public JSObject Items => JSRef.Get<JSObject>("items");
        public List<string> Nodes => JSRef.Get<List<string>>("nodes");
        public NetworkEventPointer Pointer => JSRef.Get<NetworkEventPointer>("pointer");
    }
}
