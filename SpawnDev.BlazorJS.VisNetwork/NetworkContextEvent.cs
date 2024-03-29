using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.VisNetwork
{
    public class NetworkContextEvent : NetworkEvent
    {
        public NetworkContextEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public MouseEvent DragEvent => JSRef.Get<MouseEvent>("event");
    }
}
