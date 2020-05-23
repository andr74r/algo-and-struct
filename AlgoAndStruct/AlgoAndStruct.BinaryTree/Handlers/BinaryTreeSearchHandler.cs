using AlgoAndStruct.BinaryTree.Extensions;
using System;

namespace AlgoAndStruct.BinaryTree.Handlers
{
    public class BinaryTreeSearchHandler<TKey, TValue>
        where TKey : IComparable
    {
        public BinaryTreeNode<TKey, TValue> Handle(BinaryTreeNode<TKey, TValue> root, TKey key)
        {
            return SearchRecursively(root, key);
        }

        private BinaryTreeNode<TKey, TValue> SearchRecursively(BinaryTreeNode<TKey, TValue> currentNode, TKey key)
        {
            if (currentNode == null)
            {
                return null;
            }

            if (currentNode.Key.LessThan(key))
            {
                return SearchRecursively(currentNode.RightNode, key);
            }
            else if (currentNode.Key.GreaterThan(key))
            {
                return SearchRecursively(currentNode.LeftNode, key);
            }
            else
            {
                return currentNode;
            }
        }
    }
}
