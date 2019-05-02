namespace p02.PointInRectangle
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var rectangle = new Rectangle(Console.ReadLine()); //Функция //Тук подаваме резултата от ReadLine

            var lines = int.Parse(Console.ReadLine());

            for (int count = 0; count < lines; count++)
            {
                var currentPoint = new Point(Console.ReadLine); //Тук подаваме функцията Console.ReadLine
                Console.WriteLine(rectangle.Contains(currentPoint)); 
            }
        }
    }
}
