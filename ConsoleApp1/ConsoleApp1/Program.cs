using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string maninAreaInput = Console.ReadLine();
            Area mainArea = null;

            try
            {
                string[] maninAreaInputXY = maninAreaInput.Split(' ');
                mainArea = new Area(Convert.ToInt32(maninAreaInputXY[0]), Convert.ToInt32(maninAreaInputXY[1]));
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);

            }

            List<string> resultString = new List<string>();
            while (true)
            {
                string locationInput = Console.ReadLine();
                string pathInput = Console.ReadLine();

                if (String.IsNullOrEmpty(locationInput) || String.IsNullOrEmpty(pathInput))
                {
                    break;
                }
                else
                {
                    //get location

                    try
                    {
                        string[] locationInfo = locationInput.Split(' ');
                        Location startLocation = new Location(Convert.ToInt32(locationInfo[0]), Convert.ToInt32(locationInfo[1]), locationInfo[2]);

                        Path path = new Path(startLocation, pathInput.Select(c => c.ToString()).ToList());

                        path.EndPoint = CalculateEndLocation(mainArea, startLocation, path.OrderString);
                        resultString.Add(path.EndPoint.X + " " + path.EndPoint.Y + " " + path.EndPoint.Direction);
                      
                        Console.WriteLine("Do You want to exit? (Y/N)"); // birden fazla input girebilmek amacıyla yazıldı.

                        if (String.Equals(Console.ReadLine().ToUpper(), "Y"))
                        {
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("{0} Exception caught.", ex);

                    }
                }
            }

            Console.WriteLine(String.Join(Environment.NewLine, resultString));
            Console.ReadKey();
        }


        public static Location CalculateEndLocation(Area mainArea, Location startPoint, List<string> OrderString)
        {
            string currentDirection = startPoint.Direction;
            int currentXPoint = startPoint.X;
            int currentYPoint = startPoint.Y;

            try
            {
                foreach (var order in OrderString)
                {
                    if (String.Equals(order, "L"))
                    {
                        if (String.Equals(currentDirection, "E"))
                        {
                            currentDirection = "N";
                        }
                        else if (String.Equals(currentDirection, "W"))
                        {
                            currentDirection = "S";
                        }
                        else if (String.Equals(currentDirection, "S"))
                        {
                            currentDirection = "E";
                        }
                        else if (String.Equals(currentDirection, "N"))
                        {
                            currentDirection = "W";
                        }
                    }
                    else if (String.Equals(order, "R"))
                    {
                        if (String.Equals(currentDirection, "E"))
                        {
                            currentDirection = "S";
                        }
                        else if (String.Equals(currentDirection, "W"))
                        {
                            currentDirection = "N";
                        }
                        else if (String.Equals(currentDirection, "S"))
                        {
                            currentDirection = "W";
                        }
                        else if (String.Equals(currentDirection, "N"))
                        {
                            currentDirection = "E";
                        }
                    }
                    else if (String.Equals(order, "M"))
                    {
                        if (String.Equals(currentDirection, "E"))
                        {
                            if (currentXPoint + 1 <= mainArea.X)
                            {
                                currentXPoint = currentXPoint + 1;
                            }
                        }
                        else if (String.Equals(currentDirection, "W"))
                        {
                            if (currentXPoint - 1 >= 0)
                                currentXPoint = currentXPoint - 1;
                        }
                        else if (String.Equals(currentDirection, "S"))
                        {
                            if (currentYPoint - 1 >= 0)
                            {
                                currentYPoint = currentYPoint - 1;
                            }
                        }
                        else if (String.Equals(currentDirection, "N"))
                        {
                            if (currentYPoint + 1 <= mainArea.Y)
                            {
                                currentYPoint = currentYPoint + 1;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return new Location(currentXPoint, currentYPoint, currentDirection);
        }


    }






}
