using System;
using System.Collections.Generic;

namespace p09.RectangleIntersection
{
    public class Program
    {
        public static void Main()
        {
            checked
            {
                var rectanglesIntersectionsCount = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var rectangles = new List<Rectangle>();

                var rectangleCount = int.Parse(rectanglesIntersectionsCount[0]);
                var intersectionCount = int.Parse(rectanglesIntersectionsCount[1]);

                for (int count = 0; count < rectangleCount; count++)
                {
                    var rectangleInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (rectangleInput.Length == 5)
                    {
                        var id = rectangleInput[0];

                        var width = decimal.Parse(rectangleInput[1]);
                        var height = decimal.Parse(rectangleInput[2]);

                        var rectangle = new Rectangle(id, width, height);

                        var topLeftCornerX = decimal.Parse(rectangleInput[3]);
                        var topLeftCornerY = decimal.Parse(rectangleInput[4]);

                        rectangle.TopLeftCorner = new TopLeftCorner(topLeftCornerX, topLeftCornerY);

                        rectangles.Add(rectangle);
                    }
                }

                for (int count = 0; count < intersectionCount; count++)
                {
                    var pair = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (pair.Length == 2)
                    {
                        var firstId = pair[0];
                        var secondId = pair[1];

                        var firstRectangle = rectangles.Find(r => r.Id == firstId);
                        var secondRectangle = rectangles.Find(r => r.Id == secondId);

                        if (firstRectangle.FindIntersection(secondRectangle))
                        {
                            Console.WriteLine("true");
                        }
                        else
                        {
                            Console.WriteLine("false");
                        }
                    }
                } 
            }
        }
    }
}
