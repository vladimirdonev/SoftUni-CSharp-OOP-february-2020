using Logger.Models.Contracts;
using Logger.Models.Enumerations;
using Logger.Models.Errors;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Logger.Factories
{
    public class ErrorFactory
    {
        private const string Date_Format = "M/dd/yyyy h/mm/ss tt";
        public IError ProduceError(string date, string message, string level)
        {
            DateTime dateTime;
            try
            {
                dateTime = DateTime.ParseExact(date,Date_Format,CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {

                throw new ArgumentException("Invalid date format", e);
            }

            Level level1;

            bool parcelevel = Enum.TryParse<Level>(level, true , out level1);

            if (!parcelevel)
            {
                throw new ArgumentException("Invalid Level type!");
            }

            IError error = new Error(dateTime, message, level1);
            return error;
        }
    }
}
