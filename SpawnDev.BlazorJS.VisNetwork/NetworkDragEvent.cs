using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.VisNetwork
{
    public class NetworkDragEvent : NetworkEvent
    {
        public NetworkDragEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public DragEvent DragEvent => JSRef.Get<DragEvent>("event");
    }
}
