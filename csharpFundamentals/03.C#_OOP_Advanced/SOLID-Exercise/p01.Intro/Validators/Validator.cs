using p01.Intro.Exceptions;
using System;
using System.Globalization;

public class Validator 
{
    public void ValidateLayout(string[] arguments)
    {
        if (arguments.Length != 3)
        {
            throw new InvalidNumberOfInputParametersException();
        }

        var resultingDate = string.Empty;
        var typeMessage = arguments[1];
        var endMessage = arguments[2];

        try
        {
            var date = DateTime.Parse(arguments[0], CultureInfo.InvariantCulture);
            resultingDate = date.ToString(@"M/dd/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
        }
        catch (InvalidDateException)
        {
            throw new InvalidDateException();
        }
    }

    //public void ValidateReportLevel(ReportLevel currentReportLevel, ReportLevel reportedLevel)
    //{
    //    if (currentReportLevel > reportedLevel)
    //    {
    //        throw new ArgumentException(string.Format("You need a higher degree clearence to report a {0} message!" + Environment.NewLine + "Current Report level {1}", currentReportLevel, reportedLevel));
    //    }
    //}
}