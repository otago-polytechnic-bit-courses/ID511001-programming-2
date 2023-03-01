using System;

namespace Dog
{
    public class Program
    {
        static bool isAnagram(string s1, string s2)
        {
            char[] charArrOne = s1.ToCharArray();
            char[] charArrTwo = s2.ToCharArray();

            Array.Sort(charArrOne);
            Array.Sort(charArrTwo);

            return charArrOne.SequenceEqual(charArrTwo);
        }

        static int convert(int minutes, int hours)
        {
            return (minutes * 60) + (hours * 3600);
        }

        static void Main(string[] args)
        {
            // Task 1 - Example 1
            {
                double[] nums = { 45.3, 67.5, -45.6, 20.34, -33.0, 45.6 };

                double sum = 0.0;

                for (int i = 0; i < nums.Length; i++)
                {
                    sum += nums[i];
                }

                double average = sum / nums.Length;

                Console.WriteLine($"The average of the numbers is {average:F2}");
            }

            // Task 1 - Example 2 (Advanced)
            {
                double[] nums = { 45.3, 67.5, -45.6, 20.34, -33.0, 45.6 };

                double average = nums.Average();

                Console.WriteLine($"The average of the numbers is {Math.Round(average, 2)}");
            }

            // Task 2 - Example 1
            {
                static string fizzBuzz(int num)
                {
                    if (num % 15 == 0)
                    {
                        return "FizzBuzz";
                    }
                    if (num % 3 == 0)
                    {
                        return "Fizz";
                    }
                    if (num % 5 == 0)
                    {
                        return "Buzz";
                    }
                    else
                    {
                        return num.ToString();
                    }
                }

                for (int i = 1; i <= 15; i += 2)
                {
                    Console.WriteLine(fizzBuzz(i));
                }
            }

            // Task 2 - Example 2
            {
                static string fizzBuzz(int num)
                {
                    string x = "";
                    if (num % 3 == 0)
                    {
                        x += "Fizz";
                    }
                    if (num % 5 == 0)
                    {
                        x += "Buzz";
                    }
                    if (x == "")
                    {
                        return num.ToString();
                    }
                    else
                    {
                        return x;
                    }
                }

                for (int i = 1; i <= 15; i += 2)
                {
                    Console.WriteLine(fizzBuzz(i));
                }
            }

            // Task 2 - Example 3
            {
                static string fizzBuzz(int num)
                {
                    string x = (num % 3 == 0 ? "Fizz" : "") + (num % 5 == 0 ? "Buzz" : "");
                    return x == "" ? num.ToString() : x;
                }

                for (int i = 1; i <= 15; i += 2)
                {
                    Console.WriteLine(fizzBuzz(i));
                }
            }

            // Task 3 - Example 1
            {
                int[] nums = { 21, 19, 68, 55, 42, 12 };

                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] % 2 == 1)
                    {
                        Console.WriteLine(nums[i]);
                    }
                }

                Array.Sort(nums);

                for (int i = 0; i < nums.Length; i++)
                {
                    Console.WriteLine(nums[i]);
                }
            }

            // Task 4
            {
                string s1 = "elvis";
                string s2 = "lives";

                if (isAnagram(s1, s2)) Console.WriteLine(true);
                else Console.WriteLine(false);
            }

            // Task 5
            {
                int minutes = 30;
                int hours = 2;
                int seconds = convert(minutes, hours);
                Console.WriteLine($"{hours} hours and {minutes} minutes = {seconds} seconds");
            }


            // Task 6
            {
                string sentence = "The anemone, the wild violet, the hepatica, and the funny little curled-up";
                string[] words = sentence.Split(' ');
                int count = 0;
                foreach (string word in words)
                {
                    if (word.ToLower() == "the") count++;
                }

                Console.WriteLine($"The or the appears {count} times in the {sentence}");
            }

            // Task 7
        }
    }
}
