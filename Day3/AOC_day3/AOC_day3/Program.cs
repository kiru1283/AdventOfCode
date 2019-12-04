using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_day3
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input1 = "R8,U5,L5,D3";//"R75,D30,R83,U83,L12,D49,R71,U7,L72";
            //string input2 = "U7,R6,D4,L4"; //"U62,R66,U55,R34,D71,R55,D58,R83";
            //string input1 = "R75,D30,R83,U83,L12,D49,R71,U7,L72";
            //string input2 = "U62,R66,U55,R34,D71,R55,D58,R83";
            string input1 = "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51";
            string input2 = "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7";
            CalculateDistance(input1, input2);

        }

        public static void CalculateDistance(string input1, string input2)
        {

            string[] inputs1 = input1.Split(',');
            int x1 = 0;
            int y1 = 0;
            string[] wire1 = new string[inputs1.Length+1];
            wire1.SetValue("0,0",0);
            for (int i = 0; i < inputs1.Length; i++)
            {
                if (inputs1[i].StartsWith("R"))
                {
                    x1 = x1 + Convert.ToInt32(inputs1[i].Replace("R",""));
                }
                if (inputs1[i].StartsWith("L"))
                {
                    x1 = x1 - Convert.ToInt32(inputs1[i].Replace("L", ""));
                }
                if (inputs1[i].StartsWith("U"))
                {
                    y1 = y1 + Convert.ToInt32(inputs1[i].Replace("U", ""));
                }
                if (inputs1[i].StartsWith("D"))
                {
                    y1 = y1 - Convert.ToInt32(inputs1[i].Replace("D", ""));
                }
                wire1.SetValue(x1.ToString()+","+y1.ToString(),i+1);
            }
            Console.WriteLine("wire1: "+ string.Join("/",wire1));


            string[] inputs2 = input2.Split(',');
            int x2 = 0;
            int y2 = 0;
            string[] wire2 = new string[inputs2.Length+1];
            wire2.SetValue("0,0", 0);
            for (int i = 0; i < inputs2.Length; i++)
            {
                if (inputs2[i].StartsWith("R"))
                {
                    x2 = x2 + Convert.ToInt32(inputs2[i].Replace("R", ""));
                }
                if (inputs2[i].StartsWith("L"))
                {
                    x2 = x2 - Convert.ToInt32(inputs2[i].Replace("L", ""));
                }
                if (inputs2[i].StartsWith("U"))
                {
                    y2 = y2 + Convert.ToInt32(inputs2[i].Replace("U", ""));
                }
                if (inputs2[i].StartsWith("D"))
                {
                    y2 = y2 - Convert.ToInt32(inputs2[i].Replace("D", ""));
                }
                wire2.SetValue(x2.ToString() + "," + y2.ToString(), i+1);
            }
            Console.WriteLine("wire2: " + string.Join("/", wire2));

            int[] A1 = new int[wire1.Length];
            int[] B1 = new int[wire1.Length];
            int[] C1 = new int[wire1.Length];
            string[] firstLine= new string[wire1.Length];

            for (int i=0;i<wire1.Length-1;i++)
            {
                string[] a = wire1[i].Split(',');
                string[] b = wire1[i+1].Split(',');

                A1[i] = Convert.ToInt32(b[1]) - Convert.ToInt32(a[1]);
                B1[i] = Convert.ToInt32(a[0]) - Convert.ToInt32(b[0]);
                C1[i] = A1[i] * Convert.ToInt32(b[0]) + B1[i] * Convert.ToInt32(b[1]);

                firstLine.SetValue(A1[i].ToString()+","+B1[i].ToString() + "," + C1[i].ToString(), i);
            }
            Console.WriteLine("firstlines: " + string.Join("/", firstLine));

            int[] A2 = new int[wire2.Length];
            int[] B2 = new int[wire2.Length];
            int[] C2 = new int[wire2.Length];
            string[] secondLine = new string[wire2.Length];

            for (int i = 0; i < wire2.Length - 1; i++)
            {
                string[] a = wire2[i].Split(',');
                string[] b = wire2[i + 1].Split(',');

                A2[i] = Convert.ToInt32(b[1]) - Convert.ToInt32(a[1]);
                B2[i] = Convert.ToInt32(a[0]) - Convert.ToInt32(b[0]);

                C2[i] = A2[i] * Convert.ToInt32(b[0]) + B2[i] * Convert.ToInt32(b[1]);

                secondLine.SetValue(A2[i].ToString() + "," + B2[i].ToString() + "," + C2[i].ToString(), i);
            }
            Console.WriteLine("secondLines: " + string.Join("/", secondLine));

            string[] intersections = new string[firstLine.Length - 1];

            for (int j = 0; j < firstLine.Length-1; j++)
            {
                if (secondLine[j] != null && firstLine[j] != null)
                {
                    string[] first = firstLine[j].Split(',');
                    string[] second = secondLine[j].Split(',');

                    double delta = Convert.ToInt32(first[0]) * Convert.ToInt32(second[1]) -
                                   Convert.ToInt32(first[1]) * Convert.ToInt32(second[0]);

                    if (delta == 0)
                    {
                        //paralell
                    }
                    else
                    {
                            double x = (Convert.ToInt32(second[1]) * Convert.ToInt32(first[2]) -
                                     Convert.ToInt32(first[1]) * Convert.ToInt32(second[2])) / delta;
                            double y = (Convert.ToInt32(first[0]) * Convert.ToInt32(second[2]) -
                                     Convert.ToInt32(second[0]) * Convert.ToInt32(first[2])) / delta;

                            intersections.SetValue(x.ToString() + "," + y.ToString(), j);

                        }
                    }

            }
            
            Console.WriteLine("intersections: " + string.Join("/", intersections));

            int minDistance = 0;

            for (int j = 0; j < intersections.Length; j++)
            {
                if (intersections[j] != null)
                {
                    string[] xy = intersections[j].Split(',');
                    string[] w1 = wire1[j].Split(',');
                    string[] w2 = wire2[j].Split(',');

                    if (xy[0] != null && Convert.ToInt32(xy[0]) >=0 && Convert.ToInt32(xy[1]) >=  0)
                    {
                        if (Convert.ToInt32(xy[0]) <= Convert.ToInt32(w1[0]) && Convert.ToInt32(xy[0]) <= Convert.ToInt32(w2[0])
                        && Convert.ToInt32(xy[1]) <= Convert.ToInt32(w1[1]) && Convert.ToInt32(xy[1]) <= Convert.ToInt32(w2[1]))
                        {

                            int distance = Convert.ToInt32(xy[0]) + Convert.ToInt32(xy[1]);
                            if (minDistance == 0)
                            {
                                minDistance = distance;
                            }
                            else
                            {
                                if (distance < minDistance)
                                {
                                    minDistance = distance;
                                }
                            }

                            Console.WriteLine("minDistance: " + minDistance.ToString());
                        }

                    }
                }

            }

            Console.WriteLine("minDistance: " + minDistance.ToString());


            //https://stackoverflow.com/questions/4543506/algorithm-for-intersection-of-2-lines
            //https://www.topcoder.com/community/competitive-programming/tutorials/geometry-concepts-line-intersection-and-its-applications/

            
        }
    }
}
