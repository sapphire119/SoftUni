using System;
using System.Collections;
using System.Collections.Generic;

namespace Jars
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var jar = new Jar1<string>();

            var jar2 = new Jar2<int>();

            var jar3 = new Jar3<List<string>>();

            var jar4 = new Jar3<string[]>();

            var jar5 = new Jar3<Dictionary<string, int>>();

            var jar6 = new Jar4<Dictionary<string, int>>();

            var test = new Jar5<Test>();
            ////////////////////////////////////////////////////////////
            var jar66 = new Jar66<Cucumber>();

            jar66.Add(new Cucumber());
            jar66.Add(new Pickle());
            jar66.Add(new Cucumber());

            var jar33 = new Jar66<Pickle>();

            jar33.Add(new Pickle());
            jar33.Add(new Pickle());
            jar33.Add(new Pickle());
            jar33.Add(new Pickle());

            jar66.AddAll(jar33);

            jar66.PrintContents();

            /////////////////////////////////////////////

            var jarAgain = new Jar66<Cucumber>();

            jarAgain.Add(new Cucumber());
            jarAgain.Add(new Cucumber());
            jarAgain.Add(new Pickle());
            jarAgain.Add(new Cucumber());
            jarAgain.Add(new Pickle());

            var cucumber = jarAgain[1];

            Console.WriteLine(cucumber.Freshness);
        }
    }
}


public class Jar1<T>
    where T : class { }

public class Jar2<T>
    where T : struct { }

public class Jar3<T>
    where T: IEnumerable { }

public class Jar4<T>
    where T: IDictionary { }

public class Jar5<T> //Гарантира създаване на нов конструктор
    where T : new()
{
    public static T CreateInstance()
    {
        return new T();
    }
}

public class Jar66<T> : IEnumerable<T>
    where T : Cucumber //Ако това го нямаше нямаше да можем да ползваме item.Freshness
{
    private List<T> items;

    public Jar66()
    {
        this.items = new List<T>();
    }

    public void Add(T item)
    {
        this.items.Add(item);
    }

    public void AddAll<U>(Jar66<U> items)
        where U : T
    {
        foreach (var item in items)
        {
            this.items.Add(item);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.items.GetEnumerator();
    }

    public void PrintContents()
    {
        foreach (var item in this.items)
        {
            Console.WriteLine(item.Freshness);
        }
    }

    
    public T this[int index] => this.items[index];
}

public class Test
{
    public Test()
    {

    }

    public Test(int a, int b)
        : this()
    {

    }
}

public class Cucumber
{
    public virtual int Freshness { get; set; } = 100;
}

public class Pickle : Cucumber
{
    public override int Freshness => 50;
}