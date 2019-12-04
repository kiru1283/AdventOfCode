using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            int input1 = 245318;
            int input2 = 765747;

            int num6 = (input1 / 1) % 10;
            int num5 = (input1 / 10) % 10;
            int num4 = (input1 / 100) % 10;
            int num3 = (input1 / 1000) % 10;
            int num2 = (input1 / 10000) % 10;
            int num1 = (input1 / 100000) % 10;

            //bool iscorrect = CheckRule(num1, num2, num3, num4, num5, num6);

            //Console.WriteLine("Is correct "+iscorrect.ToString());
            Console.WriteLine("Numbers: " + num1 + num2 + num3 + num4 + num5 + num6);

            loops(num1, num2, num3, num4, num5, num6);



        }
        public static void loops(int num1, int num2, int num3, int num4, int num5, int num6)
        {
            int counts = 0;
            bool resetLoop1 = false;
            bool resetLoop2 = false;
            bool resetLoop3 = false;
            bool resetLoop4 = false;
            bool resetLoop5 = false;
            for (int i = num1; i <= 7; i++)
            {
                if (resetLoop1 == true)
                {
                    num2 = 0;
                    resetLoop1 = false;
                }

                for (int j = num2; j <= 9; j++)
                {
                    if (resetLoop2 == true)
                    {
                        num3 = 0;
                        resetLoop2 = false;
                    }

                    for (int k = num3; k <= 9; k++)
                    {
                        if (resetLoop3 == true)
                        {
                            num4 = 0;
                            resetLoop3 = false;
                        }

                        for (int l = num4; l <= 9; l++)
                        {
                            if (resetLoop4 == true)
                            {
                                num5 = 0;
                                resetLoop4 = false;
                            }

                            for (int m = num5; m <= 9; m++)
                            {
                                if (resetLoop5 == true)
                                {
                                    num6 = 0;
                                    resetLoop5 = false;
                                }

                                for (int n = num6; n <= 9; n++)
                                {

                                    string number = i.ToString() + j.ToString() + k.ToString() + l.ToString() + m.ToString() + n.ToString();
                                    if (Convert.ToInt32(number) > 765747)
                                    {
                                        return;
                                    }

                                    if (CheckRule(i, j, k, l, m, n))
                                    {
                                        counts++;
                                        Console.WriteLine("counts " + counts);
                                        Console.WriteLine(number);
                                    }

                                }
                                resetLoop5 = true;

                            }
                            resetLoop4 = true;
                        }
                        resetLoop3 = true;
                    }

                    resetLoop2 = true;
                }

                resetLoop1 = true;
            }
        }

        public static bool CheckRule(int num1, int num2, int num3, int num4, int num5, int num6)
        {
            bool iscorrect = false;
            bool hasdouble = false;
            bool hasdecrease = false;
            bool hastriple = false;
            int[] doubleInts = new int[5];
            int[] numbers = new int[6] {num1, num2, num3, num4, num5, num6};
            for (int i = 0; i < 5; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    
                    hasdouble = true;
                    if(i>0)
                    {
                        if (numbers[i] == numbers[i - 1])
                        {
                            hasdouble = false;
                        }
                    }
                }

                if (i < 4)
                {
                    if (numbers[i] == numbers[i + 1] && numbers[i] == numbers[i + 2])
                    {
                        hasdouble = false;
                        hastriple = true;
                    }
                }

                if (numbers[i + 1] < numbers[i])
                {
                    hasdecrease = true;
                }

                if (hasdouble)
                {
                    foreach (int val in doubleInts)
                    {
                        if (val != numbers[i])
                        {
                            doubleInts.SetValue(numbers[i], i);
                        }
                    }
                }
                hasdouble = false;
            }

            foreach (int val in doubleInts)
            {
                if (val != 0)
                {
                    hasdouble = true;
                }
            }

            if (hasdouble)
            {
                hastriple = false;
            }

            if (hasdouble && !hasdecrease && !hastriple)
            {
                iscorrect = true;
            }

            return iscorrect;
        }
    }
}
