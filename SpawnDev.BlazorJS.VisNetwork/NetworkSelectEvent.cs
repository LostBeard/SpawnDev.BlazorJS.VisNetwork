using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.VisNetwork
{
    public class NetworkSelectEvent : NetworkEvent
    {
        public NetworkSelectEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public DragEvent DragEvent => JSRef.Get<DragEvent>("event");
    }
}
