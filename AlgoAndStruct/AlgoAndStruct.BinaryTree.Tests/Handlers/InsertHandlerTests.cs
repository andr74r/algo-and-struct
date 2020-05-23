using AlgoAndStruct.BinaryTree.Handlers;
using AlgoAndStruct.BinaryTree.Tests.Fabric;
using NUnit.Framework;

namespace AlgoAndStruct.BinaryTree.Tests.Handlers
{
    [TestFixture]
    public class InsertHandlerTests
    {
        [Test]
        public void Handle_RootIsNull_RootShouldBeInsertedNode()
        {
            // Arrange
            var handler = HandlerFabric.CreateInsertHandler();

            // Act
            var actual = handler.Handle(null, 3, new object());

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(3, actual.Key);
        }

        [Test]
        public void Handle_InsertedValueLessThenRoot_ShoudInsertIntoLeftNode()
        {
            // Arrange
            var handler = HandlerFabric.CreateInsertHandler();

            var root = NodeFabric.CreateNode(10);

            // Act
            var actual = handler.Handle(root, 3, new object());

            // Assert
            Assert.IsNotNull(actual.LeftNode);
            Assert.AreEqual(3, actual.LeftNode.Key);
        }

        [Test]
        public void Handle_InsertedValueMoreThenRoot_ShoudInsertIntoRightNode()
        {
            // Arrange
            var handler = HandlerFabric.CreateInsertHandler();

            var root = NodeFabric.CreateNode(10);

            // Act
            var actual = handler.Handle(root, 15, new object());

            // Assert
            Assert.IsNotNull(actual.RightNode);
            Assert.AreEqual(15, actual.RightNode.Key);
        }

        [Test]
        public void Handle_TreeHasSomeNodes_ShouldInsertIntoCorrectNode()
        {
            // Arrange
            var handler = HandlerFabric.CreateInsertHandler();

            var root = NodeFabric.CreateNode(10);
            root.LeftNode = NodeFabric.CreateNode(5);
            root.LeftNode.RightNode = NodeFabric.CreateNode(7);

            // Act
            var actual = handler.Handle(root, 6, new object());

            // Assert
            var inserted = actual.LeftNode.RightNode.LeftNode;
            Assert.IsNotNull(inserted);
            Assert.AreEqual(6, inserted.Key);
        }
    }
}
