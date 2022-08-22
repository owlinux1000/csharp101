// See https://aka.ms/new-console-template for more information
using System;
namespace FizzBuzz
{
    class Program {
        static void Main(string[] args) {
            while(true) {
                Console.Write("Input number: ");
                String? line = Console.ReadLine();
                if(line == "quit" || line == "q") {
                    break;
                }
                int n = int.Parse(line);
                String result = judge(n);
                Console.WriteLine(result);
            }
        }
        static String judge(int n) {
            String result = n.ToString();
            if(n % 15 == 0) {
                result = "FizzBuzz";
            } else if(n % 3 == 0) {
                result = "Fizz";
            } else if(n % 5 == 0) {
                result = "Buzz";
            }
            return result;
        }
    }
}
