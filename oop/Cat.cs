namespace oop;
class Cat : Animal, Activity {
    public string name { get; private set; }
    public Cat(string name) {
        this.name = name;
    }
    public override void Greeting(string name) {
        Console.WriteLine("Hi {0}! I'm {1}!", name, this.name);
    }
    public void Move(int n) {
        Console.WriteLine("I'm walking for {0} minutes", n);
    }
}