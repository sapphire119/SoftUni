namespace p01.Intro
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            //ЗАБЕЛЕЖКА Не съм оформил добре файл-а, които се получава при log.txt 
            //и ако се пре-въвежда нов input старите стойности няма да се презапишат,а ще се добавят

            var appenders = new List<IAppender>();

            var appenderCount = int.Parse(Console.ReadLine());

            for (int count = 0; count < appenderCount; count++)
            {
                var input = Console.ReadLine();
                var inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                ILayout layout = CreateLayout(inputArgs[1]);
                IAppender appender = CreateAppeneder(layout, inputArgs);
                appenders.Add(appender);
            }

            var logger = new Logger(appenders.ToArray());

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var commandArgs = command.Split('|', StringSplitOptions.RemoveEmptyEntries);

                var reportLevel = commandArgs[0];

                var date = commandArgs[1];

                var message = commandArgs[2];

                logger.Log(date, reportLevel, message);
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Logger info");
            foreach (var appender in logger.GetAppenders)
            {
                sb.AppendLine(appender.ToString());
            }

            var result = sb.ToString().TrimEnd();

            Console.WriteLine(result);


            //ILayout simpleLayout = new SimpleLayout();

            //var appender = new FileAppender(simpleLayout)
            //{
            //    ReportLevel = ReportLevel.Info
            //};

            //LogFile file = new LogFile();

            //appender.File = file;
            ////IAppender consoleAppender =
            ////     new ConsoleAppender(simpleLayout);

            //ILogger logger = new Logger(appender);

            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");


            //var xmlLayout = new XmlLayout();

            //var consoleAppender = new ConsoleAppender(xmlLayout);
            //consoleAppender.ReportLevel = ReportLevel.Info;

            //var file = new LogFile();

            //var fileAppender = new FileAppender(xmlLayout);

            //fileAppender.File = file;

            //fileAppender.ReportLevel = ReportLevel.Info;

            //var logger = new Logger(consoleAppender, fileAppender);

            //logger.Fatal("3/31/2015 5:23:54 PM", "mscorlib.dll does not respond");

            //logger.Critical("3/31/2015 5:23:54 PM", "No connection string found in App.config");


            //var simpleLayout = new SimpleLayout();
            //var consoleAppender = new ConsoleAppender(simpleLayout);

            //var file = new LogFile();

            //var fileAppender = new FileAppender(simpleLayout);

            //fileAppender.File = file;

            //var logger = new Logger(consoleAppender, fileAppender);
            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

        }

        private static IAppender CreateAppeneder(ILayout layout, string[] inputArgs)
        {
            IAppender appender = null;

            var appenderType = inputArgs[0];
            switch (appenderType)
            {
                case nameof(ConsoleAppender): appender = new ConsoleAppender(layout); break;
                case nameof(FileAppender):
                    appender = new FileAppender(layout);
                    break;
            }

            if (inputArgs.Length == 3)
            {
                var isItValidReportLevel = Enum.TryParse(inputArgs[2], out ReportLevel reportLevel);
                if (isItValidReportLevel)
                {
                    appender.ReportLevel = reportLevel;
                }
            }

            return appender;
        }

        private static ILayout CreateLayout(string layoutType)
        {
            ILayout layout = null;
            switch (layoutType)
            {
                case nameof(SimpleLayout): layout = new SimpleLayout(); break;
                case nameof(XmlLayout): layout = new XmlLayout(); break;
            }

            return layout;
        }
    }
}