using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Graph
    {
        Random rand = new Random();
        List<Point> startPoints;
        Point[,] graph;
        int lenght;
        private void FillGraph()
        {
            for (int i = 0; i < lenght; i++)
            {
                graph[i, 0] = new Point("border",i,0);
                graph[0, i] = new Point("border",0,i);
                graph[i, lenght - 1] = new Point("border",i,lenght-1);
                graph[lenght - 1, i] = new Point("border",lenght-1,i);
            }
            for (int i = 1; i < lenght - 1; i++)
            {
                for (int j = 1; j < lenght - 1; j++)
                {
                    graph[i, j] = new Point("point",i,j);
                }
            }
            for (int i = 1; i < lenght - 1; i++)
            {
                for (int j = 1; j < lenght - 1; j++)
                {
                    if (rand.Next(0, 5) == 1)
                    {
                        graph[i, j] = new Point("wall", i, j);
                    }
                }
            }
            int port = 1 + rand.Next(0,lenght/2);
            for (int i = 0; i < port; i++)
            {
                int exit = rand.Next(1, lenght-1);
                int enter = rand.Next(1, lenght-1);
                graph[0, exit] = new Point("exit",0,exit);
                Point enterPoint = new Point("enter", lenght - 1, enter);
                startPoints.Add(enterPoint);
                graph[lenght - 1, enter] = enterPoint;
            }
        }
        private void PrintGraph()
        {
            for (int i = 0; i < lenght; i++)
            {
                for (int j = 0; j < lenght; j++)
                {
                    switch (graph[i, j]?.Status)
                    {
                        case null:
                        case "point":
                            if (graph[i,j].Visit == true)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write('*');
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write('*');
                            }
                            break;
                        case "wall":
                        case "border":
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write('#');
                            break;
                        case "exit":
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write('#');
                            break;
                        case "enter":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write('#');
                            break;

                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public int WayFinder(Point point, int lenght)
        {
            if (graph[point.X, point.Y + 1].Status == "exit")
            {
                return lenght;
            }
            if (graph[point.X, point.Y - 1].Status == "exit")
            {
                return lenght;
            }
            if (graph[point.X - 1, point.Y].Status == "exit")
            {
                return lenght;
            }
            if (!graph[point.X - 1, point.Y].Visit && graph[point.X - 1, point.Y].Status == "point")
            {
                graph[point.X - 1, point.Y].Visit = true;
                lenght = WayFinder(graph[point.X - 1, point.Y], ++lenght);
                if (lenght > 0)
                {
                    return lenght;
                }
                else
                {
                    graph[point.X - 1, point.Y].Visit = false;
                }
            }
            if (!graph[point.X, point.Y + 1].Visit && graph[point.X, point.Y + 1].Status == "point")
            {
                graph[point.X, point.Y + 1].Visit = true;
                lenght = WayFinder(graph[point.X, point.Y + 1], ++lenght);
                if (lenght > 0)
                {
                    return lenght;
                }
                else
                {
                    graph[point.X, point.Y + 1].Visit = false;
                }
            }
            if (!graph[point.X, point.Y - 1].Visit && graph[point.X, point.Y - 1].Status == "point")
            {
                graph[point.X, point.Y - 1].Visit = true;
                lenght = WayFinder(graph[point.X, point.Y - 1], ++lenght);
                if (lenght > 0)
                {
                    return lenght;
                }
                else
                {
                    graph[point.X, point.Y - 1].Visit = false;
                }
            }


            
            return 0;
        }
        public void FirstKR()
        {
            startPoints = new List<Point>();
            lenght = 15;
            graph = new Point[lenght, lenght];
            FillGraph();
            PrintGraph();
            int counter = 0;
            foreach (var item in startPoints)
            {

                if (WayFinder(item, 0) > 0)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
            PrintGraph();
        }
    }

    public class Point
    {
        public int X;
        public int Y;
        public string Status;
        public bool Visit;
        public Point()
        {
            Visit = false;
        }
        public Point(string status)
            : base()
        {
            Status = status;
        }
        public Point(string status, int x, int y)
            :this(status)
        {
            X = x;
            Y = y;
        }
    }
}
