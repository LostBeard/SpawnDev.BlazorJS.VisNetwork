namespace SpawnDev.BlazorJS.VisNetwork
{
    public interface IVisEdge
    {
        string From { get; set; }
        string? Id { get; set; }
        string To { get; set; }
    }
}