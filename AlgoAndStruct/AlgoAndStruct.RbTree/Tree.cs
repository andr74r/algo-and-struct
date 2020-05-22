using AlgoAndStruct.RbTree.Handlers;

namespace AlgoAndStruct.RbTree
{
    public class Tree
    {
        private readonly InsertHandler _insertHandler;
        private readonly RemoveHandler _removeHandler;
        private readonly SearchHandler _searchHandler;

        private readonly Node _root;

        public Tree(Node root)
        {
            _root = root;

            _insertHandler = new InsertHandler();
            _removeHandler = new RemoveHandler();
            _searchHandler = new SearchHandler();
        }

        public void Insert(Node node)
        {
            _insertHandler.Handle(_root, node);
        }

        public void Remove(Node node)
        {
            _removeHandler.Handle(_root, node);
        }

        public Node Search(int value)
        {
            return _searchHandler.Handle(_root, value);
        }
    }
}
