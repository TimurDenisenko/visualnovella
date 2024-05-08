using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace visualnovella
{
    internal class hueta
    {
        string lbl_exercise = "Task: Calculating the sum of numbers\r\n\r\nYour friend is planning a party and decided to make it more interesting by holding a competition for the most creative pair of numbers. He wants to create a program that will allow participants to quickly find out the sum of any pair of numbers. You are asked to write such a program.";

        string lbl = "    using System;\r\n    public class FunctionReturnValue\r\n    {\r\n        public static void Main(string[] args)\r\n        {\r\n            int x = Convert.ToInt32(Console.ReadLine());\r\n            int y = Convert.ToInt32(Console.ReadLine());\r\n     \r\n            int sum = Sum(x, y);\r\n            Console.WriteLine(sum);\r\n        }\r\n     \r\n        public static int Sum(int x, int y)\r\n        {\r\n            return x + y;\r\n        }\r\n    }";


        string lbl2_exercise = "Task: Calculating the sum of numbers in an array\r\n\r\nYou are developing a financial accounting program. Your program should allow the user to enter expenses for a week (5 days) and output the total amount of expenses.\r\n\r\nClue:\r\n\r\n Use an array to store daily expenses.\r\n Enter expense data for each day of the week using a cycle.\r\n Use the Sum function to find the total amount of expenses.\r\n Print the total amount of expenses.";
        string lbl2 = "    using System;\r\n    public class FunctionAddArrayIntegers\r\n    {\r\n        public static void Main(string[] args)\r\n        {\r\n            int total = 5;\r\n            int[] numbers = new int[total];\r\n     \r\n            for (int i = 0; i < total; i++)\r\n            {\r\n                numbers[i] = Convert.ToInt32(Console.ReadLine());\r\n            }\r\n     \r\n            int sum = Sum(numbers);\r\n            Console.WriteLine(sum);\r\n        }\r\n     \r\n        public static int Sum(int[] numbers)\r\n        {\r\n            int sum = 0;\r\n     \r\n            for (int i = 0; i < numbers.Length; i++)\r\n            {\r\n                sum += numbers[i];\r\n            }\r\n     \r\n            return sum;\r\n        }\r\n    }";

        string lbl3_exercise = "Problem: Doubling a number\r\n\r\nYou are writing a program to double an entered number. Your program should read an integer from the keyboard and print twice its value.\r\n\r\nHint: You need to write a Double function that takes one argument, a number, and returns double its value. You need to use this function in the main part of the program to process the entered number.";
        string lbl3 = "    using System;\r\n    public class FunctionCalculateDouble\r\n    {\r\n        public static void Main(string[] args)\r\n        {\r\n            int number = Convert.ToInt32(Console.ReadLine());\r\n     \r\n            Console.WriteLine(Double(number));\r\n        }\r\n     \r\n        public static int Double(int number)\r\n        {\r\n            return number + number;\r\n        }\r\n    }";

        string lbl4_exercise = "Task: Counting spaces in a string.\r\n\r\nDescription: Write a program that counts the number of spaces in a string entered by the user and displays the result on the screen.\r\n\r\nTip: To count spaces in a string, you can use a for loop and the Substring method to access the string character by character. You can use a string or char variable to store the current character. The space counter can be initialized to zero and incremented when a white space character is encountered.";
        string lbl4 = "    using System;\r\n    public class FunctionCountSpaces\r\n    {    \r\n        public static void Main(string[] args)\r\n        {\r\n            string text = Console.ReadLine();\r\n     \r\n            int countSpaces = CountSpaces(text);\r\n            Console.WriteLine(countSpaces);\r\n        }\r\n     \r\n        public static int CountSpaces(string text)\r\n        {\r\n            int count = 0;\r\n            string letter;\r\n     \r\n            for (int i = 0; i < text.Length; i++)\r\n            {\r\n                letter = text.Substring(i, 1);\r\n     \r\n                if (letter == \" \")\r\n                {\r\n                    count++;\r\n                }\r\n            }\r\n     \r\n            return count;\r\n        }\r\n    }";
    }
}

