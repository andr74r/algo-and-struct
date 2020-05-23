using AlgoAndStruct.BinaryTree.Handlers;
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
            var handler = GetInsertHandler();

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
            var handler = GetInsertHandler();

            var root = CreateNode(10);

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
            var handler = GetInsertHandler();

            var root = CreateNode(10);

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
            var handler = GetInsertHandler();

            var root = CreateNode(10);
            root.LeftNode = CreateNode(5);
            root.LeftNode.RightNode = CreateNode(7);

            // Act
            var actual = handler.Handle(root, 6, new object());

            // Assert
            var inserted = actual.LeftNode.RightNode.LeftNode;
            Assert.IsNotNull(inserted);
            Assert.AreEqual(6, inserted.Key);
        }

        private InsertHandler<int, object> GetInsertHandler()
        {
            return new InsertHandler<int, object>();
        }

        private Node<int, object> CreateNode(int key)
        {
            return new Node<int, object>(key, new object());
        }
    }
}
