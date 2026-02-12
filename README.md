# SpawnDev.BlazorJS.VisNetwork

[![NuGet](https://img.shields.io/nuget/v/SpawnDev.BlazorJS.VisNetwork.svg)](https://www.nuget.org/packages/SpawnDev.BlazorJS.VisNetwork/)

**SpawnDev.BlazorJS.VisNetwork** is a Blazor WebAssembly wrapper for [vis-network](https://github.com/visjs/vis-network), a powerful JavaScript library for creating interactive network visualizations with nodes and edges.

## Features

- ✅ Full Blazor WebAssembly support for .NET 8, 9, and 10
- ✅ Strongly-typed C# API for vis-network
- ✅ Interactive network graphs with customizable nodes and edges
- ✅ Support for clustering, hierarchical layouts, and physics simulations
- ✅ Event handling for user interactions
- ✅ Comprehensive configuration options
- ✅ Built on [SpawnDev.BlazorJS](https://github.com/LostBeard/SpawnDev.BlazorJS) for seamless JavaScript interop

## Installation

Install the package via NuGet:

```bash
dotnet add package SpawnDev.BlazorJS.VisNetwork
```

Or via the NuGet Package Manager:

```powershell
Install-Package SpawnDev.BlazorJS.VisNetwork
```


## Getting Started

### 1. Register Services

In your `Program.cs`, add the required services:

```csharp
using SpawnDev.BlazorJS;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

// Add BlazorJS services
builder.Services.AddBlazorJSRuntime();

// Initialize BlazorJS by calling BlazorJSRunAsync instead of RunAsync
await builder.Build().BlazorJSRunAsync();
```

### 2. Basic Usage

Create a simple network visualization in your Blazor component:

```razor
@page "/network"
@using SpawnDev.BlazorJS.VisNetwork

<div style="width: 100%; height: 600px;">
    <VisNetworkView OnReady="OnNetworkReady" Style="width: 100%; height: 100%;" />
</div>

@code {
    void OnNetworkReady(VisNetworkView visNetwork)
    {
        visNetwork.Nodes!.Add(new List<VisNode>
        {
            new VisNode { Id = "1", Label = "Node 1" },
            new VisNode { Id = "2", Label = "Node 2" },
            new VisNode { Id = "3", Label = "Node 3" },
            new VisNode { Id = "4", Label = "Node 4" },
            new VisNode { Id = "5", Label = "Node 5" }
        });

        visNetwork.Edges!.Add(new List<VisEdge>
        {
            new VisEdge { From = "1", To = "3" },
            new VisEdge { From = "1", To = "2" },
            new VisEdge { From = "2", To = "4" },
            new VisEdge { From = "2", To = "5" },
            new VisEdge { From = "3", To = "5" }
        });
    }
}
```

## Advanced Examples

### Styled Nodes and Edges

Customize the appearance of nodes and edges:

```csharp
void OnNetworkReady(VisNetworkView visNetwork)
{
    visNetwork.Nodes!.Add(new List<VisNode>
    {
        new VisNode 
        { 
            Id = "1", 
            Label = "Server",
            Shape = "box",
            Color = new VisNodeColor 
            { 
                Background = "#97C2FC", 
                Border = "#2B7CE9" 
            },
            Font = new VisFont { Color = "#000000", Size = 14 }
        },
        new VisNode 
        { 
            Id = "2", 
            Label = "Database",
            Shape = "database",
            Color = new VisNodeColor { Background = "#FFA500" },
            Size = 30
        },
        new VisNode 
        { 
            Id = "3", 
            Label = "Client",
            Shape = "circle",
            Color = new VisNodeColor { Background = "#7BE141" }
        }
    });

    visNetwork.Edges!.Add(new List<VisEdge>
    {
        new VisEdge 
        { 
            From = "1", 
            To = "2",
            Label = "Query",
            Arrows = new VisEdgeArrows { To = new VisEdgeArrowConfig { Enabled = true } },
            Color = new VisEdgeColor { Color = "#848484" },
            Width = 2,
            Dashes = true
        },
        new VisEdge 
        { 
            From = "3", 
            To = "1",
            Label = "Request",
            Arrows = new VisEdgeArrows { To = new VisEdgeArrowConfig { Enabled = true } },
            Smooth = true
        }
    });
}
```

### Hierarchical Layout

Create a hierarchical network layout:

```razor
<VisNetworkView OnReady="OnNetworkReady" Options="@options" Style="width: 100%; height: 100%;" />

@code {
    NetworkOptions options = new NetworkOptions
    {
        Physics = new PhysicsOptions
        {
            Enabled = false
        }
    };

    void OnNetworkReady(VisNetworkView visNetwork)
    {
        // Add nodes in a hierarchical structure
        visNetwork.Nodes!.Add(new List<VisNode>
        {
            new VisNode { Id = "1", Label = "Root", Level = 0 },
            new VisNode { Id = "2", Label = "Child 1", Level = 1 },
            new VisNode { Id = "3", Label = "Child 2", Level = 1 },
            new VisNode { Id = "4", Label = "Grandchild 1", Level = 2 },
            new VisNode { Id = "5", Label = "Grandchild 2", Level = 2 }
        });

        visNetwork.Edges!.Add(new List<VisEdge>
        {
            new VisEdge { From = "1", To = "2" },
            new VisEdge { From = "1", To = "3" },
            new VisEdge { From = "2", To = "4" },
            new VisEdge { From = "3", To = "5" }
        });
    }
}
```

### Event Handling

#### Using VisNetworkView Component Events

Handle user interactions using the `VisNetworkView` component's event parameters:

```razor
<VisNetworkView 
    OnReady="OnNetworkReady" 
    OnClick="OnNetworkClick"
    OnDoubleClick="OnNetworkDoubleClick"
    OnSelectNode="OnNodeSelected"
    OnHoverNode="OnNodeHover"
    Style="width: 100%; height: 100%;" />

@code {
    void OnNetworkReady(VisNetworkView visNetwork)
    {
        // Add your nodes and edges
    }

    void OnNetworkClick(NetworkEvent e)
    {
        Console.WriteLine($"Clicked at position: {e.Pointer.Canvas.X}, {e.Pointer.Canvas.Y}");
        if (e.Nodes.Length > 0)
        {
            Console.WriteLine($"Clicked node: {e.Nodes[0]}");
        }
    }

    void OnNetworkDoubleClick(NetworkEvent e)
    {
        Console.WriteLine($"Double-clicked");
    }

    void OnNodeSelected(NetworkSelectEvent e)
    {
        Console.WriteLine($"Selected nodes: {string.Join(", ", e.Nodes)}");
    }

    void OnNodeHover(NetworkFocusEvent e)
    {
        Console.WriteLine($"Hovering over node: {e.Node}");
    }
}
```

#### Using Network ActionEvent Properties (Preferred for Direct Network Access)

When working with the `Network` object directly, use the strongly-typed `ActionEvent` properties with `+=` and `-=` operators:

```razor
<VisNetworkView OnReady="OnNetworkReady" Style="width: 100%; height: 100%;" />

@code {
    Network? network;

    void OnNetworkReady(VisNetworkView visNetwork)
    {
        network = visNetwork.Network;

        // Attach event handlers using ActionEvent properties
        network.OnClick += HandleClick;
        network.OnDoubleClick += HandleDoubleClick;
        network.OnSelectNode += HandleNodeSelect;
        network.OnHoverNode += HandleNodeHover;
        network.OnZoom += HandleZoom;

        // Add your nodes and edges
    }

    void HandleClick(NetworkEvent e)
    {
        Console.WriteLine($"Clicked at position: {e.Pointer.Canvas.X}, {e.Pointer.Canvas.Y}");
        if (e.Nodes.Length > 0)
        {
            Console.WriteLine($"Clicked node: {e.Nodes[0]}");
        }
    }

    void HandleDoubleClick(NetworkEvent e)
    {
        Console.WriteLine($"Double-clicked");
    }

    void HandleNodeSelect(NetworkSelectEvent e)
    {
        Console.WriteLine($"Selected nodes: {string.Join(", ", e.Nodes)}");
    }

    void HandleNodeHover(NetworkFocusEvent e)
    {
        Console.WriteLine($"Hovering over node: {e.Node}");
    }

    void HandleZoom(NetworkZoomEvent e)
    {
        Console.WriteLine($"Zoom scale: {e.Scale}, Direction: {e.Direction}");
    }

    public void Dispose()
    {
        if (network != null)
        {
            // Detach event handlers to prevent memory leaks
            network.OnClick -= HandleClick;
            network.OnDoubleClick -= HandleDoubleClick;
            network.OnSelectNode -= HandleNodeSelect;
            network.OnHoverNode -= HandleNodeHover;
            network.OnZoom -= HandleZoom;
            network.Dispose();
        }
    }
}
```

**Important:** Always use the `ActionEvent` properties (e.g., `OnClick`, `OnDoubleClick`) with `+=` and `-=` operators instead of string-based event methods like `On("click", callback)` or `Once("click", callback)`. The `ActionEvent` pattern provides strong typing, automatic reference management, and cleaner syntax.

### Dynamic Data Updates

Add, update, and remove nodes and edges dynamically:

```razor
<button @onclick="AddNode">Add Node</button>
<button @onclick="UpdateNode">Update Node</button>
<button @onclick="RemoveNode">Remove Node</button>
<button @onclick="AddEdge">Add Edge</button>

<VisNetworkView OnReady="OnNetworkReady" Style="width: 100%; height: 400px;" />

@code {
    VisNetworkView? networkView;
    int nodeCounter = 6;

    void OnNetworkReady(VisNetworkView visNetwork)
    {
        networkView = visNetwork;

        visNetwork.Nodes!.Add(new List<VisNode>
        {
            new VisNode { Id = "1", Label = "Node 1" },
            new VisNode { Id = "2", Label = "Node 2" },
            new VisNode { Id = "3", Label = "Node 3" }
        });

        visNetwork.Edges!.Add(new List<VisEdge>
        {
            new VisEdge { From = "1", To = "2" },
            new VisEdge { From = "2", To = "3" }
        });
    }

    void AddNode()
    {
        var newId = nodeCounter++.ToString();
        networkView?.Nodes?.Add(new VisNode 
        { 
            Id = newId, 
            Label = $"Node {newId}",
            X = 0,
            Y = 0
        });
    }

    void UpdateNode()
    {
        networkView?.Nodes?.Update(new VisNode 
        { 
            Id = "1",
            Label = "Updated Node",
            Color = new VisNodeColor { Background = "#FF0000" }
        });
    }

    void RemoveNode()
    {
        networkView?.Nodes?.Remove("3");
    }

    void AddEdge()
    {
        networkView?.Edges?.Add(new VisEdge 
        { 
            From = "1",
            To = "3"
        });
    }
}
```

### Clustering

Group nodes together using clustering:

```csharp
void OnNetworkReady(VisNetworkView visNetwork)
{
    // Add nodes with groups
    visNetwork.Nodes!.Add(new List<VisNode>
    {
        new VisNode { Id = "1", Label = "Server 1", Group = "servers" },
        new VisNode { Id = "2", Label = "Server 2", Group = "servers" },
        new VisNode { Id = "3", Label = "Server 3", Group = "servers" },
        new VisNode { Id = "4", Label = "Client 1", Group = "clients" },
        new VisNode { Id = "5", Label = "Client 2", Group = "clients" }
    });

    visNetwork.Edges!.Add(new List<VisEdge>
    {
        new VisEdge { From = "4", To = "1" },
        new VisEdge { From = "5", To = "2" },
        new VisEdge { From = "1", To = "2" },
        new VisEdge { From = "2", To = "3" }
    });

    // Cluster nodes by group
    // Note: Use Network API directly for advanced clustering
    // visNetwork.Network?.Cluster(clusterOptions);
}
```

### Physics Simulation

Control the physics simulation:

```razor
<button @onclick="TogglePhysics">Toggle Physics</button>
<button @onclick="Stabilize">Stabilize</button>

<VisNetworkView OnReady="OnNetworkReady" Options="@options" Style="width: 100%; height: 400px;" />

@code {
    VisNetworkView? networkView;
    bool physicsEnabled = true;

    NetworkOptions options = new NetworkOptions
    {
        Physics = new PhysicsOptions
        {
            Enabled = true,
            BarnesHut = new BarnesHutPhysicsOptions
            {
                GravitationalConstant = -2000,
                CentralGravity = 0.3,
                SpringLength = 95,
                SpringConstant = 0.04,
                Damping = 0.09,
                AvoidOverlap = 0.1
            },
            MaxVelocity = 50,
            MinVelocity = 0.1,
            Solver = "barnesHut",
            TimeStep = 0.5
        }
    };

    void OnNetworkReady(VisNetworkView visNetwork)
    {
        networkView = visNetwork;
        // Add your nodes and edges
    }

    void TogglePhysics()
    {
        physicsEnabled = !physicsEnabled;
        networkView?.Network?.SetOptions(new NetworkOptions 
        { 
            Physics = new PhysicsOptions { Enabled = physicsEnabled } 
        });
    }

    void Stabilize()
    {
        networkView?.Network?.Stabilize();
    }
}
```

## Network Methods

The `Network` class provides many useful methods:

```csharp
// Selection
var selectedNodes = networkView.Network?.GetSelectedNodes();
var selectedEdges = networkView.Network?.GetSelectedEdges();
networkView.Network?.SelectNodes(new[] { "1", "2", "3" });
networkView.Network?.UnselectAll();

// View control
networkView.Network?.Fit(); // Zoom to fit all nodes
networkView.Network?.Focus("nodeId", new FocusOptions { Scale = 1.5, Animation = true });
networkView.Network?.MoveTo(new MoveToOptions 
{ 
    Position = new Position { X = 0, Y = 0 },
    Scale = 1.0,
    Animation = true
});

// Data access
var nodePositions = networkView.Network?.GetPositions();
var nodePosition = networkView.Network?.GetPosition("nodeId");
var boundingBox = networkView.Network?.GetBoundingBox("nodeId");
var connectedNodes = networkView.Network?.GetConnectedNodes("nodeId");
var connectedEdges = networkView.Network?.GetConnectedEdges("nodeId");

// Physics
networkView.Network?.StartSimulation();
networkView.Network?.StopSimulation();
networkView.Network?.Stabilize();

// Canvas
networkView.Network?.Redraw();
networkView.Network?.SetSize("800px", "600px");
```

## Configuration Options

The library supports extensive configuration through the `NetworkOptions` class:

- **Nodes**: Shape, size, color, font, borders, shadows, and more
- **Edges**: Width, color, arrows, dashes, smooth curves, and labels
- **Layout**: Hierarchical, random, or custom positioning
- **Physics**: Barnes-Hut, force atlas, repulsion, and stabilization
- **Interaction**: Hover, selection, drag, zoom, and keyboard controls
- **Manipulation**: Add, edit, and delete nodes/edges through UI

## Examples Repository

For more examples, check out the [examples project](./Examples) in this repository.

## Documentation

- [vis-network Documentation](https://visjs.github.io/vis-network/docs/network/)
- [SpawnDev.BlazorJS Documentation](https://github.com/LostBeard/SpawnDev.BlazorJS)

## Requirements

- .NET 8, 9, or 10
- Blazor WebAssembly
- SpawnDev.BlazorJS

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Credits

- Built on [vis-network](https://github.com/visjs/vis-network) by the vis.js team
- Powered by [SpawnDev.BlazorJS](https://github.com/LostBeard/SpawnDev.BlazorJS)

## Support

If you encounter any issues or have questions:
- [Open an issue](https://github.com/LostBeard/SpawnDev.BlazorJS.VisNetwork/issues)
- Check the [vis-network documentation](https://visjs.github.io/vis-network/docs/network/)

