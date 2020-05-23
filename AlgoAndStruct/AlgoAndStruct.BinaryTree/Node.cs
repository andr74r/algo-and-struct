using System;

namespace AlgoAndStruct.BinaryTree
{
    public class Node<TKey, TValue>
        where TKey : IComparable
    {
        public Node<TKey, TValue> LeftNode { get; set; }

        public Node<TKey, TValue> RightNode { get; set; }

        public TKey Key { get; private set; }

        public TValue Value { get; private set; }

        public Node(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}
