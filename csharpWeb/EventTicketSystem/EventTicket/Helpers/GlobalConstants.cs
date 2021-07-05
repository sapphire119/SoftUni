using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventTicket.Helpers
{
    public static class GlobalConstants
    {
        #region User
        public const string UsernameAllowedCharsErrorMessage = "Only alphanumerics, dashes, underscores, dots, asteriks, and tylde are allowed";

        public const string UsernameMinLengthErrorMessage = "Username should be at least {1} symbols";

        public const string PasswordMinLengthErrorMessage = "The {0} must be at least {1} characters long.";

        public const string UcnMinLengthErrorMessage = "{0} should be exactly {1} symbols";

        public const string PasswordMismatchErrorMessage = "The password and confirmation password do not match.";
        #endregion


        #region Event
        public const string TicketsBelowMinValueErrorMessage = "Total tickets cannot be below {1} ";

        public const string TicketMinPriceErrorMessage = "Tickets must cost at least {1}$";

        public const string DateParseErrorMessage = "Couldn't parse {0} field to proper date and time";

        public const string EventNameLengthError = "Event name must be 10 symbols.";
        //public const string DefaultDateFormat = @"dd-MMM-yyyy HH:ss";
        #endregion
    }
}
