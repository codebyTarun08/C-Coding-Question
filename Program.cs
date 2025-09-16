using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Single Line Comment - Hello World Print karne Ke liye with new line
            Console.WriteLine("Hello World");
            Console.Write("Hello World without new line");

            // Data Types in C#
            int a = 10;
            float b = 20.5F;
            double c = 20.2;
            char d= 'A';
            string s= "Hello";
            bool isTrue = true; // false

            /*
             * Multiple Line Comment
             * Console.WriteLine("Integer: " , a);
             * Keval Integer string print karega
             */
            Console.WriteLine("Integer: "+ a);
            Console.WriteLine("FLoating Number: "+ b);
            Console.WriteLine("Double DataType: "+ c);
            Console.WriteLine("Characater: "+ d);
            Console.WriteLine("String: "+ s);
            Console.WriteLine("boolean: " + isTrue);
            /* Taking Input From User 
            string name;
            Console.WriteLine("Enter Your Name: ");
            name = Console.ReadLine();
            Console.WriteLine("Your Name is: " + name);
            */

            /*Type Casting in C#
             * There are two type of Type Casting
             * 1. Implicit Type Casting
             * 2. Explicit Type Casting
             */

            /* Implicit Type Casting - done by compiler automatically
             * char -> int -> long -> float -> double [smaller to larger] - Conversion hoti hai
             */
            int j = 10;
            float num = j;
            Console.WriteLine("Implicit Type Casting: " + num);

            /* Explicit Type Casting - done by programmer manually
             * double -> float -> long -> int -> char [larger to smaller] - Conversion hoti hai
             */
            int l = (int)20.8;
            Console.WriteLine("Explicit Type Casting: " + l);
            char k = (char)650; // ASCII value of 650 is ?
            Console.WriteLine("Explicit Type Casting: " + k);

            /* Type Casting using Convert Class methods
             * Convert Class ke methods ka use karke bhi hum type casting kar sakte hain
             * Convert.ToInt32() - float, double, string to int
             * Convert.toInt64() - float, double, string to long
             * Convert.ToDouble() - int, float, string to double
             * Convert.ToString() - int, float, double to string
             * Convert.ToChar() - int to char
             */
            int convertInt = Convert.ToInt32(20.4);
            double convertDouble = Convert.ToDouble("1322.45");
            Console.WriteLine("Convert TO INT32: " + convertInt);
            Console.WriteLine("Convert TO double: " + convertDouble);

            /* Type Casting using Parse method
             * Parse method ka use karke bhi hum type casting kar sakte hain
             * int.Parse() - string to int
             * double.Parse() - string to double
             * float.Parse() - string to float
             */

            /* User Input */
            Console.WriteLine("How many candies do you want ?");
            string candies = Console.ReadLine();
            Console.WriteLine("You will get: " + (Convert.ToInt32(candies) + 4) );

            /* Operators in C#
             * 1. Arithmetic Operators - +, -, *, /, %
             * 2. Assignment Operators - =, +=, -=, *=, /=
             * 3. Comparison Operators - ==, !=, >, <, >=, <=
             * 4. Logical Operators - &&, ||, !
             * 5. Bitwise Operators - &, |, ^, ~, <<, >>
             */

            int p = 10;
            int q= 20;
            Console.WriteLine("Arithmetic Operators: ");
            Console.WriteLine("Addition: " + (p + q));
            Console.WriteLine("Subtraction: " + (p - q)); 
            Console.WriteLine("Multiplication: " + (p * q));
            Console.WriteLine("Division: " + (p / q));
            Console.WriteLine("Modulus: " + (p % q));

            Console.WriteLine("Comparison Operators: ");
            Console.WriteLine("Equal to: " + (p == q));
            Console.WriteLine("Not Equal to: " + (p != q));
            Console.WriteLine("Greater than: " + (p > q));
            Console.WriteLine("Less than: " + (p < q));
            Console.WriteLine("Greater than or Equal to: " + (p >= q));
            Console.WriteLine("Less than or Equal to: " + (p <= q));

            Console.WriteLine("Logical Operators: ");
            Console.WriteLine("Logical AND: " + (true && false));
            Console.WriteLine("Logical OR: " + (true || false));
            Console.WriteLine("Logical NOT: " + (!true));

            Console.WriteLine("Bitwise Operators: ");
            Console.WriteLine("Bitwise AND: " + (5 & 3)); // 0101 & 0011 = 0001 = 1
            Console.WriteLine("Bitwise OR: " + (5 | 3)); // 0101 | 0011 = 0111 = 7
            Console.WriteLine("Bitwise XOR: " + (5 ^ 3)); // 0101 ^ 0011 = 0110 = 6
            Console.WriteLine("Bitwise NOT: " + (~5)); // ~0101 = 1010 = -6
            Console.WriteLine("Left Shift: " + (5 << 1)); // 0101 << 1 = 1010 = 10
            Console.WriteLine("Right Shift: " + (5 >> 1)); // 0101 >> 1 = 0010 = 2

            /* Conditional Statements in C#
             * 1. if
             * 2. if-else
             * 3. if-else-if
             * 4. switch
             */
            Console.WriteLine("Enter Your Age: ");
            string age = Console.ReadLine();
            int ageInt = Convert.ToInt32(age);
            if(ageInt < 18)
            {
                Console.WriteLine("You are a minor.");
            }
            else if (ageInt >= 18 && ageInt < 60)
            {
                Console.WriteLine("You are an adult.");
            }
            else
            {
                Console.WriteLine("You are a senior citizen.");
            }

            //Switch Case

            /*
            Console.WriteLine("Enter Your Age: ");
            string age2 = Console.ReadLine();
            int ageInt2 = Convert.ToInt32(age);
            switch(ageInt2)
            {
                case 0:
                    Console.WriteLine("You are not born yet.");
                    break;
                case 1:
                    Console.WriteLine("You are a baby.");
                    break;
                case 2:
                    Console.WriteLine("You are a toddler.");
                    break;
                case 3:
                    Console.WriteLine("You are a kid.");
                    break;
                case 4:
                    Console.WriteLine("You are a child.");
                    break;
                case 5:
                    Console.WriteLine("You are a pre-teen.");
                    break;
                case 6:
                    Console.WriteLine("You are a teenager.");
                    break;
                case 7:
                    Console.WriteLine("You are an adult.");
                    break;
                default:
                    Console.WriteLine("You are a senior citizen.");
                    break;
            }
            */

            /* Loops in C#
             * 1. for
             * 2. while
             * 3. do-while
             * 4. foreach
             */

            int n = 10;
            Console.WriteLine("For Loop: ");
            int g2;
            for (g2 = 0; g2 < n; g2++)
            {
                Console.WriteLine(g2 + 1);
            }

            Console.WriteLine("While Loop: ");
            int i = 0;
            while (i <= n)
            {
                Console.WriteLine(i++);
            }

            Console.WriteLine("Do-While Loop: ");
            i = 0;
            do
            {
                Console.WriteLine(i);
                i++;
            } while (i <= n);

            Console.WriteLine("Foreach Loop: ");
            string[] fruits = { "Apple", "Banana", "Mango", "Orange" };
            foreach (string fruit in fruits)
            {
                Console.Write(fruit + " ,");
            }


            Console.WriteLine("String Methods in C#");
            /*
             * 1. Length - returns the length of the string
             * 2. ToUpper() - converts the string to uppercase
             * 3. ToLower() - converts the string to lowercase
             * 4. Substring() - returns a substring of the string
             * 5. Replace() - replaces a substring with another substring
             * 6. Split() - splits the string into an array of substrings
             * 7. Trim() - removes leading and trailing whitespace from the string
             * 8. IndexOf() - returns the index of the first occurrence of a substring
             * 9. LastIndexOf() - returns the index of the last occurrence of a substring
             * 10. Contains() - returns true if the string contains a substring
             * 11. StartsWith() - returns true if the string starts with a substring
             * 12. EndsWith() - returns true if the string ends with a substring
             * 13. IsNullOrEmpty() - returns true if the string is null or empty
             * 14. IsNullOrWhiteSpace() - returns true if the string is null or whitespace
             * 15. Concat() - concatenates two or more strings
             * 16. Join() - joins an array of strings into a single string
             * 17. Format() - formats a string using placeholders
             * 18. Compare() - compares two strings
             * 19. CompareTo() - compares the current string with another string
             * 20. ToCharArray() - converts the string to a char array
             * 21. PadLeft() - pads the string on the left with a specified character
             * 22. PadRight() - pads the string on the right with a specified character
             * 23. Remove() - removes a substring from the string
             * 24. Insert() - inserts a substring at a specified index
             * 25. Reverse() - reverses the string
             * 26. Normalize() - normalizes the string to a specified form
             */
            string str = "Hello Man, Welcome to C# Programming";

            Console.WriteLine("Length: " + str.Length);
            Console.WriteLine("IN UPPER CASE: " + str.ToUpper());
            Console.WriteLine("In Lower Case: " + str.ToLower());
            Console.WriteLine("Substring: " + str.Substring(2));

            string str2 = "        Trimmed String      ";
            Console.WriteLine("Trim: " + str2.Trim());

            string str3 = "I LOVE YOU";
            string[] arrayString = str3.Split(' ');
            Console.WriteLine("split: ");
            foreach (string s1 in arrayString)
            {
                Console.WriteLine(s1);
            }
            string strConcat = string.Concat(str2,str3);
            Console.WriteLine("Concat: " + strConcat);
            Console.ReadLine();
        }
    }
}