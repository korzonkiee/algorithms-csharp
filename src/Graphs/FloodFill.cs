using System;
using System.Collections.Generic;

namespace Algorithms.Graphs
{
    // 0,1,2,3
    // 0,1,2,2
    // 0,1,1,1
    // 0,0,0,0
    public class FloodFill
    {
        private int[,] arr;
        private bool[,] visited;

        public FloodFill(int[,] arr)
        {
            this.arr = arr;
            this.visited = new bool[arr.GetLength(0), arr.GetLength(1)];
        }

        public int FindLargestFill()
        {
            int max = 0;

            for (int x = 0; x < arr.GetLength(0); x++)
            {
                for (int y = 0; y < arr.GetLength(1); y++)
                {
                    if (!visited[x, y])
                    {
                        int fill = DFS(x, y, 1);
                        if (fill > max) max = fill;
                    }
                }
            }

            return max;
        }

        private int BFS(int x, int y, int acc)
        {
            var queue = new Queue<(int, int)>();
            queue.Enqueue((x, y));

            while (queue.Count > 0)
            {
                var (e_x, e_y) = queue.Dequeue();
                if (visited[e_x, e_y]) continue;

                visited[e_x, e_y] = true;
                acc = acc + 1;

                var neighs = GetNeighbors(e_x, e_y);
                neighs = FilterNeighbors(e_x, e_y, neighs);

                foreach (var neigh in neighs)
                {
                    queue.Enqueue(neigh);
                }

            }

            return acc;
        }

        private int DFS(int x, int y, int acc)
        {
            visited[x, y] = true;

            var neighs = GetNeighbors(x, y);
            neighs = FilterNeighbors(x, y, neighs);

            foreach (var neigh in neighs)
            {
                if (!visited[neigh.Item1, neigh.Item2])
                {
                    acc = DFS(neigh.Item1, neigh.Item2, acc + 1);
                }
            }

            return acc;
        }

        // Remove neighbors that are visited or have different value.
        private List<(int, int)> FilterNeighbors(int x, int y, List<(int, int)> neighs)
        {
            neighs.RemoveAll(n =>
                visited[n.Item1, n.Item2] ||
                arr[x, y] != arr[n.Item1, n.Item2]
            );
            return neighs;
        }

        private List<(int, int)> GetNeighbors(int x, int y)
        {
            var neighbors = new List<(int, int)>();

            neighbors.Add((x - 1, y));
            neighbors.Add((x, y - 1));
            neighbors.Add((x + 1, y));
            neighbors.Add((x, y + 1));

            int w = this.arr.GetLength(0);
            int h = this.arr.GetLength(1);

            neighbors.RemoveAll(n =>
                n.Item1 < 0 || n.Item1 >= w ||
                n.Item2 < 0 || n.Item2 >= h
            );

            return neighbors;
        }
    }
}