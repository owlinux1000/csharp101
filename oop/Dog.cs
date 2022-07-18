namespace oop;
class Dog : Animal {
    public string name { get; private set; }
    public Dog(string name) {
        this.name = name;
    }
    public override void Greeting(string name) {
        Console.WriteLine("Hi {0}. I'm {1}!", name, this.name);
    }
}