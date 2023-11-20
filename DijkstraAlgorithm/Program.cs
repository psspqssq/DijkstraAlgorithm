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
            graph.AddEdge(n1, n2, 9);
            graph.AddEdge(n1, n3, 5);
            graph.AddEdge(n2, n1, 3);
            graph.AddEdge(n2, n4, 18);
            graph.AddEdge(n3, n4, 12);
            graph.AddEdge(n4, n8, 8);
            graph.AddEdge(n4, n2, 2);
            graph.AddEdge(n5, n4, 9);
            graph.AddEdge(n5, n6, 2);
            graph.AddEdge(n5, n8, 3);
            graph.AddEdge(n5, n7, 5);
            graph.AddEdge(n6, n7, 1);
            graph.AddEdge(n7, n5, 4);
            graph.AddEdge(n7, n8, 6);
            graph.AddEdge(n8, n5, 3);
            Console.WriteLine("================================================\n");
            Console.WriteLine("Generic Weighted Directed Graph\n");
            Console.WriteLine("Adjacency List Implementation\n");
            Console.WriteLine("================================================\n");
            Console.WriteLine(WeightedGraph<int>.PrintGraph(graph));
            Console.WriteLine("\n================================================\n");
            Console.WriteLine($"Dijkstra's Algorithm Shortest Path Node {n6} to {n1}");
            Console.WriteLine("================================================\n");
            ShortestPath(graph, n6, n1).ForEach(e => Console.WriteLine(e.ToString() + "\n")); 
        }

        static List<WeightedEdge<int>> ShortestPath(WeightedGraph<int> graph, WeightedGraphNode<int> from, WeightedGraphNode<int> to)
        {
            List<WeightedEdge<int>> path = graph.GetShortestPathDijkstra(from, to);
            return path;
        }
    }
}