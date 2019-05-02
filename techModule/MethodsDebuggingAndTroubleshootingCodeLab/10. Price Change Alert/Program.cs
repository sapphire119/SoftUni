using System;

class PriceChangeAlert
{
    static void Main()
    {
        int countPrices = int.Parse(Console.ReadLine());
        double threshold = double.Parse(Console.ReadLine());
        var oldValue = double.Parse(Console.ReadLine());
        for (int i = 1; i <= countPrices - 1; i++) 
        {
            var currentValue = double.Parse(Console.ReadLine());
            double diffrence = ((currentValue - oldValue) / oldValue) * 100.0;
            bool IsThreshHoldBiggerThanDiffrence = (
                Math.Abs(diffrence) >= threshold*100.0) ? true : false;
            string result = CalculateEndResult(
                currentValue, oldValue,diffrence, IsThreshHoldBiggerThanDiffrence);
            oldValue = currentValue;
            Console.WriteLine(result);
        }
    }

    static string CalculateEndResult(
        double currentValue,double oldValue, double diffrence, bool IsThreshHoldBiggerThanDiffrence)
    {
        string result = "";
        if (diffrence == 0)
        {
            result = string.Format("NO CHANGE: {0}", currentValue);
        }
        else if (IsThreshHoldBiggerThanDiffrence == false)
        {
            result = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", oldValue, currentValue, diffrence);
        }
        else if (diffrence > 0)
        {
            result = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", oldValue, currentValue, diffrence);
        }
        else if (diffrence < 0)
            result = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", oldValue, currentValue, diffrence);
        return result;
    }




}
