namespace p04.Telephony
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var phoneNumbers = Console.ReadLine().Split().ToList();
            var websitesInput = Console.ReadLine().Split().ToList();

            var smarthPhone = new SmartPhone(phoneNumbers, websitesInput);

            Console.WriteLine(smarthPhone.CallOtherPhones());
            Console.WriteLine(smarthPhone.BrowseInternet());
        }
    }
}
