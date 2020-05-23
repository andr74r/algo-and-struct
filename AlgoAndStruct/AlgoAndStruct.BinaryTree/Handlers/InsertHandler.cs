using AlgoAndStruct.BinaryTree.Extensions;
using System;

namespace AlgoAndStruct.BinaryTree.Handlers
{
    public class InsertHandler<TKey, TValue>
        where TKey : IComparable
    {
        public virtual Node<TKey, TValue> Handle(Node<TKey, TValue> root, TKey key, TValue value)
        {
            if (root == null)
            {
                root = new Node<TKey, TValue>(key, value);
            }
            else
            {
                var newNode = new Node<TKey, TValue>(key, value);
                InsertRecursively(root, newNode);
            }

            return root;
        }

        private void InsertRecursively(Node<TKey, TValue> currentNode, Node<TKey, TValue> newNode)
        {
            if (newNode.Key.GreaterThan(currentNode.Key))
            {
                if (currentNode.RightNode == null)
                {
                    currentNode.RightNode = newNode;
                    return;
                }

                InsertRecursively(currentNode.RightNode, newNode);
            }
            else
            {
                if (currentNode.LeftNode == null)
                {
                    currentNode.LeftNode = newNode;
                    return;
                }

                InsertRecursively(currentNode.LeftNode, newNode);
            }
        }
    }
}
