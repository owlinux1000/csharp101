namespace FakeDll {
    public class FakeDll
    {
        public FakeDll() {
            System.Console.WriteLine("FakeDll constructor is executed");
        }
        public FakeDll(string message) {
            System.Console.WriteLine(message);
        }
        public void MethodSample(string message) {
            System.Console.WriteLine($"MethodSample is called: {message}");
        }
    }
}
