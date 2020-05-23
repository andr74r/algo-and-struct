namespace AlgoAndStruct.BinaryTree.Tests.Fabric
{
    public static class NodeFabric
    {
        public static BinaryTreeNode<int, object> CreateNode(int key)
        {
            return new BinaryTreeNode<int, object>(key, new object());
        }
    }
}
