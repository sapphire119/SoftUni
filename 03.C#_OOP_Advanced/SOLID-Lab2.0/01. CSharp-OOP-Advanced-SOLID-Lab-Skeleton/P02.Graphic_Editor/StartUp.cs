namespace P02.Graphic_Editor
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var rectangle = new Rectangle();
            GraphicEditor editor = new GraphicEditor();
            Console.WriteLine(editor.DrawShape(rectangle));

            Polygon polygon = new Polygon();
            Console.WriteLine(editor.DrawShape(polygon));
        }
    }
}
