namespace AlgoAndStruct.Graph
{
    public class GraphNode<TKey, TValue>
    {
        public TKey Key { get; private set; }

        public TValue Value { get; set; }

        public GraphNode(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}
