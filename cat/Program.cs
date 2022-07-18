// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
namespace cat;
class Program {
    static void Main(string[] args) {

        // Read from Stdin
        if(args.Length == 0) {
            string s = Console.ReadLine();
            while(s != null) {
                Console.WriteLine(s);
                s = Console.ReadLine();
            }
        } else {
            string path = args[0];
            if(File.Exists(path)) {
                string s = File.ReadAllText(path);
                Console.Write(s);
            } else {
                Console.WriteLine("Not found");
            }
        }
    }
}

