using System.Collections.Generic;
using System.Linq;

namespace AlgoAndStruct.Graph
{
    public class Graph<TKey, TValue, TWeight>
    {
        private readonly List<GraphNode<TKey, TValue>> _nodes = new List<GraphNode<TKey, TValue>>();
        private readonly List<GraphEdge<TKey, TValue, TWeight>> _edges = new List<GraphEdge<TKey, TValue, TWeight>>();

        public IReadOnlyList<GraphNode<TKey, TValue>> Nodes
        {
            get
            {
                return _nodes.AsReadOnly();
            }
        }

        public IReadOnlyList<GraphEdge<TKey, TValue, TWeight>> Edges
        {
            get
            {
                return _edges.AsReadOnly();
            }
        }

        public TWeight this[TKey key1, TKey key2]
        {
            get
            {
                var node1 = _nodes.SingleOrDefault(x => x.Key.Equals(key1));
                var node2 = _nodes.SingleOrDefault(x => x.Key.Equals(key2));

                if (node1 == null || node2 == null)
                {
                    throw new System.ArgumentException("Nodes do not exist");
                }

                var edge = _edges.SingleOrDefault(x => x.From.Key.Equals(key1) && x.To.Key.Equals(key2));

                return edge != null ? edge.Weight : default;
            }
            set
            {
                if (value.Equals(default(TWeight)))
                {
                    RemoveEdge(key1, key2);

                    return;
                }

                var edge = _edges.SingleOrDefault(x => x.From.Key.Equals(key1) && x.To.Key.Equals(key2));

                if (edge == null)
                {
                    var node1 = _nodes.SingleOrDefault(x => x.Key.Equals(key1));
                    var node2 = _nodes.SingleOrDefault(x => x.Key.Equals(key2));

                    if (node1 == null || node2 == null)
                    {
                        throw new System.ArgumentException("Nodes do not exist");
                    }

                    AddEdge(node1.Key, node2.Key, value);
                }
                else
                {
                    edge.Weight = value;
                }
            }
        }

        public void AddNode(TKey key, TValue value)
        {
            if (_nodes.Any(x => x.Key.Equals(key)))
            {
                throw new System.ArgumentException("Key already exists.");
            }

            _nodes.Add(new GraphNode<TKey, TValue>(key, value));
        }

        public void RemoveNode(TKey key)
        {
            _nodes.RemoveAll(x => x.Key.Equals(key));

            _edges.RemoveAll(x => x.From.Key.Equals(key) || x.To.Key.Equals(key));
        }

        public void AddEdge(TKey from, TKey to, TWeight weight)
        {
            var fromNode = _nodes.SingleOrDefault(x => x.Key.Equals(from));

            var toNode = _nodes.SingleOrDefault(x => x.Key.Equals(to));

            if (fromNode == null || toNode == null)
            {
                throw new System.ArgumentException("Key was not found.");
            }

            if (_edges.Any(x => x.To == toNode && x.From == fromNode))
            {
                throw new System.ArgumentException("Edge already exists");
            }

            _edges.Add(new GraphEdge<TKey, TValue, TWeight>(fromNode, toNode, weight));
        }

        public void RemoveEdge(TKey from, TKey to)
        {
            _edges.RemoveAll(x => x.From.Key.Equals(from) && x.To.Key.Equals(to));
        }
    }
}
