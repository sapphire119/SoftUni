using System;
using System.Collections.Generic;

namespace _01.Intro
{
    public class StartUp
    {
        public static void Main()
        {

            var list = CreateList<int>();

            //Box<int> box = new Box<int>();

            //box.Add(1);
            //box.Add(2);
            //box.Add(3);
            //Console.WriteLine(box.Remove());

            //box.Add(4);
            //box.Add(5);
            //Console.WriteLine(box.Remove());

            //var cucumberJar = new CucumberJar();

            //cucumberJar.Add(new Cucumber());
            //cucumberJar.Add(new Cucumber());
            //cucumberJar.Add(new Cucumber());

            //cucumberJar.Add(new Pickle());

            //var pickleJar = new PickleJar();

            //pickleJar.Add(new Pickle());
        }

        public static List<T> CreateList<T>()
        {
            return new List<T>();
        }
    }

    

    public class Jar<T>
    {
        private readonly List<T> items;

        public Jar()
        {
            this.items = new List<T>();
        }

        public void Add(T element) => this.items.Add(element);

        public T Remove()
        {
            var lastElement = this.items[this.items.Count - 1];
            this.items.RemoveAt(this.items.Count - 1);
            return lastElement;
        }

        public int Count => this.items.Count;
    }


    public class CucumberJar : Jar<Cucumber>
    {
    }

    public class PickleJar : Jar<Pickle>
    {
    }

    public class Cucumber
    {
        public virtual int Freshness { get; set; } = 100;

        public int SeedCount { get; }
    }

    public class Pickle : Cucumber
    {
        public override int Freshness => 50;
    }
}
