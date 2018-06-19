namespace _04.CopyBinaryFile
{
    using System;
    using System.IO;

    public class Program
    {
        public static void Main()
        {
            using (var sourceFile = new FileStream("./../streams/CopyMe.png", FileMode.Open))
            {
                using (var destinationFile = new FileStream("CopiedImage.png", FileMode.Create)) 
                {
                    byte[] buffer = new byte[4096];
                    while (true)
                    {
                        var readBytesCount = sourceFile.Read(buffer, 0, buffer.Length);
                        if (readBytesCount == 0)
                            break;
                        destinationFile.Write(buffer, 0, readBytesCount);
                    }
                }
            }
        }
    }
}
