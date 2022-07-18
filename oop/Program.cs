using System;
using System.Collections;
namespace oop;
class Program {
    static void Main(string[] args) {
        Dog lambda = new Dog("lambda");
        Cat mio = new Cat("mio");
        List<Animal> animals = new List<Animal>();
        animals.Add(lambda);
        animals.Add(mio);
        foreach (Animal animal in animals) {
            animal.Greeting("Chihiro");
        }
    }
}
