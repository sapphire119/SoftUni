namespace p01._Single_Inheritance
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var dog = new Dog();
            dog.Eat();
            //dog.Bark();

            Animal dogAsAnimal = dog;
            dogAsAnimal.Eat();

            //var puppy = new Puppy();

            //puppy.Eat();
            //puppy.Bark();
            //puppy.Weep();

            //var cat = new Cat();

            //cat.Eat();
            //cat.Meow();
        }
    }
}
