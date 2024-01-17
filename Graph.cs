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
                        graph[i, j] = new Point("wall",i,j);
                    }
                }
            }
            int port = rand.Next(1, lenght / 2);
            for (int i = 0; i < port; i++)
            {
                int exit = rand.Next(1, lenght);
                int enter = rand.Next(1, lenght);
                graph[0, exit] = new Point("exit",0,exit);
                graph[lenght - 1, enter] = new Point("enter",lenght-1,enter);
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
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write('*');
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
        }
        static int minWay;
        public List<Point> WayFinder(Point point, int lenght)
        {
            List<Point> list = new List<Point>();
            if (!graph[point.X, point.Y + 1].Visit && graph[point.X, point.Y + 1].Status == "point")
            {
                WayFinder(graph[point.X, point.Y + 1], ++lenght);
            }
            if (!graph[point.X-1,point.Y].Visit && graph[point.X - 1, point.Y].Status == "point")
            {
                WayFinder(graph[point.X - 1, point.Y], ++lenght);
            }
            if (!graph[point.X + 1, point.Y].Visit && graph[point.X + 1, point.Y].Status == "point")
            {
                WayFinder(graph[point.X + 1, point.Y], ++lenght);
            }
            if (graph[point.X, point.Y + 1].Status == "enter")
            {

            }
            if (graph[point.X - 1, point.Y].Status == "enter")
            {

            }
            if (graph[point.X + 1, point.Y].Status == "enter")
            {

            }
            return new Point();
        }

        public void FirstKR()
        {
            lenght = 30;
            graph = new Point[lenght, lenght];
            FillGraph();
            PrintGraph();
            minWay = lenght * lenght;

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
