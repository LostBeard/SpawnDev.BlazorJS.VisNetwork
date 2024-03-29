using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.VisNetwork
{
    /// <summary>
    /// Network is a visualization to display networks and networks consisting of nodes and edges. The visualization is easy to use and supports custom shapes, styles, colors, sizes, images, and more. The network visualization works smooth on any modern browser for up to a few thousand nodes and edges. To handle a larger amount of nodes, Network has clustering support. Network uses HTML canvas for rendering.<br />
    /// https://visjs.github.io/vis-network/docs/network/<br />
    /// https://visjs.github.io/vis-network/examples/network/events/interactionEvents.html
    /// </summary>
    public class Network : JSObject
    {
        public Network(IJSInProcessObjectReference _ref) : base(_ref){ }
        public Network(ElementReference container, NetworkData data, NetworkOptions options) : base(JS.New("vis.Network", container, data, options)){ }
        public void Fit() => JSRef.CallVoid("fit");
        public string GetNodeAt(NetworkPointerPoint pointer) => JSRef.Call<string>("getNodeAt", pointer);
        public void SelectNodes(IEnumerable<string> nodeIds) => JSRef.CallVoid("selectNodes", nodeIds);
        public HTMLElement Body => JSRef.Get<HTMLElement>("canvas");
        public HTMLCanvasElement Canvas => JSRef.Get<HTMLCanvasElement>("canvas");
        public JSEventCallback<NetworkEvent> OnClick { get => new JSEventCallback<NetworkEvent>(JSRef, "click", "on", "off"); set { } }
        public JSEventCallback<NetworkEvent> OnDoubleClick { get => new JSEventCallback<NetworkEvent>(JSRef, "doubleClick", "on", "off"); set { } }
        public JSEventCallback<NetworkContextEvent> OnContext { get => new JSEventCallback<NetworkContextEvent>(JSRef, "oncontext", "on", "off"); set { } }
        public JSEventCallback<NetworkDragEvent> OnDragging { get => new JSEventCallback<NetworkDragEvent>(JSRef, "dragging", "on", "off"); set { } }
        public JSEventCallback<NetworkDragEvent> OnDragStart { get => new JSEventCallback<NetworkDragEvent>(JSRef, "dragStart", "on", "off"); set { } }
        public JSEventCallback<NetworkDragEvent> OnDragEnd { get => new JSEventCallback<NetworkDragEvent>(JSRef, "dragEnd", "on", "off"); set { } }
        public JSEventCallback<NetworkFocusEvent> OnHoverNode { get => new JSEventCallback<NetworkFocusEvent>(JSRef, "hoverNode", "on", "off"); set { } }
        public JSEventCallback<NetworkFocusEvent> OnBlurNode { get => new JSEventCallback<NetworkFocusEvent>(JSRef, "blurNode", "on", "off"); set { } }
        public JSEventCallback<NetworkSelectEvent> OnSelect { get => new JSEventCallback<NetworkSelectEvent>(JSRef, "select", "on", "off"); set { } }
        public JSEventCallback<NetworkSelectEvent> OnSelectNode { get => new JSEventCallback<NetworkSelectEvent>(JSRef, "selectNode", "on", "off"); set { } }
        public JSEventCallback<NetworkSelectEvent> OnDeselectNode { get => new JSEventCallback<NetworkSelectEvent>(JSRef, "deselectNode", "on", "off"); set { } }
        public JSEventCallback<NetworkSelectEvent> OnSelectEdge { get => new JSEventCallback<NetworkSelectEvent>(JSRef, "selectEdge", "on", "off"); set { } }
        public JSEventCallback<NetworkSelectEvent> OnDeselectEdge { get => new JSEventCallback<NetworkSelectEvent>(JSRef, "deselectEdge", "on", "off"); set { } }
        public JSEventCallback<NetworkZoomEvent> OnZoom { get => new JSEventCallback<NetworkZoomEvent>(JSRef, "zoom", "on", "off"); set { } }
        public JSEventCallback<string> OnShowPopup { get => new JSEventCallback<string>(JSRef, "showPopup", "on", "off"); set { } }
        public JSEventCallback OnHidePopup { get => new JSEventCallback(JSRef, "hidePopup", "on", "off"); set { } }
    }
}
