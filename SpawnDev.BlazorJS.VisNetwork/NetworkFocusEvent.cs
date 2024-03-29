using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.VisNetwork
{
    public class NetworkFocusEvent : NetworkEvent
    {
        public NetworkFocusEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public MouseEvent MouseEvent => JSRef.Get<MouseEvent>("event");
    }
}
