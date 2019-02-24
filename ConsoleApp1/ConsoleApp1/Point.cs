using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class Area : Point
    {
        public Area(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    public class Location : Point
    {
        public string Direction { get; set; }

        public Location(int x, int y, string direction)
        {
            this.X = x;
            this.Y = y;
            this.Direction = direction;
        }
    }

    public class Path
    {
        public List<string> OrderString { get; set; }
        public Location StartPoint;
        public Location EndPoint;

        public Path(Location startPoint, List<string> orderString)
        {
            this.StartPoint = startPoint;
            this.OrderString = orderString;
        }
    }
}
