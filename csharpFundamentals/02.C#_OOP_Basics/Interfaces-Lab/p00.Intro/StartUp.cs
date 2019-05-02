namespace p00.Intro
{
    using System;
    using System.Collections.Generic;
    using p00.Intro.Animals;

    public class StartUp
    {
        public static void Main()
        {
            /*Animal animal = new Animal()*/; // Когато клас-а е абстрактен не може да се създава инстанция от него
            // Не е добре да се инстанцира нов обект по този начин (той е абстраткент) 
            //и заради това се  използва Abstractен клас (Виж Анимал)

            var bunny = new Bunny();


            //Полиморфизът е начин, по които извикваме даден метод от базов клас, но всъщност се извиква негов наследник
            //Пример

            var listOfAnimals = new List<Animal>();

            listOfAnimals.Add(new Cat());
            listOfAnimals.Add(new Dog());
            listOfAnimals.Add(new Bunny());

            foreach (var animal in listOfAnimals)
            {
                Console.WriteLine(animal.SayHello());
            }

            PrintCollection(listOfAnimals);
        }

        private static void PrintCollection(ICollection<Animal> animals)
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.SayHello());
            }
        }
    }
}
