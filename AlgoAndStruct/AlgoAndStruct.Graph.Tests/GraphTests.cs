﻿using NUnit.Framework;

namespace AlgoAndStruct.Graph.Tests
{
    [TestFixture]
    public class GraphTests
    {
        [Test]
        public void AddNode_NewNode_ShouldAddNode()
        {
            // Arrange
            var graph = new Graph<string, int, int>();

            // Act
            graph.AddNode("node", 3);

            // Assert
            Assert.AreEqual(1, graph.Nodes.Count);
            Assert.AreEqual("node", graph.Nodes[0].Key);
            Assert.AreEqual(3, graph.Nodes[0].Value);
        }

        [Test]
        public void AddNode_NodeExists_ShouldThrowException()
        {
            // Arrange
            var graph = new Graph<string, int, int>();
            graph.AddNode("node", 3);

            // Act
            var del = new TestDelegate(() => graph.AddNode("node", 3));

            // Assert
            Assert.Throws<System.ArgumentException>(del);
        }

        [Test]
        public void AddEdge_NewEdge_ShouldAddNewEdge()
        {
            // Arrange
            var graph = new Graph<string, int, int>();
            graph.AddNode("node1", 1);
            graph.AddNode("node2", 2);

            // Act
            graph.AddEdge("node1", "node2", 3);

            // Assert
            Assert.AreEqual(1, graph.Edges.Count);
            Assert.AreEqual("node1", graph.Edges[0].From.Key);
            Assert.AreEqual("node2", graph.Edges[0].To.Key);
        }

        [Test]
        public void AddEdge_EdgeExists_ShouldThrowArgException()
        {
            // Arrange
            var graph = new Graph<string, int, int>();
            graph.AddNode("node1", 1);
            graph.AddNode("node2", 2);
            graph.AddEdge("node1", "node2", 3);

            // Act
            var del = new TestDelegate(() => graph.AddEdge("node1", "node2", 1));

            // Assert
            Assert.Throws<System.ArgumentException>(del);
        }

        [Test]
        public void AddEdge_NodeDoesNotExist_ShouldThrowArgException()
        {
            // Arrange
            var graph = new Graph<string, int, int>();
            graph.AddNode("node1", 1);

            // Act
            var del = new TestDelegate(() => graph.AddEdge("node1", "node2", 1));

            // Assert
            Assert.Throws<System.ArgumentException>(del);
        }

        [Test]
        public void RemoveNode_Key_ShouldRemoveNodeAndEdges()
        {
            // Arrange
            var graph = new Graph<string, int, int>();
            graph.AddNode("node1", 1);
            graph.AddNode("node2", 2);
            graph.AddEdge("node1", "node2", 3);
            graph.AddEdge("node2", "node1", 3);

            // Act
            graph.RemoveNode("node2");

            // Assert
            Assert.AreEqual(1, graph.Nodes.Count);
            Assert.AreEqual("node1", graph.Nodes[0].Key);
            Assert.AreEqual(0, graph.Edges.Count);
        }

        [Test]
        public void Indexer_EdgeExists_ShouldReturnEdgeWeight()
        {
            // Arrange
            var graph = new Graph<string, int, int>();
            graph.AddNode("node1", 1);
            graph.AddNode("node2", 2);

            graph.AddEdge("node1", "node1", 3);

            // Act
            var actual = graph["node1", "node1"];

            // Assert
            Assert.AreEqual(3, actual);
        }

        [Test]
        public void Indexer_EdgeDoNotExist_ShouldReturnDefaultValue()
        {
            // Arrange
            var graph = new Graph<string, int, int>();
            graph.AddNode("node1", 1);
            graph.AddNode("node2", 2);

            graph.AddEdge("node1", "node1", 3);

            // Act
            var actual = graph["node1", "node2"];

            // Assert
            Assert.AreEqual(0, actual);
        }

        [Test]
        public void Indexer_NodesDoNotExist_ShouldThrowArgException()
        {
            // Arrange
            var graph = new Graph<string, int, int>();
            graph.AddNode("node1", 1);
            graph.AddNode("node2", 2);

            graph.AddEdge("node1", "node1", 3);

            // Act
            var del = new TestDelegate(() => {
                var value = graph["node1", "node3"];
            });

            // Assert
            Assert.Throws<System.ArgumentException>(del);
        }

        [Test]
        public void Indexer_SetValue_ShouldAddEdge()
        {
            // Arrange
            var graph = new Graph<string, int, int>();
            graph.AddNode("node1", 1);
            graph.AddNode("node2", 2);

            // Act
            graph["node1", "node2"] = 3;

            // Assert
            Assert.AreEqual(1, graph.Edges.Count);
            Assert.AreEqual(3, graph.Edges[0].Weight);
        }

        [Test]
        public void Indexer_SetValueAndEdgeExists_ShouldUpdateEdgeWeight()
        {
            // Arrange
            var graph = new Graph<string, int, int>();
            graph.AddNode("node1", 1);
            graph.AddNode("node2", 2);
            graph.AddEdge("node1", "node2", 1);

            // Act
            graph["node1", "node2"] = 3;

            // Assert
            Assert.AreEqual(1, graph.Edges.Count);
            Assert.AreEqual(3, graph.Edges[0].Weight);
        }

        [Test]
        public void Indexer_SetValueAndNodesDoNotExist_ShouldThrowArgException()
        {
            // Arrange
            var graph = new Graph<string, int, int>();
            graph.AddNode("node1", 1);

            // Act
            var del = new TestDelegate(() => graph["node1", "node2"] = 3);

            // Assert
            Assert.Throws<System.ArgumentException>(del);
        }

        [Test]
        public void Indexer_SetDefaultValueAndEdgeExists_ShouldRemoveEdge()
        {
            // Arrange
            var graph = new Graph<string, int, int>();
            graph.AddNode("node1", 1);
            graph.AddNode("node2", 2);
            graph.AddEdge("node1", "node2", 1);

            // Act
            graph["node1", "node2"] = 0;

            // Assert
            Assert.AreEqual(0, graph.Edges.Count);
        }
    }
}
