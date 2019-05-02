using System;
using System.Globalization;

public class DateModifier
{
    private string firstDate;
    private string secondDate;

    public DateModifier() { }

    public DateModifier(string firstDate, string secondDate)
        : this()
    {
        this.FirstDate = firstDate;
        this.SecondDate = secondDate;
    }

    public string SecondDate
    {
        get
        {
            return this.secondDate;
        }
        set
        {
            this.secondDate = value;
        }
    }


    public string FirstDate
    {
        get
        {
            return this.firstDate;
        }
        set
        {
            this.firstDate = value;
        }
    }

    public long CalculateDiffrence()
    {
        var firstDate = DateTime.ParseExact(this.FirstDate, @"yyyy MM dd", CultureInfo.InvariantCulture);
        var secondDate = DateTime.ParseExact(this.SecondDate, @"yyyy MM dd", CultureInfo.InvariantCulture);

        var daysDiffrence = Math.Abs((long)firstDate.Subtract(secondDate).TotalDays);

        return daysDiffrence;
    }
}

