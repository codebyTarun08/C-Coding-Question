using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class Program
    {
        public static bool Pallindrome(string str)
        {
            string copy = str.ToLower();
            string newStr= "";
            string[] words = copy.Split(' ');
            foreach(string word in words) {
                newStr = string.Concat(newStr,word);
                Console.WriteLine(newStr);
            }
            int start = 0;
            int end = newStr.Length - 1;
            while(start <= end)
            {
                if (newStr[start] != newStr[end])
                {
                    return false;
                }
                start++;
                end--;
            }
            return true;
        }
        public static void Reverse(int[] nums,int start,int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }
        static void Main(string[] args)
        {


            /*Array Rotaion*/
            //int[] nums = { 1, 2, 3, 4, 5 };
            //int k = 2;
            //int n = nums.Length;
            //Reverse(nums, 0, n-k-1);
            //Reverse(nums, n - k, n - 1);
            //Reverse(nums, 0, n - 1);

            //for(int i = 0; i < nums.Length; i++)
            //{
            //    Console.Write(nums[i] + ", ");
            //}

            //string str = "A man a plan a canal Panama";
            //Console.WriteLine( Pallindrome(str));

            //Console.WriteLine();

        }
    }
}
