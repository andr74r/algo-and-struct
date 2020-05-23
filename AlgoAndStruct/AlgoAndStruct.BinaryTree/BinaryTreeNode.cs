using System;

namespace AlgoAndStruct.BinaryTree
{
    public class BinaryTreeNode<TKey, TValue>
        where TKey : IComparable
    {
        public BinaryTreeNode<TKey, TValue> LeftNode { get; set; }

        public BinaryTreeNode<TKey, TValue> RightNode { get; set; }

        public TKey Key { get; private set; }

        public TValue Value { get; private set; }

        public BinaryTreeNode(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}
