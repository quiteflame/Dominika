using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;

namespace Zadania
{
	class MainClass
	{
		public struct Graph
		{
			public List<Edge> edges;
			public HashSet<string> vertices;
		}

		public struct Edge
		{
			public string Source;
			public string Destination;
			public int Weight;
		}

		public struct DisjointSets
		{
			Dictionary<string, string> parent;
			Dictionary<string, int> rank;

			public DisjointSets(HashSet<string> vertices)
			{
				parent = new Dictionary<string, string>();
				rank = new Dictionary<string, int>();

				foreach (string v in vertices)
				{
					rank.Add(v, 0);
					parent.Add(v, v);
				}
			}
				
			public string findParent(string u)
			{
				if (u != parent [u]) {
					parent [u] = findParent (parent [u]);
				}

				return parent [u];
			}

			public void mergeByRank(string x, string y)
			{
				x = findParent (x);
				y = findParent (y);

				if (rank [x] > rank [y]) {
					parent [y] = x;
				} else {
					parent [x] = y;
				}
				if (rank [x] == rank [y]) {
					rank [y]++;
				}
			}
		}

		static void Kruskal(Graph graph)
		{
			int weight = 0;

			List<Edge> sortedEdges = graph.edges.OrderBy(o => o.Weight).ToList();

			DisjointSets ds = new DisjointSets(graph.vertices);

			foreach (Edge edge in sortedEdges)
			{
				string u = edge.Source;
				string v = edge.Destination;

				string set_u = ds.findParent(u);
				string set_v = ds.findParent(v);

				if (set_u != set_v)
				{
					weight += edge.Weight;
					ds.mergeByRank(set_u, set_v);
				}
			}

			Console.WriteLine ("Weight of minimum spanning tree is " + weight);
		}

		public static void Main (string[] args)
		{
			List<Edge> edges = new List<Edge>();
			HashSet<string> vertices = new HashSet<string> ();
			Graph graph = new Graph();

			foreach (string line in File.ReadLines("kruskal.txt")) 
			{
				// start, finish, wage
				string[] component = line.Split (';');
				string a = component[0];
				string b = component[1];
				int c = Int32.Parse(component[2]);

				vertices.Add (a);
				vertices.Add (b);

				Edge edge = new Edge ();
				edge.Source = a;
				edge.Destination = b;
				edge.Weight = c;

				edges.Add(edge);

				graph.edges = edges;
				graph.vertices = vertices;
			}
			Kruskal (graph);
		}
	}
}
