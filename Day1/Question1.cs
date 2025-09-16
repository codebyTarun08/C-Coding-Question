using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day1
{
    internal class Question1
    {
        public static string ExpandInput(string input)
        {
            Dictionary<char,int> firstIndex = new Dictionary<char, int>();
            List<string> list = new List<string>();

            for(int i = 0; i < input.Length; i++)
            {
                char ch = input[i];

                if (!firstIndex.ContainsKey(ch))
                {
                    firstIndex.Add(ch, i + 1);
                }
                int repeatCount = firstIndex[ch];
                list.Add(new string(ch, repeatCount));
            }
            return string.Join("-",list);
        }

        public static int CostRequired(string str1, string str2)
        {
            Dictionary<char, int> freq1 = new Dictionary<char, int>();
            Dictionary<char, int> freq2 = new Dictionary<char, int>();

            // Frequency of str1
            foreach (char c in str1)
            {
                if (!freq1.ContainsKey(c))
                    freq1[c] = 0;
                freq1[c]++;
            }

            // Frequency of str2
            foreach (char c in str2)
            {
                if (!freq2.ContainsKey(c))
                    freq2[c] = 0;
                freq2[c]++;
            }

            int cost = 0;

            // Compare and calculate missing characters
            foreach (var entry in freq2)
            {
                char c = entry.Key;
                int needed = entry.Value;                       // from str2
                int available = freq1.ContainsKey(c) ? freq1[c] : 0;

                if (needed > available)
                {
                    cost += (needed - available);
                    Console.WriteLine($"➡ Need {needed - available} more '{c}'");
                }
            }

            Console.WriteLine("✅ Extra characters in str1 can be removed (cost 0).");

            return cost;
        }

        public static int MaximumPermutation(string[] str, int n)
        {
            int maxLen = 0;

            foreach (string s in str)
            {
                string noVowels = "";

                // Remove vowels manually
                foreach (char c in s)
                {
                    if (!(c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u'))
                    {
                        noVowels += c; // build new string without vowels
                    }
                }

                // Update max length
                maxLen = Math.Max(maxLen, noVowels.Length);
            }

            // Compute factorial of maxLen
            if (maxLen > 0)
            {
                int fact = 1;
                for (int i = 1; i <= maxLen; i++)
                {
                    fact *= i;
                }
                return fact;
            }

            return 0;
        }

        public static int Permutation(int n)
        {
            int per = 1;
            for(int i = 1; i <= n; i++)
            {
                per= per*i;
            }
            return per;
        }
        public static int countPermutations(string str)
        {
          
            string consonant= Regex.Replace(str, "[aeiouAEIOU]", "");
            Console.WriteLine(consonant);
            if(consonant.Length != str.Length)
            {
                return Permutation(consonant.Length);
            }
            return 0;
        }

        public static string MostOccurringPair(string str)
        {
            Dictionary<string,int> freq = new Dictionary<string,int>();
            string[] words = str.Split(' ');
            foreach (string word in words)
            {
                string pair = $"{word[0]}{word[word.Length - 1]}";
                if (!freq.ContainsKey(pair))
                {
                    freq[pair] = 1;
                }
                else
                {
                    freq[pair]++;
                }
            }
            int max = freq.Values.Max();
            foreach (var pair in freq.Keys) { 
                if(freq[pair] > max)
                {
                    return pair;
                }else if (freq[pair] == max)
                {
                    return pair;
                } 
            }
            return "";
        }

        public static int AbsoluteDifference(string str)
        {
            Dictionary<char,int> freq=new Dictionary<char,int>();
            foreach(char c in str)
            {
                if (!freq.ContainsKey(c))
                {
                    freq[c] = 1;
                }
                else
                {
                    freq[c]++;
                }
            }
            int maxOdd = Int32.MinValue;
            int minEven = Int32.MaxValue;
            foreach(int count in freq.Values)
            {
                Console.WriteLine("Count: "+ count);
                if (count % 2 == 0) minEven = Math.Min(minEven, count);
                else maxOdd = Math.Max(maxOdd, count);
            }
            Console.Write("Odd"+maxOdd);
            Console.WriteLine("minEVEN"+minEven);
            int diff = Math.Abs(maxOdd-minEven);
            return diff;
        }


        public static int LoanWaveOff(int n,int[,] loans)
        {
            Dictionary<int,int> frequency =new Dictionary<int,int>();
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    int value = loans[i, j];
                    if(value>0)
                        if(!frequency.ContainsKey(value))
                            frequency[value] = 1;
                        else
                            frequency[value]++;
                }
            }

            foreach( int key in frequency.Keys)
            {
                if(frequency[key] == 1)
                {
                    return key;
                }
            }
            return 0;
        }

        public static int MaximumAlphabet(int n ,string str)
        {
            Dictionary<char,int> freq1 = new Dictionary<char,int>();
            Dictionary<int,int>  freq2 = new Dictionary<int,int>();
            foreach(char c in str)
            {
                if (!freq1.ContainsKey(c))
                {
                    freq1[c] = 1;
                }
                else
                {
                    freq1[c]++;
                }
            }
            foreach(int value in freq1.Values)
            {
                if (!freq2.ContainsKey(value))
                    freq2[value] = 1;
                else
                    freq2[value]++;
            }
            int maxFreq = freq2.Values.Max();
            return freq2
                   .Where(kvp => (kvp.Value == maxFreq))
                   .Select(kvp =>kvp.Key)
                   .Min();
        }

        public static int MinCost(int N,int P,int Q)
        {
            int B = 80,S=8;
            int busrep = N / B;
            int rem = N % B;
            int shuttleRep = (rem != 0) ? (rem/S)+1 : 0;
            int totalCost = busrep * P * 75 + shuttleRep * Q * 75;
            return totalCost;
        }

        public static int SumOfTallBuilding(int n, int[] height,int D)
        {
            List<int> tallBuilding = new List<int>();
            for(int i = 0; i < n; i++)
            {
                int tall1 = i - D;
                int tall2 = i + D;
                bool left = (tall1 < 0) || (height[i] > height[tall1]);
                bool right = (tall2>=n-1) || (height[i] < height[tall2]);
                if(left && right)
                {
                    tallBuilding.Add(height[i]);
                }
            }
            foreach (int i in tallBuilding)
            {
                Console.WriteLine(i);
            }
            int sum = tallBuilding.Sum();
            return sum!=0 ? sum : 0;
        }

        public static int CountOfDigitSurroundedByLetters(string str)
        {
            int n = str.Length;
            int start=-1, end=-1;
            int count = 0;
            for(int i=0;i<n;i++)
            {
                if (Char.IsDigit(str[i]))
                {
                    start = i++;
                    while (Char.IsDigit(str[i])) end = i++;

                    if (Char.IsLetter(str[start - 1]) && Char.IsLetter(str[end + 1]))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public static string ReplaceConsecutiveLetter(string str)
        {
            //string str = "aabbbccdeeea";  o/p : #d#a
            int i = 0;
            StringBuilder sb = new StringBuilder();
            while(i<str.Length)
            {
                char current = str[i];
                int j = i;
                while(j<str.Length && str[j] == current)
                {
                    j++;
                }
                if (j - i >=2)
                {
                    if (sb.Length == 0 || sb[sb.Length - 1] != '#')
                        sb.Append("#");
                }
                else if(j-i==1)
                {
                    sb.Append(current);
                }
                i = j;
            }
                
            return sb.ToString();
        }

        public static int AbsoluteDifferenceInTyping(string str)
        {
            if (string.IsNullOrEmpty(str)) return 0;
            int distance = 0;
            for (int i = 1; i < str.Length; i++)
            {
                int firstIndex = str[i - 1] - 'a';
                int currentIndex = str[i] - 'a';
                int absDiff = Math.Abs(currentIndex - firstIndex);
                distance += absDiff;
            }
            return distance;
        }

        public static int MinimumConversion(string str)
        {
            int diff1 = 0; // assuming pattern "XYXY..."
            int diff2 = 0; // assuming pattern "YXYX..."

            for (int i = 0; i < str.Length; i++)
            {
                char expected1 = (i % 2 == 0) ? 'X' : 'Y';
                char expected2 = (i % 2 == 0) ? 'Y' : 'X';

                if (str[i] != expected1) diff1++;
                if (str[i] != expected2) diff2++;
            }

            return Math.Min(diff1, diff2);
        }

        public static long StockValue(string str)
        {
            //string str = "Apple:250:10;Banana:120:15;Orange:300:5";
            
            int result = 0;
            string[] product = str.Split(';');
            for(int i  = 0; i < product.Length; i++)
            {
                string[] values = product[i].Split(':');
                int val = 1;
                for (int j = 1; j < values.Length; j++)
                {
                    val *= Int32.Parse(values[j]);
                }
                result += val;
            }
            return result;
        }

        public static int NoOfDogs(string str)
        {
            HashSet<string> hs = new HashSet<string>();
            string[] barks = str.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string bark in barks)
            {
                hs.Add(bark);
            }

            return hs.Count;
        }

        public static int NoOfReg(int n , string[] reg , string start , string end)
        {
            string format = "dd-MM-yyyy";
            CultureInfo provider = CultureInfo.InvariantCulture;

            // Parse the start and end dates
            DateTime startDate = DateTime.ParseExact(start, format, provider);
            DateTime endDate = DateTime.ParseExact(end, format, provider);

            int count = 0;

            foreach (string r in reg)
            {
                DateTime regDate = DateTime.ParseExact(r, format, provider);

                if (regDate >= startDate && regDate <= endDate)
                {
                    count++;
                }
            }

            return count;
        }

        public static int TotalPulseSkipCount(int N, int[] A)
        {
            Stack<(int value,int skip)> st = new Stack<(int, int)>();
            int totalSkips = 0;
            for(int i = 0; i < N; i++)
            {
                int skipCount = 0;
                while(st.Count>0 && A[i] >= st.Peek().value)
                {
                    st.Pop();
                    skipCount++;
                }
                totalSkips += skipCount;

                st.Push((A[i], skipCount));
            }
            return totalSkips;
        }

        public static int CountChars(int n,int[] digits,string str)
        {
            int count = 0;
            HashSet<int> hs = new HashSet<int>();
            foreach(int i in digits)
            {
                hs.Add(i);
            }
            foreach(char c in str.ToCharArray())
            {
                int ascii = (int)c;
                char[] dig = ascii.ToString().ToCharArray();
                foreach(char val in dig)
                {
                    int num = val - '0';
                    if (hs.Contains(num))
                    {
                        count++;
                        break;
                    }
                }
            }
            return count;
        }

        public static string ModifyString(string str)
        {
            char[] result = str.ToCharArray();
            int n = str.Length;
            for(int i=0; i < n; i++)
            {
                int pos = (result[i] - 'a') + 1;
                int root = (int) Math.Sqrt(pos);
                if(root*root == pos)
                {
                    int k = root;
                    char newChar = (char)('a' + k - 1);

                    bool hasNeighbor = false;
                    if(i>0 && result[i-1]==newChar) 
                        hasNeighbor = true;
                    if(i<n-1 && result[i+1]==newChar) { hasNeighbor = true; }

                    if (!hasNeighbor)
                    {
                        result[i] = newChar;
                    }
                }
            }
            return new string(result);
        }

        public static int WrappedItems(string str)
        {
           char[] payload = str.ToCharArray();
            int count = 0;
            for (int i = 0; i < str.Length-1; i++) 
            {
                if (Char.IsLetter(payload[i])){
                    if(Char.IsDigit(payload[i-1]) && Char.IsDigit(payload[i + 1]))
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public static int HomogeneousCount(string str)
        {
            int count = 0;
            int i = 0;
            int layerSize = 1;
            while (i + layerSize <= str.Length)
            {
                string layer = str.Substring(i, layerSize);
                bool isHomogeneous = true;
                for (int j = 0; j < layer.Length; j++)
                {
                    if (layer[j] != layer[0])
                    {
                        isHomogeneous = false;
                        break;
                    }
                }

                if (isHomogeneous) {
                    count++;
                }
                i += layerSize;
                layerSize++;
            }
            return count;
        }


        public static void CountString(string str)
        {
            int Alphabet = 0;
            int Digit = 0;
            int SpecialCharacter = 0;
            int WhiteSpace = 0;
            foreach(char c in str)
            {
                if(Char.IsLetter(c)) Alphabet++;
                if(Char.IsDigit(c)) Digit++;
                //if(!Char.IsLetterOrDigit(c) && !Char.IsWhiteSpace(c)) SpecialCharacter++;
                if(Char.IsWhiteSpace(c)) WhiteSpace++;
            }
            SpecialCharacter = str.Count(c => (!Char.IsLetterOrDigit(c) && !Char.IsWhiteSpace(c)));
            Console.WriteLine(Alphabet);
            Console.WriteLine(Digit);
            Console.WriteLine(WhiteSpace);
            Console.WriteLine(SpecialCharacter);
        }

        public static List<char> GradeList(int n , int[] Marks)
        {
            List<char> gradeList = new List<char>();
            foreach(int mark in Marks)
            {
                if(mark>=10 && mark <= 40) { gradeList.Add('F'); }
                if (mark >= 41 && mark <= 50) { gradeList.Add('C'); }
                if (mark >= 51 && mark <= 60) { gradeList.Add('B'); }
                if (mark >= 61 && mark <= 80) { gradeList.Add('A'); }
                if (mark >= 81 && mark <= 100) { gradeList.Add('S'); }
            }
            return gradeList;
        }

        public static void String2OccurenceInString1(string str1,string str2)
        {
            string[] words=str1.Split(' ');
            int count = 0;
            foreach(string word in words)
            {
                if(word == str2)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }

        public static void MagicalBoard(string s)
        {
            string magicalString = "";
            for(int i = 0; i < 4; i++)
            {
                int num=int.Parse(s.Substring(i * 2,2));
                magicalString+=Convert.ToChar(num);
            }
            Console.WriteLine(magicalString);
        }
        public static void GetTotalTicketAmount()
        {
            Console.WriteLine("Enter The No of Tickets");
            int tickets=int.Parse(Console.ReadLine());
            if(tickets<5 || tickets > 40)
            {
                Console.WriteLine("Minimum 5 or maximum 40");
            }
            Console.WriteLine("Do you want Refreshment?");
            string refresh = Console.ReadLine().ToLower().Trim();

            Console.WriteLine("Do you have Coupan");
            string coupan= Console.ReadLine().ToLower().Trim();

            Console.WriteLine("Enter the class of ticket");
            string TicketClass = Console.ReadLine().ToLower().Trim().Substring(0,1);
            double ticketPrice=1;
            if (TicketClass == "k")
                ticketPrice = 75;
            else if (TicketClass == "q")
                ticketPrice = 150;
            else
                Console.WriteLine("Invalid Input");

            double total=tickets*ticketPrice;
            if (tickets > 20)
                total *= 0.9;
            if (coupan == "y")
                total *= 0.98;
            if (refresh == "y")
                total += tickets * 50;

            Console.WriteLine(total);

        }
        public static void Main(string[] args)
        {
            /*
             * expand equal to first index
            string input = "abcaba";
            string output = ExpandInput(input);
            Console.WriteLine(output);
            */

            /*
            string str1 = "ABD";
            string str2 = "AABCCAD";

            Console.WriteLine("value: " + CostRequired(str1, str2));

            string str3 = "ABC";
            string str4 = "XYZ";

            Console.WriteLine("value: " + CostRequired(str3, str4));
            */

            /*
             * Maximum Permutation after removing vowels from string 
            string[] arr = {"eio"}; //  "apple", "orange", "sky" o/p 6
            int result = MaximumPermutation(arr, arr.Length);

            Console.WriteLine("Result: " + result);
            */

            /*Count Permutation after removing vowel
            string s = "abc";
            Console.WriteLine(countPermutations(s));
            */

            //Console.WriteLine(5 | 9);

            /*
             * Return the mostOcurring pair of start and last character of word in sentences
             Console.WriteLine(MostOccurringPair("she is good grid god and ground player plotter"));
            */


            /*
             * Return Absolute Difference of maxOdd frequency and minEven frequency of character
            string str = "aartfffu";
            Console.WriteLine(AbsoluteDifference(str)); 
            */

            /*
            int n = 3;
            //int[,] loans = { { -1, 1, 3 }, { 2, 3, 4 }, { 3, 4, 5 } }; O/p : 1
            int[,] loans = { { -1, 2, 3 }, { 2, 3, 4 }, { 3, 4, 5 } };
            Console.WriteLine(LoanWaveOff(n, loans));
            */

            /*
                int n = 9;
                string str = "ACABABCCA"; O/p : 2
                
            int n = 20;
            string str = "ACABDDABDCDACFAEGFDA";
            Console.WriteLine(MaximumAlphabet(n,str));
            */

            // Console.WriteLine(MinCost(185,70,15)); //140*75+4*15*75

            /*
            int n = 6;
            int[] height = { 1, 3, 2, 1, 5, 4 };
            int D = 2;
            Console.WriteLine(SumOfTallBuilding(n, height, D));
            int[] h = { 2, 1 };
            Console.WriteLine(SumOfTallBuilding(2,h, 1));
            */

            //Console.WriteLine(CountOfDigitSurroundedByLetters("a123d2f"));

            /*
             * Replace consecutive same subsequence with # 
            string str = "aabbbccdeeea";
            Console.WriteLine(ReplaceConsecutiveLetter(str));
            */

            /*
            //string str = "cba";
            //string str = "pqrt";
            string str = "qrty";
            Console.WriteLine(AbsoluteDifferenceInTyping(str));
            */

            /*
            string str = "XXYYXXY";
            Console.WriteLine(MinimumConversion(str));
            */
            /*
            string str = "Apple:250:10;Banana:120:15;Orange:300:5";
            Console.WriteLine(StockValue(str));
            */

            /*
             * return no of dogs at street recognize by barking pattern
            string S = "B...B...BB...B....BBB";
            Console.WriteLine(NoOfDogs(S));
            */

            /*
             * Calculate no of registrations done b/w start & end
            string [] registration = {
                                       "01-01-2023", "10-01-2023", "05-02-2023",
                                       "25-12-2022", "03-01-2023", "01-03-2023"
                                     };
            int n = 6;
            string start= "01-01-2023";
            string end= "31-01-2023";
            Console.WriteLine(NoOfReg(n, registration, start, end)); 
            */

            /*
             * total pulse skip count in stack
            int n = 6;
            int[] a = { 3, 1, 4, 2, 5, 1 };
            Console.WriteLine(TotalPulseSkipCount(n, a));
            */

            /*
            int n = 6;
            int[] digits = { 1, 6, 4, 3, 6, 5 };
            string str = "ABCDEF";
            Console.WriteLine(CountChars(n, digits,str));
            */

            /*
            string str = "abcd";
            Console.WriteLine(ModifyString(str));
            */

            /*
            //string str = "1a2b3c4d5";
            string str = "5aart6i7io8o5o56";
            Console.WriteLine(WrappedItems(str));
            */

            /*
            string homoStr = "aaabbbcccdddddd";
            Console.WriteLine(HomogeneousCount(homoStr));
            */
            /*
            CountString("Amcatuff@ #% 123");
            */

            /*
            int[] marks = { 84, 61, 51, 41, 11 };
            List<char> grades = GradeList(5,marks);
            foreach (char mark in grades)
            {
                Console.Write(mark + " ,");
            }
            */
            /*
            String2OccurenceInString1("Always Joe in Friends Joe with Joe Joe", "Joe");
            */
            /*
            MagicalBoard("65666768");
            */

            GetTotalTicketAmount();
            Console.ReadLine();
        }
    }
}
