using Microsoft.AspNetCore.Components;

namespace SpawnDev.BlazorJS.VisNetwork
{
    // https://visjs.org/
    /// <summary>
    /// VisNetwork is a visualization to display networks and networks consisting of nodes and edges. The visualization is easy to use and supports custom shapes, styles, colors, sizes, images, and more. The network visualization works smooth on any modern browser for up to a few thousand nodes and edges. To handle a larger amount of nodes, Network has clustering support. Network uses HTML canvas for rendering.<br />
    /// https://github.com/visjs/vis-network
    /// </summary>
    public partial class VisNetworkView : IDisposable
    {
        [Inject] BlazorJSRuntime JS { get; set; } = default!;
        /// <summary>
        /// Style to be applied to the container
        /// </summary>
        [Parameter] public string Style { get; set; } = "width: 100%; height: 100%;";
        /// <summary>
        /// Called after OnReady and when (re-)rendered (for example: when StateHasChanged() is called on the parent component)<br/>
        /// (Changing this to an EventCallback will cause this component to hang if disposed, and then recreated.)
        /// </summary>
        [Parameter] public Func<VisNetworkView, Task>? UpdateData { get; set; }
        /// <summary>
        /// Called when the control is ready
        /// </summary>
        [Parameter] public EventCallback<VisNetworkView> OnReady { get; set; }
        /// <summary>
        /// Called on click
        /// </summary>
        [Parameter] public EventCallback<NetworkEvent> OnClick { get; set; }
        /// <summary>
        /// Called on double click
        /// </summary>
        [Parameter] public EventCallback<NetworkEvent> OnDoubleClick { get; set; }
        /// <summary>
        /// Called on context click
        /// </summary>
        [Parameter] public EventCallback<NetworkContextEvent> OnContext { get; set; }
        /// <summary>
        /// Called when dragging
        /// </summary>
        [Parameter] public EventCallback<NetworkDragEvent> OnDragging { get; set; }
        /// <summary>
        /// Called when dragging starts
        /// </summary>
        [Parameter] public EventCallback<NetworkDragEvent> OnDragStart { get; set; }
        /// <summary>
        /// Called when dragging ends
        /// </summary>
        [Parameter] public EventCallback<NetworkDragEvent> OnDragEnd { get; set; }
        /// <summary>
        /// Called on node hover
        /// </summary>
        [Parameter] public EventCallback<NetworkFocusEvent> OnHoverNode { get; set; }
        /// <summary>
        /// Called on node blur
        /// </summary>
        [Parameter] public EventCallback<NetworkFocusEvent> OnBlurNode { get; set; }
        /// <summary>
        /// Called on select
        /// </summary>
        [Parameter] public EventCallback<NetworkSelectEvent> OnSelect { get; set; }
        /// <summary>
        /// Called on node select
        /// </summary>
        [Parameter] public EventCallback<NetworkSelectEvent> OnSelectNode { get; set; }
        /// <summary>
        /// Called on node deselect
        /// </summary>
        [Parameter] public EventCallback<NetworkSelectEvent> OnDeselectNode { get; set; }
        /// <summary>
        /// Called on node edge select
        /// </summary>
        [Parameter] public EventCallback<NetworkSelectEvent> OnSelectEdge { get; set; }
        /// <summary>
        /// Called on node edge deselect
        /// </summary>
        [Parameter] public EventCallback<NetworkSelectEvent> OnDeselectEdge { get; set; }
        /// <summary>
        /// Called on zoom
        /// </summary>
        [Parameter] public EventCallback<NetworkZoomEvent> OnZoom { get; set; }
        /// <summary>
        /// Called on popup show
        /// </summary>
        [Parameter] public EventCallback<string> OnShowPopup { get; set; }
        /// <summary>
        /// Called on popup hide
        /// </summary>
        [Parameter] public EventCallback OnHidePopup { get; set; }

        ElementReference _container;
        /// <summary>
        /// NetworkOptions to be used when Network is created
        /// </summary>
        [Parameter] public NetworkOptions? Options { get; set; }
        /// <summary>
        /// Returns the instance of Network
        /// </summary>
        public Network? Network { get; private set; }
        /// <summary>
        /// Contains the network data
        /// </summary>
        public NetworkData? NetworkData { get; private set; }
        /// <summary>
        /// Accesses NetworkData.Nodes
        /// </summary>
        public DataSet<VisNode>? Nodes => NetworkData?.Nodes;
        /// <summary>
        /// Accesses NetworkData.Edges
        /// </summary>
        public DataSet<VisEdge>? Edges => NetworkData?.Edges;
        /// <summary>
        /// Network.fit()
        /// </summary>
        public void Fit() => Network?.Fit();
        /// <summary>
        /// Clear the network data
        /// </summary>
        public void Clear()
        {
            NetworkData?.Nodes?.Clear();
            NetworkData?.Edges?.Clear();
        }

        // https://visjs.org/
        // https://visjs.github.io/vis-network/
        // https://visjs.github.io/vis-network/examples/network/data/dynamicData.html
        // https://visjs.github.io/vis-network/examples/network/nodeStyles/circularImages.html

        /// <inheritdoc/>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await InitAsync();
            }
        }

        /// <inheritdoc/>
        protected override bool ShouldRender()
        {
            // after the initial render, we only need to update the data to redraw the canvas
            if (Network != null)
            {
                _ = Update();
            }
            return false;
        }

        void Network_OnClick(NetworkEvent networkEvent)
        {
            using var domEvent = networkEvent.Event;
            domEvent.PreventDefault();
            _ = OnClick.InvokeAsync(networkEvent);
        }

        void Network_OnDoubleClick(NetworkEvent networkEvent)
        {
            using var domEvent = networkEvent.Event;
            domEvent.PreventDefault();
            _ = OnDoubleClick.InvokeAsync(networkEvent);
        }

        void Network_OnContext(NetworkContextEvent networkEvent)
        {
            using var domEvent = networkEvent.Event;
            domEvent.PreventDefault();
            _ = OnContext.InvokeAsync(networkEvent);
        }

        void Network_OnDragging(NetworkDragEvent networkEvent)
        {
            using var domEvent = networkEvent.Event;
            domEvent.PreventDefault();
            _ = OnDragging.InvokeAsync(networkEvent);
        }
        void Network_OnDragStart(NetworkDragEvent networkEvent)
        {
            using var domEvent = networkEvent.Event;
            domEvent.PreventDefault();
            _ = OnDragStart.InvokeAsync(networkEvent);
        }
        void Network_OnDragEnd(NetworkDragEvent networkEvent)
        {
            using var domEvent = networkEvent.Event;
            domEvent.PreventDefault();
            _ = OnDragEnd.InvokeAsync(networkEvent);
        }

        void Network_OnHoverNode(NetworkFocusEvent networkEvent)
        {
            using var domEvent = networkEvent.Event;
            domEvent.PreventDefault();
            _ = OnHoverNode.InvokeAsync(networkEvent);
        }

        void Network_OnBlurNode(NetworkFocusEvent networkEvent)
        {
            using var domEvent = networkEvent.Event;
            domEvent.PreventDefault();
            _ = OnBlurNode.InvokeAsync(networkEvent);
        }

        void Network_OnSelect(NetworkSelectEvent networkEvent)
        {
            using var domEvent = networkEvent.Event;
            domEvent.PreventDefault();
            _ = OnSelect.InvokeAsync(networkEvent);
        }

        void Network_OnSelectNode(NetworkSelectEvent networkEvent)
        {
            using var domEvent = networkEvent.Event;
            domEvent.PreventDefault();
            _ = OnSelectNode.InvokeAsync(networkEvent);
        }

        void Network_OnDeselectNode(NetworkSelectEvent networkEvent)
        {
            using var domEvent = networkEvent.Event;
            domEvent.PreventDefault();
            _ = OnDeselectNode.InvokeAsync(networkEvent);
        }

        void Network_OnSelectEdge(NetworkSelectEvent networkEvent)
        {
            using var domEvent = networkEvent.Event;
            domEvent.PreventDefault();
            _ = OnSelectEdge.InvokeAsync(networkEvent);
        }

        void Network_OnDeselectEdge(NetworkSelectEvent networkEvent)
        {
            using var domEvent = networkEvent.Event;
            domEvent.PreventDefault();
            _ = OnDeselectEdge.InvokeAsync(networkEvent);
        }

        void Network_OnZoom(NetworkZoomEvent networkEvent)
        {
            _ = OnZoom.InvokeAsync(networkEvent);
        }

        void Network_OnShowPopup(string networkEvent)
        {
            _ = OnShowPopup.InvokeAsync(networkEvent);
        }

        void Network_OnHidePopup()
        {
            _ = OnHidePopup.InvokeAsync();
        }

        async Task InitAsync()
        {
            await JS.LoadScript("_content/SpawnDev.BlazorJS.VisNetwork/vis-network.min.js", "vis"); ;
            NetworkData = new NetworkData();
            NetworkData.Nodes = new DataSet<VisNode>();
            NetworkData.Edges = new DataSet<VisEdge>();
            if (Options == null)
            {
                Options = new NetworkOptions();
                Options.AutoResize = true;
            }
            try
            {
                Network = new Network(_container, NetworkData, Options);
                Network.OnClick += Network_OnClick;
                Network.OnDoubleClick += Network_OnDoubleClick;
                Network.OnContext += Network_OnContext;
                Network.OnDragging += Network_OnDragging;
                Network.OnDragStart += Network_OnDragStart;
                Network.OnDragEnd += Network_OnDragEnd;
                Network.OnHoverNode += Network_OnHoverNode;
                Network.OnBlurNode += Network_OnBlurNode;
                Network.OnSelect += Network_OnSelect;
                Network.OnSelectNode += Network_OnSelectNode;
                Network.OnDeselectNode += Network_OnDeselectNode;
                Network.OnSelectEdge += Network_OnSelectEdge;
                Network.OnDeselectEdge += Network_OnDeselectEdge;
                Network.OnZoom += Network_OnZoom;
                Network.OnShowPopup += Network_OnShowPopup;
                Network.OnHidePopup += Network_OnHidePopup;
#if DEBUG
                JS.Set("_network", Network);
#endif
                Ready = true;
                await OnReady.InvokeAsync(this);
                await Update();
            }
            catch (Exception ex)
            {
                JS.Log($"InitAsync failed: {ex.ToString()}");
            }
        }
        /// <summary>
        /// Releases resources
        /// </summary>
        public void Dispose()
        {
            if (Network != null)
            {
                Network.OnClick -= Network_OnClick;
                Network.OnDoubleClick -= Network_OnDoubleClick;
                Network.OnContext -= Network_OnContext;
                Network.OnDragging -= Network_OnDragging;
                Network.OnDragStart -= Network_OnDragStart;
                Network.OnDragEnd -= Network_OnDragEnd;
                Network.OnHoverNode -= Network_OnHoverNode;
                Network.OnBlurNode -= Network_OnBlurNode;
                Network.OnSelect -= Network_OnSelect;
                Network.OnSelectNode -= Network_OnSelectNode;
                Network.OnDeselectNode -= Network_OnDeselectNode;
                Network.OnSelectEdge -= Network_OnSelectEdge;
                Network.OnDeselectEdge -= Network_OnDeselectEdge;
                Network.OnZoom -= Network_OnZoom;
                Network.OnShowPopup -= Network_OnShowPopup;
                Network.OnHidePopup -= Network_OnHidePopup;
            }
            NetworkData?.Edges?.Dispose();
            NetworkData?.Nodes?.Dispose();
            Network?.Dispose();
        }
        /// <summary>
        /// Returns true when the component has been initialized and is ready
        /// </summary>
        public bool Ready { get; private set; } = false;
        /// <summary>
        /// Returns true when updating
        /// </summary>
        public bool Updating { get; private set; } = false;
        /// <summary>
        /// UpdateData will be called. 
        /// </summary>
        /// <returns></returns>
        public async Task Update()
        {
            if (UpdateData == null) return;
            if (Updating) return;
            Updating = true;
            try
            {
                await UpdateData(this);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UpdateData failed: {ex.ToString()}");
            }
            finally
            {
                Updating = false;
            }
        }
    }
}
