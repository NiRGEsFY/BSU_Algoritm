﻿namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Algoritm alg = new Algoritm();
            Graph gr = new Graph();
            gr.Start(20);
            Console.ReadKey();
        }
    }
}