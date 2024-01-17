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

    }
    public class Point
    {
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
    }
}
