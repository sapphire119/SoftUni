namespace p04.RandomList
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var randomList = new global::RandomList
            {
                "pesho",
                "ivan",
                "gosho",
                "petur",
                "boris",
                "vladimir",
                "kaloqn"
            };

            Console.WriteLine("Random element removed: {0}",randomList.RandomString());
        }
    }
}
