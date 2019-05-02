namespace p01.Structure
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            DraftManager draftManager = new DraftManager();

            var args = "Sonic AS-51 100 100 10".Split().ToList();
            var args2 = "Solar Falcon 100".Split().ToList();
            var args3 = "Hammer CDD 100 50".Split().ToList();
            Console.WriteLine();
            try
            {
                draftManager.RegisterHarvester(args);
                draftManager.RegisterProvider(args2);
                draftManager.RegisterHarvester(args3);
                draftManager.Day();
                var modeArgs = "Half".Split().ToList();
                draftManager.Mode(modeArgs);
                draftManager.Day();
                var secondModeArgs = "Energy".Split().ToList();
                draftManager.Mode(secondModeArgs);
                draftManager.Day();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}