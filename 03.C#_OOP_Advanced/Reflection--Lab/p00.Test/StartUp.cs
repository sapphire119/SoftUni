namespace p00.Test
{
    using System;
    using System.Reflection;
    using System.Runtime.InteropServices;

    public class StartUp
    {
        public static void Main()
        {
            ShowMessageBox(0, "Some text", "Some caption", 5);
        }

        [DllImport("user32.dll", EntryPoint = "MessageBox")]
        public static extern int ShowMessageBox(int hWnd, string test, string caption, int type);
    }
}
