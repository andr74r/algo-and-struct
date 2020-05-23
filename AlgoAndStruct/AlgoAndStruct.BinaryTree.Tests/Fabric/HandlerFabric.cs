using AlgoAndStruct.BinaryTree.Handlers;

namespace AlgoAndStruct.BinaryTree.Tests.Fabric
{
    public static class HandlerFabric
    {
        public static BinaryTreeInsertHandler<int, object> CreateInsertHandler()
        {
            return new BinaryTreeInsertHandler<int, object>();
        }

        public static BinaryTreeRemoveHandler<int, object> CreateRemoveHandler()
        {
            return new BinaryTreeRemoveHandler<int, object>();
        }

        public static BinaryTreeSearchHandler<int, object> CreateSearchHandler()
        {
            return new BinaryTreeSearchHandler<int, object>();
        }
    }
}
