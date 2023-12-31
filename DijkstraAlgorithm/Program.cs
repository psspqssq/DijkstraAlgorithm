﻿
namespace DijkstraAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WeightedGraph<int> graph = new WeightedGraph<int>(true, true);
            WeightedGraphNode<int> n1 = graph.AddNode(1);
            WeightedGraphNode<int> n2 = graph.AddNode(2);
            WeightedGraphNode<int> n3 = graph.AddNode(3);
            WeightedGraphNode<int> n4 = graph.AddNode(4);
            WeightedGraphNode<int> n5 = graph.AddNode(5);
            WeightedGraphNode<int> n6 = graph.AddNode(6);
            WeightedGraphNode<int> n7 = graph.AddNode(7);
            WeightedGraphNode<int> n8 = graph.AddNode(8);
            graph.AddEdge(n1, n2, 11);
            graph.AddEdge(n2, n1, 11);

            graph.AddEdge(n1, n4, 11);
            graph.AddEdge(n4, n1, 11);

            graph.AddEdge(n2, n3, 18);
            graph.AddEdge(n3, n2, 18);

            graph.AddEdge(n2, n5, 8);
            graph.AddEdge(n5, n2, 8);

            graph.AddEdge(n3, n6, 11);
            graph.AddEdge(n6, n3, 11);

            graph.AddEdge(n4, n5, 13);
            graph.AddEdge(n5, n4, 13);

            graph.AddEdge(n4, n7, 15);
            graph.AddEdge(n7, n4, 15);

            graph.AddEdge(n5, n6, 13);
            graph.AddEdge(n6, n5, 13);

            graph.AddEdge(n5, n7, 10);
            graph.AddEdge(n7, n5, 10);

            graph.AddEdge(n6, n8, 7);
            graph.AddEdge(n8, n6, 7);

            graph.AddEdge(n7, n8, 21);
            graph.AddEdge(n8, n7, 21);

            Console.WriteLine("================================================\n");
            Console.WriteLine("Generic Weighted Directed Graph\n");
            Console.WriteLine("Adjacency List Implementation\n");
            Console.WriteLine("================================================\n");
            Console.WriteLine(WeightedGraph<int>.PrintGraph(graph));
            Console.WriteLine("\n================================================\n");
            Console.WriteLine($"Dijkstra's Algorithm Shortest Path Node {n1} to {n8}");
            Console.WriteLine("================================================\n");
            //Dijkstra.ShortestPath(graph, n7, n3).ForEach(e => Console.WriteLine(e.ToString() + "\n")); 
        }
    }
}