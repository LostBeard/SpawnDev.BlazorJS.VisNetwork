using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.VisNetwork
{
    /// <summary>
    /// Network is a visualization to display networks and networks consisting of nodes and edges. The visualization is easy to use and supports custom shapes, styles, colors, sizes, images, and more. The network visualization works smooth on any modern browser for up to a few thousand nodes and edges. To handle a larger amount of nodes, Network has clustering support. Network uses HTML canvas for rendering.<br />
    /// https://visjs.github.io/vis-network/docs/network/<br />
    /// </summary>
    public class Network : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Network(IJSInProcessObjectReference _ref) : base(_ref){ }
        /// <summary>
        /// Creates a new instance of vis.Network
        /// </summary>
        /// <param name="container"></param>
        /// <param name="data"></param>
        /// <param name="options"></param>
        public Network(ElementReference container, NetworkData data, NetworkOptions options) : base(JS.New("vis.Network", container, data, options)){ }
        /// <summary>
        /// Zooms out so all nodes fit on the canvas.
        /// </summary>
        public void Fit() => JSRef!.CallVoid("fit");
        /// <summary>
        /// Returns a nodeId or undefined. The DOM positions are expected to be in pixels from the top left corner of the canvas.
        /// </summary>
        /// <param name="pointer"></param>
        /// <returns></returns>
        public string? GetNodeAt(NetworkPointerPoint pointer) => JSRef!.Call<string?>("getNodeAt", pointer);
        /// <summary>
        /// Selects the nodes corresponding to the id's in the input array. If highlightEdges is true or undefined, the neighbouring edges will also be selected. This method unselects all other objects before selecting its own objects. Does not fire events.
        /// </summary>
        /// <param name="nodeIds"></param>
        public void SelectNodes(IEnumerable<string> nodeIds) => JSRef!.CallVoid("selectNodes", nodeIds);
        /// <summary>
        /// Unselect all objects. Does not fire events.
        /// </summary>
        public void UnselectAll() => JSRef!.CallVoid("unselectAll");
        /// <summary>
        /// Returns the network div
        /// </summary>
        public HTMLElement Body => JSRef!.Get<HTMLElement>("body");
        /// <summary>
        /// Returns the network canvas
        /// </summary>
        public HTMLCanvasElement Canvas => JSRef!.Get<HTMLCanvasElement>("canvas");
        /// <summary>
        /// Fired when the user clicks the mouse or taps on a touchscreen device.
        /// </summary>
        public ActionEvent<NetworkEvent> OnClick { get => new ActionEvent<NetworkEvent>("click", On, Off); set { } }
        /// <summary>
        /// Fired when the user double clicks the mouse or double taps on a touchscreen device. Since a double click is in fact 2 clicks, 2 click events are fired, followed by a double click event. If you do not want to use the click events if a double click event is fired, just check the time between click events before processing them.
        /// </summary>
        public ActionEvent<NetworkEvent> OnDoubleClick { get => new ActionEvent<NetworkEvent>("doubleClick", On, Off); set { } }
        /// <summary>
        /// Fired when the user click on the canvas with the right mouse button. The right mouse button does not select by default. You can use the method getNodeAt to select the node if you want.
        /// </summary>
        public ActionEvent<NetworkContextEvent> OnContext { get => new ActionEvent<NetworkContextEvent>("oncontext", On, Off); set { } }
        /// <summary>
        /// Fired when dragging node(s) or the view.
        /// </summary>
        public ActionEvent<NetworkDragEvent> OnDragging { get => new ActionEvent<NetworkDragEvent>("dragging", On, Off); set { } }
        /// <summary>
        /// Fired when starting a drag.
        /// </summary>
        public ActionEvent<NetworkDragEvent> OnDragStart { get => new ActionEvent<NetworkDragEvent>("dragStart", On, Off); set { } }
        /// <summary>
        /// Fired when the drag has finished.
        /// </summary>
        public ActionEvent<NetworkDragEvent> OnDragEnd { get => new ActionEvent<NetworkDragEvent>("dragEnd", On, Off); set { } }
        /// <summary>
        /// Fired if the option interaction:{hover:true} is enabled and the mouse hovers over a node.
        /// </summary>
        public ActionEvent<NetworkFocusEvent> OnHoverNode { get => new ActionEvent<NetworkFocusEvent>("hoverNode", On, Off); set { } }
        /// <summary>
        /// Fired if the option interaction:{hover:true} is enabled and the mouse moved away from a node it was hovering over before.
        /// </summary>
        public ActionEvent<NetworkFocusEvent> OnBlurNode { get => new ActionEvent<NetworkFocusEvent>("blurNode", On, Off); set { } }
        /// <summary>
        /// Fired when the selection has changed by user action. This means a node or edge has been selected, added to the selection or deselected. All select events are only triggered on click and hold.
        /// </summary>
        public ActionEvent<NetworkSelectEvent> OnSelect { get => new ActionEvent<NetworkSelectEvent>("select", On, Off); set { } }
        /// <summary>
        /// Fired when a node has been selected by the user.
        /// </summary>
        public ActionEvent<NetworkSelectEvent> OnSelectNode { get => new ActionEvent<NetworkSelectEvent>("selectNode", On, Off); set { } }
        /// <summary>
        /// Fired when a node (or nodes) has (or have) been deselected by the user. The previous selection is the list of nodes and edges that were selected before the last user event. Passes an object with properties structured as
        /// </summary>
        public ActionEvent<NetworkSelectEvent> OnDeselectNode { get => new ActionEvent<NetworkSelectEvent>("deselectNode", On, Off); set { } }
        /// <summary>
        /// Fired when an edge has been selected by the user.
        /// </summary>
        public ActionEvent<NetworkSelectEvent> OnSelectEdge { get => new ActionEvent<NetworkSelectEvent>("selectEdge", On, Off); set { } }
        /// <summary>
        /// Fired when an edge (or edges) has (or have) been deselected by the user. The previous selection is the list of nodes and edges that were selected before the last user event.
        /// </summary>
        public ActionEvent<NetworkSelectEvent> OnDeselectEdge { get => new ActionEvent<NetworkSelectEvent>("deselectEdge", On, Off); set { } }
        /// <summary>
        /// Fired when the user zooms in or out. The properties tell you which direction the zoom is in. The scale is a number greater than 0, which is the same that you get with network.getScale(). When fired by clicking the zoom in or zoom out navigation buttons, the pointer property of the object passed will be null.
        /// </summary>
        public ActionEvent<NetworkZoomEvent> OnZoom { get => new ActionEvent<NetworkZoomEvent>("zoom", On, Off); set { } }
        /// <summary>
        /// Fired when the popup (tooltip) is shown.
        /// </summary>
        public ActionEvent<string> OnShowPopup { get => new ActionEvent<string>("showPopup", On, Off); set { } }
        /// <summary>
        /// Fired when the popup (tooltip) is hidden.
        /// </summary>
        public ActionEvent OnHidePopup { get => new ActionEvent("hidePopup", On, Off); set { } }
        /// <summary>
        /// Set an event listener. Depending on the type of event you get different parameters for the callback function. Look at the event section of the documentation for more information.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="callback"></param>
        public void On(string eventName, Callback callback) => JSRef!.CallVoid("on", eventName, callback);/// <summary>
        /// Remove an event listener. The function you supply has to be the exact same as the one you used in the on function. If no function is supplied, all listeners will be removed. Look at the event section of the documentation for more information.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="callback"></param>
        public void Off(string eventName, Callback callback) => JSRef!.CallVoid("off", eventName, callback);
        /// <summary>
        /// Set an event listener only once. After it has taken place, the event listener will be removed. Depending on the type of event you get different parameters for the callback function. Look at the event section of the documentation for more information.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="callback"></param>
        public void Once(string eventName, Callback callback) => JSRef!.CallVoid("once", eventName, callback);
    }
}
