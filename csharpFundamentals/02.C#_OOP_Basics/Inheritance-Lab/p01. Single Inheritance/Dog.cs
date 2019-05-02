using System;

public class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine("barking...");
    }

    //public new void Eat() 
    //    //Създава свой метод Eat със съшото име. 
    //    //Не презаписва този в Animal,а създава свой
    //{
    //    Console.WriteLine("Munch,Munch...");
    //}

    public override void Eat() //Презаписва base.Eat() във Animal class-a
    {
        Console.WriteLine("Munch,Munch...");
    }
}