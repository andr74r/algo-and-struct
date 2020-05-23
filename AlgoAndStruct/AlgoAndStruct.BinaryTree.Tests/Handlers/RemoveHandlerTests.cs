using AlgoAndStruct.BinaryTree.Tests.Fabric;
using NUnit.Framework;

namespace AlgoAndStruct.BinaryTree.Tests.Handlers
{
    [TestFixture]
    public class RemoveHandlerTests
    {
        [Test]
        public void Handle_RemoveNodeFromEmptyTree_ShouldReturnNull()
        {
            // Arrange
            var handler = HandlerFabric.CreateRemoveHandler();

            // Act
            var actual = handler.Handle(null, 3);

            // Assert
            Assert.IsNull(actual);
        }

        [Test]
        public void Handle_TreeHasOnlyRoot_ShouldReturnNull()
        {
            // Arrange
            var handler = HandlerFabric.CreateRemoveHandler();
            var root = NodeFabric.CreateNode(3);

            // Act
            var actual = handler.Handle(root, 3);

            // Assert
            Assert.IsNull(actual);
        }

        [Test]
        public void Handle_NodeToDeleteIsLeaf_ShouldRemoveOnlyLeaf()
        {
            // Arrange
            var handler = HandlerFabric.CreateRemoveHandler();
            var root = NodeFabric.CreateNode(10);
            root.LeftNode = NodeFabric.CreateNode(3);

            // Act
            var actual = handler.Handle(root, 3);

            // Assert
            Assert.IsNull(actual.LeftNode);
        }

        [Test]
        public void Handle_NodeToDeleteHasOneChild_ShouldReplaceNodeToDeleteByChild()
        {
            // Arrange
            var handler = HandlerFabric.CreateRemoveHandler();
            var root = NodeFabric.CreateNode(10);
            root.LeftNode = NodeFabric.CreateNode(3);
            root.LeftNode.RightNode = NodeFabric.CreateNode(5);

            // Act
            var actual = handler.Handle(root, 3);

            // Assert
            Assert.AreEqual(5, actual.LeftNode.Key);
            Assert.IsNull(actual.LeftNode.RightNode);
        }

        [Test]
        public void Handle_NodeToDeleteHasTwoChildren_ShouldReplaceNodeToDeleteBySmallestNodeInRightSubtree()
        {
            // Arrange
            var handler = HandlerFabric.CreateRemoveHandler();
            var root = NodeFabric.CreateNode(5);
            root.LeftNode = NodeFabric.CreateNode(4);
            root.RightNode = NodeFabric.CreateNode(7);
            root.RightNode.LeftNode = NodeFabric.CreateNode(6);
            root.RightNode.RightNode = NodeFabric.CreateNode(8);

            // Act
            var actual = handler.Handle(root, 5);

            // Assert
            Assert.AreEqual(6, actual.Key);
            Assert.AreEqual(7, actual.RightNode.Key);
            Assert.AreEqual(4, actual.LeftNode.Key);
            Assert.IsNull(actual.RightNode.LeftNode);
        }

        [Test]
        public void Handle_NodeToDeleteHasTwoLeaves_ShouldReplaceNodeToDeleteByRightNode()
        {
            // Arrange
            var handler = HandlerFabric.CreateRemoveHandler();
            var root = NodeFabric.CreateNode(5);
            root.LeftNode = NodeFabric.CreateNode(4);
            root.RightNode = NodeFabric.CreateNode(6);

            // Act
            var actual = handler.Handle(root, 5);

            // Assert
            Assert.AreEqual(6, actual.Key);
            Assert.AreEqual(4, actual.LeftNode.Key);
            Assert.IsNull(actual.RightNode);
        }
    }
}
