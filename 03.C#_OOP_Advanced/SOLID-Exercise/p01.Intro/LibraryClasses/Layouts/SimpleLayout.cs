using System;
using System.Globalization;
using p01.Intro.Exceptions;

public class SimpleLayout : ILayout
{
    private Validator validator;

    public SimpleLayout()
    {
        this.validator = new Validator();
    }

    public string Format(string[] arguments)
    {
        this.validator.ValidateLayout(arguments);

        var resultingDate = arguments[0];
        var typeMessage = arguments[1];
        var endMessage = arguments[2];
        //if (arguments.Length != 3)
        //{
        //    throw new InvalidNumberOfInputParametersException();
        //}

        //var resultingDate = string.Empty;
        //var typeMessage = arguments[1];
        //var endMessage = arguments[2];

        //try
        //{
        //    var date = DateTime.Parse(arguments[0], CultureInfo.InvariantCulture);
        //    resultingDate = date.ToString(@"M/dd/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
        //}
        //catch (InvalidDateException)
        //{
        //    throw new InvalidDateException();
        //}

        return string.Format("{0} - {1} - {2}", resultingDate, typeMessage, endMessage);
    }

}