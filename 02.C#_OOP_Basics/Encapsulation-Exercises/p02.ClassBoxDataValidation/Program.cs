namespace p02.ClassBoxDataValidation
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var length = decimal.Parse(Console.ReadLine());
            var width = decimal.Parse(Console.ReadLine());
            var height = decimal.Parse(Console.ReadLine());

            var box = new Box();

            try
            {
                box = new Box(length, width, height);

                Console.WriteLine(box.CalculateSurfaceArea());
                Console.WriteLine(box.CalculateLateralSurface());
                Console.WriteLine(box.CalculateVolume());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
