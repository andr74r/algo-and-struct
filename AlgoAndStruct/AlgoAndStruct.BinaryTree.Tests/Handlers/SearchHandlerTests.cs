using AlgoAndStruct.BinaryTree.Tests.Fabric;
using NUnit.Framework;

namespace AlgoAndStruct.BinaryTree.Tests.Handlers
{
    [TestFixture]
    public class SearchHandlerTests
    {
        [Test]
        public void Handle_SearchKeyDoesNotExist_ShouldReturnNull()
        {
            // Arrange
            var handler = HandlerFabric.CreateSearchHandler();

            var root = NodeFabric.CreateNode(10);
            root.LeftNode = NodeFabric.CreateNode(5);
            root.RightNode = NodeFabric.CreateNode(15);
            root.RightNode.LeftNode = NodeFabric.CreateNode(12);

            // Act
            var actual = handler.Handle(root, 3);

            // Assert
            Assert.IsNull(actual);
        }

        [Test]
        public void Handle_SearchKeyExists_ShouldReturnNodeWithTheSameKey()
        {
            // Arrange
            var handler = HandlerFabric.CreateSearchHandler();

            var root = NodeFabric.CreateNode(10);
            root.LeftNode = NodeFabric.CreateNode(5);
            root.RightNode = NodeFabric.CreateNode(15);
            root.RightNode.LeftNode = NodeFabric.CreateNode(12);

            // Act
            var actual = handler.Handle(root, 12);

            // Assert
            Assert.AreEqual(root.RightNode.LeftNode, actual);
        }
    }
}
