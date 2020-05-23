using AlgoAndStruct.BinaryTree.Extensions;
using System;

namespace AlgoAndStruct.BinaryTree.Handlers
{
    public class BinaryTreeInsertHandler<TKey, TValue>
        where TKey : IComparable
    {
        public virtual BinaryTreeNode<TKey, TValue> Handle(BinaryTreeNode<TKey, TValue> root, TKey key, TValue value)
        {
            if (root == null)
            {
                root = new BinaryTreeNode<TKey, TValue>(key, value);
            }
            else
            {
                var newNode = new BinaryTreeNode<TKey, TValue>(key, value);
                InsertRecursively(root, newNode);
            }

            return root;
        }

        private void InsertRecursively(BinaryTreeNode<TKey, TValue> currentNode, BinaryTreeNode<TKey, TValue> newNode)
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
