using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class GraphicEditor
    {
        public string DrawShape(IShape shape)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"I'm {shape.GetType().Name}");

            var result = sb.ToString().TrimEnd();

            return result;
        }
    }
}
