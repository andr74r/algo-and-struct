using AlgoAndStruct.BinaryTree.Extensions;
using System;

namespace AlgoAndStruct.BinaryTree.Handlers
{
    public class RemoveHandler<TKey, TValue>
        where TKey : IComparable
    {
        public virtual Node<TKey, TValue> Handle(Node<TKey, TValue> root, TKey key)
        {
            return DeleteRecursively(root, key);
        }

        private Node<TKey, TValue> DeleteRecursively(Node<TKey, TValue> currentNode, TKey key)
        {
            if (currentNode == null)
            {
                return null;
            }

            if (key.LessThan(currentNode.Key))
            {
                currentNode.LeftNode = DeleteRecursively(currentNode.LeftNode, key);
            }
            else if (key.GreaterThan(currentNode.Key))
            {
                currentNode.RightNode = DeleteRecursively(currentNode.RightNode, key);
            }
            else
            {
                if (currentNode.LeftNode == null)
                {
                    return currentNode.RightNode;
                }
                else if (currentNode.RightNode == null)
                {
                    return currentNode.LeftNode;
                }
                else
                {
                    var nodeToReplace = FindSmallestNode(currentNode.RightNode);

                    DeleteRecursively(currentNode, nodeToReplace.Key);

                    nodeToReplace.LeftNode = currentNode.LeftNode;
                    nodeToReplace.RightNode = currentNode.RightNode;

                    return nodeToReplace;
                }
            }

            return currentNode;
        }

        private Node<TKey, TValue> FindSmallestNode(Node<TKey, TValue> currentNode)
        {
            if (currentNode.LeftNode == null)
            {
                return currentNode;
            }

            return FindSmallestNode(currentNode.LeftNode);
        }
    }
}
