namespace SpawnDev.BlazorJS.VisNetwork
{
    public class NetworkZoomEvent
    {
        public string Direction { get; set; } = "";
        public double Scale { get; set; }
        public NetworkPointerPoint Pointer { get; set; }
    }
}
