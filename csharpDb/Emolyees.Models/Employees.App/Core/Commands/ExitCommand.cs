﻿namespace Employees.App.Core.Commands
{
    using System;

    public class ExitCommand
    {
        public string Execute()
        {
            Environment.Exit(0);

            return null;
        }
    }
}
