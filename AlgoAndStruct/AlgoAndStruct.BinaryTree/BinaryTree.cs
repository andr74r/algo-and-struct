using AlgoAndStruct.BinaryTree.Handlers;
using System;

namespace AlgoAndStruct.BinaryTree
{
    public class BinaryTree<TKey, TValue>
        where TKey : IComparable
    {
        private readonly InsertHandler<TKey, TValue> _insertHandler;
        private readonly RemoveHandler<TKey, TValue> _removeHandler;
        private readonly SearchHandler<TKey, TValue> _searchHandler;

        private Node<TKey, TValue> _root;

        public BinaryTree()
        {
            _insertHandler = new InsertHandler<TKey, TValue>();
            _removeHandler = new RemoveHandler<TKey, TValue>();
            _searchHandler = new SearchHandler<TKey, TValue>();
        }

        public void Insert(TKey key, TValue value)
        {
            _root = _insertHandler.Handle(_root, key, value);
        }

        public void Remove(TKey key)
        {
            _root = _removeHandler.Handle(_root, key);
        }

        public TValue Get(TKey key)
        {
            var node = _searchHandler.Handle(_root, key);

            if (node == null)
            {
                throw new ArgumentException("Key does not exist");
            }

            return node.Value;
        }
    }
}
