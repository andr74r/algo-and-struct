namespace AlgoAndStruct.BinaryTree.Tests.Fabric
{
    public static class NodeFabric
    {
        public static Node<int, object> CreateNode(int key)
        {
            return new Node<int, object>(key, new object());
        }
    }
}
