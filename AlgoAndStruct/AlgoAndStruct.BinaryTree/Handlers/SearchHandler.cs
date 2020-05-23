using AlgoAndStruct.BinaryTree.Extensions;
using System;

namespace AlgoAndStruct.BinaryTree.Handlers
{
    public class SearchHandler<TKey, TValue>
        where TKey : IComparable
    {
        public Node<TKey, TValue> Handle(Node<TKey, TValue> root, TKey key)
        {
            return SearchRecursively(root, key);
        }

        private Node<TKey, TValue> SearchRecursively(Node<TKey, TValue> currentNode, TKey key)
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
