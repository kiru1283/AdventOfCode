using System;

namespace AdventOfcode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string input = "1,0,0,3,1,1,2,3,1,3,4,3,1,5,0,3,2,6,1,19,1,19,10,23,2,13,23,27,1,5,27,31,2,6,31,35,1,6,35,39,2,39,9,43,1,5,43,47,1,13,47,51,1,10,51,55,2,55,10,59,2,10,59,63,1,9,63,67,2,67,13,71,1,71,6,75,2,6,75,79,1,5,79,83,2,83,9,87,1,6,87,91,2,91,6,95,1,95,6,99,2,99,13,103,1,6,103,107,1,2,107,111,1,111,9,0,99,2,14,0,0";
           // Calculate(input);
            CalculateInputs(input);
        }

        public static string[] Calculate(string input)
        {

            string[] numbers = input.Split(',');
            int position1 = 0;
            int position2 = 0;
            int position3 = 0;
            int input1 = 0;
            int input2 = 0;
            int output = 0;

            for (int i = 0; i < numbers.Length-1; i = i + 4)
            {
                if (numbers[i] == "99")
                {
                    break;
                }
                else
                {
                    position1 = Convert.ToInt32(numbers[i + 1]);
                    position2 = Convert.ToInt32(numbers[i + 2]);
                    position3 = Convert.ToInt32(numbers[i + 3]);
                    input1 = Convert.ToInt32(numbers[position1]);
                    input2 = Convert.ToInt32(numbers[position2]);

                    Console.WriteLine("pos1:" + position1 + ", pos2:" + position2 + ", input1:" + input1 + ", input2:" + input2);

                    if (numbers[i] == "1")
                    {
                        output = input1 + input2;
                    }
                    if (numbers[i] == "2")
                    {
                        output = input1 * input2;
                    }


                    numbers[position3] = output.ToString();

                    Console.WriteLine("output:" + output.ToString());                    
                }
            }

            string outputNumbers = string.Join(",",numbers);

            Console.WriteLine("outputarray:" + outputNumbers);

            return numbers;
        }


        public static void CalculateInputs(string input)
        {
            string[] outputNumbers = input.Split(',');

            bool isfound = false;

            for (int i = 1; i <= 99; i++)
            {
                for (int j = 1; j <= 99; j++)
                {
                    string[] numbers = input.Split(',');

                    numbers[1] = j.ToString();
                    numbers[2] = i.ToString();

                    string inputString = string.Join(",", numbers);

                    outputNumbers = Calculate(inputString);

                    if (outputNumbers[0] == "4138687")
                    {
                        isfound = true;
                        break;
                    }

                }

                if (isfound)
                {
                    break;
                }

            }

            Console.WriteLine("pos1:" + outputNumbers[1] + ", pos2:" + outputNumbers[2] + ", output:" + (100*Convert.ToInt32(outputNumbers[1])+ Convert.ToInt32(outputNumbers[2])).ToString());

        }

     }
}
