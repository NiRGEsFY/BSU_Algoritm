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
        int ports;
        bool Visual = true;
        public Graph()
        {
            ports = 0;
            startPoints = new List<Point>();
            lenght = 15;
            graph = new Point[lenght, lenght];
        }
        public Graph(bool visual)
            :this()
        {
            Visual = visual;
        }
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
            int port;
            if (ports == 0)
            {
                port = rand.Next(lenght / 2, lenght);
            }
            else
            {
                port = ports;
            }
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
        private int WayFinderRight(Point point, int lenght = 0)
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
                lenght = WayFinderRight(graph[point.X - 1, point.Y], ++lenght);
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
                lenght = WayFinderRight(graph[point.X, point.Y + 1], ++lenght);
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
                lenght = WayFinderRight(graph[point.X, point.Y - 1], ++lenght);
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
        private int WayFinderLeft(Point point, int lenght = 0)
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
                lenght = WayFinderLeft(graph[point.X - 1, point.Y], ++lenght);
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
                lenght = WayFinderLeft(graph[point.X, point.Y + 1], ++lenght);
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
                lenght = WayFinderLeft(graph[point.X, point.Y - 1], ++lenght);
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
        public int Start()
        {
            FillGraph();
            if (Visual)
            {
                PrintGraph();
            }
            int counterRight = 0;
            int counterLeft = 0;
            foreach (var item in startPoints)
            {
                if (WayFinderRight(item) > 0)
                {
                    counterRight++;
                }
            }
            foreach (var item in graph)
            {
                item.Visit = false;
            }
            foreach (var item in startPoints)
            {
                if (WayFinderLeft(item) > 0)
                {
                    counterLeft++;
                }
            }
            if (counterLeft >= counterRight)
            {
                if (Visual)
                {
                    Console.WriteLine(counterLeft);
                    PrintGraph();
                }
                return counterLeft;
                
            }
            else
            {
                foreach (var item in startPoints)
                {
                    WayFinderRight(item);
                }
                if (Visual)
                {
                    Console.WriteLine(counterRight);
                    PrintGraph();
                }
                return counterRight;
            }

            
            
        }
        public int Start(int field)
        {
            lenght = field;
            graph = new Point[lenght, lenght];
            return Start();
        }
        public int Start(int field, int port)
        {
            ports = port;
            return Start(field);
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
