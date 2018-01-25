using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;

namespace Zadania
{
	class MainClass
	{
		static void Dijkstra(int[,] graph, int source, int pointsCount)
		{
			int[] distance = new int[pointsCount];
			bool[] shortestPathTreeSet = new bool[pointsCount];

			for (int i = 0; i < pointsCount; ++i)
			{
				distance[i] = int.MaxValue;
				shortestPathTreeSet[i] = false;
			}

			distance[source] = 0;

			for (int count = 0; count < pointsCount - 1; ++count)
			{
				int min = int.MaxValue;
				int minIndex = 0;

				for (int pointIndex = 0; pointIndex < pointsCount; ++pointIndex)
				{
					if (shortestPathTreeSet[pointIndex] == false && distance[pointIndex] <= min)
					{
						min = distance[pointIndex];
						minIndex = pointIndex;
					}
				}
					
				shortestPathTreeSet[minIndex] = true;

				for (int v = 0; v < pointsCount; ++v) 
				{
					if (!shortestPathTreeSet [v] && 
						Convert.ToBoolean (graph [minIndex, v]) && 
						distance [minIndex] != int.MaxValue && 
						distance [minIndex] + graph [minIndex, v] < distance [v]) 
					{
						distance [v] = distance [minIndex] + graph [minIndex, v];
					}
				}
			}

			Console.WriteLine("Point    Distance from source");

			for (int i = 1; i < pointsCount; ++i) 
			{
				Console.WriteLine ("{0}\t  {1}", i, distance [i]);
			}
		}

		public static void Main (string[] args)
		{
			int[,] graph = new int[9,9];
			foreach (string line in File.ReadLines("dijkstra.txt")) 
			{
				// start, finish, wage
				string[] component = line.Split (';');
				int a = Int32.Parse(component[0]);
				int b = Int32.Parse(component[1]);
				int c = Int32.Parse(component[2]);

				graph[a,b] = c;
			}
			Dijkstra (graph, 1, 9);
		}
	}
}
