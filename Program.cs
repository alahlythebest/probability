using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace probability
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[5] { 9, 2, 4, 10, 5 };
            Program p = new Program();

            Console.WriteLine("This is mode");
            Console.WriteLine(p.mode(arr));
            Console.WriteLine("This is range");
            int[] rang = p.range(arr);
            for (int i = 0; i < 2; i++)
            {
                Console.Write(rang[i]);
                Console.Write(" ");
            }
            Console.WriteLine();

            int temp = 0;
            for (int i = 0; i <= arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            Console.WriteLine("This is the median");
            Console.WriteLine(p.median(arr));
            Console.WriteLine("This is the first quartile");
            Console.WriteLine(p.first(arr));
            Console.WriteLine("This is the third quartile");
            Console.WriteLine(p.Third(arr));
            Console.WriteLine("This is the P90");
            Console.WriteLine(p.CalculateP90(arr));
            Console.WriteLine("This is the IQR");
            Console.WriteLine(p.IQR(arr));
            Console.WriteLine("This is the Boundries");
            
            double[] bound = p.boundries(arr);
            for (int i = 0; i < 2; i++)
            {
                Console.Write(bound[i]);
                Console.Write(" ");
            }

            Console.WriteLine();
            Console.WriteLine("insert a value to determine if the value is an outliear ir not");
            string input = Console.ReadLine();
            int value = int.Parse(input);
            Console.WriteLine(p.isoutlier(arr, value));




        }
        public double mean(int[] arr)
        {
            double ava;
            double sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum = sum + arr[i];
            }
            ava = sum / arr.Length;
            return ava;
        }
        public double median(int[] arr)
        {
            double mid;

            int half = arr.Length / 2;
            if (arr.Length % 2 == 0)
            {
                mid = (double)(arr[half] + arr[half - 1]) / 2;
            }
            else
            {
                mid = arr[half];
            }
            return mid;
        }
        public int mode(int[] arr)
        {
            int[] freq = new int[100000000];
            int max = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                freq[arr[i]]++;
            }
            int x = 0;
            for (int i = 0; i < freq.Length; i++)
            {
                if (max < freq[i])
                {
                    max = freq[i];
                    x = i;
                }
            }
            return x;
        }
        public int[] range(int[] arr)
        {
            int[] range = new int[2];

            int max = 0, min = 1000000;
            for (int i = 0; i < arr.Length; i++)
            {
                if (max < arr[i])
                {
                    max = arr[i];
                }
                if (min > arr[i])
                {
                    min = arr[i];
                }
            }
            range[0] = min;
            range[1] = max;

            return range;
        }
        public int first(int[] arr)
        {
            int middleIndex = arr.Length / 2;
            int quartileIndex = middleIndex / 2;

            if (arr.Length % 2 == 0)
            {
                return (arr[quartileIndex - 1] + arr[quartileIndex]) / 2;
            }
            else
            {
                return arr[quartileIndex];
            }
        }
        public double Third(int[] arr)
        {
            int n = arr.Length;
            double q3 = 0;
            int index = (int)(0.75 * n);
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[i])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            if (n % 4 == 0)
            {
                q3 = (double)(arr[index - 1] + arr[index]) / 2;
            }
            else
            {
                q3 = arr[index];
            }

            return q3;
        }
        public double IQR(int[] arr)
        {
            return Third(arr) - first(arr);
        }
        public double[] boundries(int[] arr)
        {
            double[] bound = new double[2];

            bound[0] = first(arr) - (1.5 * IQR(arr));
            bound[1] = Third(arr) + (1.5 * IQR(arr));

            return bound;
        }
        public bool isoutlier(int[] arr, int value) // -3.5 16.5     19
        {
            bool isout = true;

            double[] bound = boundries(arr);
            if (value > bound[0] && value < bound[1])
            {
                return false;
            }
            return isout;
        }
        public int CalculateP90(int[] arr)
        {
            int index = (int)(arr.Length * 0.9 - 1);
            return arr[index];
        }
    }
}

