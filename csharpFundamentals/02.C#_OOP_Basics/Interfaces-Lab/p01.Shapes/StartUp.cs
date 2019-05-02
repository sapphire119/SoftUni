namespace p01.Shapes
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {

            IEnumerable<int> numbers = new List<int>();

            var list = numbers as HashSet<int>; //Това пробва да го cast-не и ако не може връща null
            if (list == null)
            {
                Console.WriteLine("Oo yeah");
            }

            //var radius = int.Parse(Console.ReadLine());
            //IDrawable circle = new Circle(radius);

            //var width = int.Parse(Console.ReadLine());
            //var height = int.Parse(Console.ReadLine());
            //IDrawable rect = new Rectangle(width, height);

            //circle.Draw();
            //rect.Draw();
        }
    }
}
