using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.VisNetwork
{
    /// <summary>
    /// Vis.js comes with a flexible DataSet, which can be used to hold and
    /// manipulate unstructured data and listen for changes in the data.The DataSet
    /// is key/value based. Data items can be added, updated and removed from the
    /// DataSet, and one can subscribe to changes in the DataSet. The data in the
    /// DataSet can be filtered and ordered.Data can be normalized when appending it
    /// to the DataSet as well.<br />
    /// https://github.com/visjs/vis-data/blob/master/src/data-set.ts
    /// </summary>
    public class DataSet : JSObject
    {
        public DataSet(IJSInProcessObjectReference _ref) : base(_ref) { }
        public DataSet() : base(JS.New("vis.DataSet")) { }
        public DataSet(List<VisNode> nodes) : base(JS.New("vis.DataSet", nodes)) { }
        public DataSet(List<VisEdge> edges) : base(JS.New("vis.DataSet", edges)) { }
        public List<string> GetIds() => JSRef.Call<List<string>>("getIds");
        public void Clear() => JSRef.CallVoid("clear");
        public List<string> Add(VisEdge edge) => JSRef.Call<List<string>>("add", edge);
        public List<string> Add(List<VisEdge> edges) => JSRef.Call<List<string>>("add", edges);
        public List<string> Add(VisNode node) => JSRef.Call<List<string>>("add", node);
        public List<string> Add(List<VisNode> nodes) => JSRef.Call<List<string>>("add", nodes);
        public List<string> Update(VisEdge edge) => JSRef.Call<List<string>>("update", edge);
        public List<string> Update(List<VisEdge> edges) => JSRef.Call<List<string>>("update", edges);
        public List<string> Update(VisNode node) => JSRef.Call<List<string>>("update", node);
        public List<string> Update(List<VisNode> nodes) => JSRef.Call<List<string>>("update", nodes);
        public List<string> Remove(List<string> ids) => JSRef.Call<List<string>>("remove", ids);
        public List<string> Remove(string id) => JSRef.Call<List<string>>("remove", id);
        public T Get<T>(string id) => JSRef.Call<T>("get", id);
        public int Length => JSRef.Get<int>("length");
    }
    public class DataSet<T> : JSObject
    {
        public DataSet(IJSInProcessObjectReference _ref) : base(_ref) { }
        public DataSet() : base(JS.New("vis.DataSet")) { }
        public DataSet(List<T> items) : base(JS.New("vis.DataSet", items)) { }
        public List<string> GetIds() => JSRef.Call<List<string>>("getIds");
        public void Clear() => JSRef.CallVoid("clear");
        public List<string> Add(T item) => JSRef.Call<List<string>>("add", item);
        public List<string> Add(List<T> items) => JSRef.Call<List<string>>("add", items);
        public List<string> Update(T item) => JSRef.Call<List<string>>("update", item);
        public List<string> Update(List<T> items) => JSRef.Call<List<string>>("update", items);
        public List<string> Remove(List<string> ids) => JSRef.Call<List<string>>("remove", ids);
        public List<string> Remove(string id) => JSRef.Call<List<string>>("remove", id);
        public T Get(string id) => JSRef.Call<T>("get", id);
        public int Length => JSRef.Get<int>("length");
    }
}
