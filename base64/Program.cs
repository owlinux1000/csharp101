using System;
namespace base64;

class Program {
    static void Main(string[] args) {
        Random r = new System.Random();
        for(int i = 0; i < 10; i++) {
            string random = Guid.NewGuid().ToString("N").Substring(0, r.Next(10,15));
            if(compare(random)) {
                Console.WriteLine("Passed");
            } else {
                Console.WriteLine("Failed");
            }
        }
    }
    
    static bool compare(string random) {
        var base64 = new Base64();
        string encoded = base64.Encode(random);
        string decoded = base64.Decode(encoded);
        return random == decoded;
    }
}