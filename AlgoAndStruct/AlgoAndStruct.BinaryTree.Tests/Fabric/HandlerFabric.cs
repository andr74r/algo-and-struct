using AlgoAndStruct.BinaryTree.Handlers;

namespace AlgoAndStruct.BinaryTree.Tests.Fabric
{
    public static class HandlerFabric
    {
        public static InsertHandler<int, object> CreateInsertHandler()
        {
            return new InsertHandler<int, object>();
        }

        public static RemoveHandler<int, object> CreateRemoveHandler()
        {
            return new RemoveHandler<int, object>();
        }
    }
}
