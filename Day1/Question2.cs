using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Day1
{
    internal class Question2
    {
        public static int TotalSplits(int[] array,int n)
        {
            int totalSum = 0;
            foreach(int num in array)
            {
                totalSum += num;
            }
            int prefixSum = 0;
            int count = 0;
            for(int i = 0; i < n-1; i++)
            {
                prefixSum += array[i];
                int suffixSum = totalSum - prefixSum;
                if(Math.Abs(prefixSum - suffixSum) % 2 == 0)
                {
                    count++;
                }
            }
            return count;
        }

        public static int TotalSubarray(int[] A, int n)
        {
            int totalNo = 0;
            for(int i = 0; i < n-2; i++)
            {
                if( (A[i] + A[i+2]) == A[i + 1])
                {
                    totalNo++;
                }
            }
            return totalNo;
        }

        public static int[] CountSensors(int[] A,int n)
        {
            int[] result = new int[n];
            for(int i = 0; i < n; i++)
            {
                int count = 0;
                if (i == 0)
                {
                    if (A[i + 1] > A[i]) count++;
                    if (A[n - 1] > A[i]) count++;
                }
                else if (i == n - 1)
                {
                    if (A[i - 1] > A[i]) count++;
                    if (A[0] > A[i]) count++;
                }
                else
                {
                    if (A[i - 1] > A[i]) count++;
                    if (A[i + 1] > A[i]) count++;
                }
                    result[i] = count;
            }
            return result;
        }

        public static int Decoder(int num)
        {
            while (num >= 10)
            {
                int secret = 0;
                while (num > 0)
                {
                    secret += num % 10;
                    num = num / 10;
                }
                num=secret;
            }
            return num;
        }

        public static long MorrisFunction(int num)
        {
            // f(n)=f(n-1)+7*f(n-1)+(n/4)%(1e9+7)
            int[] F = new int[num+1];
            F[0] = 1;
            F[1] = 1;
            for(int i = 2; i < num+1; i++)
            {
                F[i] = F[i - 1] + (7 * F[i - 2]) + (i / 4) % 1000000007;
            }
            return F[num];
        }

        public static int StarSum(int num)
        {
            int sum = 0;
            string s = num.ToString();
            Console.WriteLine("S: "+s);
            for(int i = 1; i <= s.Length; i++)
            {
                Console.WriteLine("Convert: "+Convert.ToInt32(s.Substring(0, i)));
                sum += Convert.ToInt32(s.Substring(0, i));
            }
            Console.WriteLine(sum);
            return sum;
        }
        public static int Prefix(int N)
        {
            int count = 0;
            for(int M = 1; M<=N; M++)
            {
                if (StarSum(M) > N)
                {
                    count++;
                }
            }
            return count;
        }

        public static (int,int) PairMultiply(int[] nums,int n)
        {
            List<(int l, int r)> pair = new List<(int, int)>();
            for(int i = 0; i < nums.Length; i++)
            {
                for(int j = 0; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == 18)
                    {
                        if (nums[i] >= nums[j])
                        {
                            pair.Add((nums[i], nums[j]));
                            continue;
                        }
                        pair.Add((nums[j], nums[i]));
                    }
                }
            }
            (int l, int r) best = pair[0];
            int maxProduct = best.l*best.r;
            foreach(var p in pair)
            {
                int product = p.l*p.r;
                if(product > maxProduct)
                {
                    maxProduct = product;
                    best = p;
                }
            }
            return best;
        }

        public static void FlipkartVirus(int n)
        {
            if (n == 1 || n == 2)
            {
                Console.WriteLine(0);
            }
            if(n == 3) Console.WriteLine(1);
            int a=0; int b=0; int c=1; int d=0;
            for(int i = 4; i<=n; i++)
            {
                d= a + b + c;
                Console.WriteLine(i+" : "+d);
                a = b;
                b = c;
                c = d;
            }
            Console.WriteLine(c);
        }
        public static void Main(string[] args)
        {
            /*
             * TotalSplits
            int n = 5;
            int[] array = {10,10,3,7,6};
            int split = TotalSplits(array, n);
            Console.WriteLine(split);
            */
            /*
             * Total no. of suarrays that have size 3 and 1 + 3 == 2
            int[] array = { 1, 2, 1, 3, 5, 2, 4, 2 };
            int n = 8;
            Console.WriteLine(TotalSubarray(array, n));
            */



            /*
            int[] array = { 10, 15, 12, 9, 14 };
            int[] result = CountSensors(array,array.Length);
            foreach(int i in result)
            {
                Console.WriteLine(i);
            }
            */

            /*
            int secretNumber = 38;
            Console.WriteLine(Decoder(secretNumber));
            */

            /*
            int input = 3;
            Console.WriteLine(MorrisFunction(input));
            */

            /*
            int N = 112;
            Console.WriteLine(Prefix(N));
            */

            /*
             * 
            int[] nums = { 11, 1 , 2, 8, 10 , 11, 15, 7 };
            int n = 8;
            Console.WriteLine(PairMultiply(nums,n));
            */
            FlipkartVirus(11);
            Console.ReadLine();

        }
    }
}
