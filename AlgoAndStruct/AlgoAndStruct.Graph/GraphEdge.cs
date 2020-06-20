namespace AlgoAndStruct.Graph
{
    public class GraphEdge<TKey, TValue, TWeight>
    {
        public GraphNode<TKey, TValue> From { get; private set; }

        public GraphNode<TKey, TValue> To { get; private set; }

        public TWeight Weight { get; set; }

        public GraphEdge(GraphNode<TKey, TValue> from, GraphNode<TKey, TValue> to, TWeight weight)
        {
            if (from == null)
            {
                throw new System.ArgumentNullException("from parameter is null");
            }

            if (to == null)
            {
                throw new System.ArgumentNullException("to parameter is null");
            }

            From = from;
            To = to;
            Weight = weight;
        }
    }
}
