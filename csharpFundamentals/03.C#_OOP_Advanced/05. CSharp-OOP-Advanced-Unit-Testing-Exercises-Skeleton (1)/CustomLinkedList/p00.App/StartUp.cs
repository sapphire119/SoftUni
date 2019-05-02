namespace p00.App
{
    using p01.Database;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var test = new int[16];
            IDatabase database = new Database(test);
        }
    }
}
