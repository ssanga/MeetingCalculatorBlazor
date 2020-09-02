using System;

namespace MeetingCalculator
{
    public class TimeCalculation : ITimeCalculation
    {
        
        public decimal ReturnCostPerTime(DateTime start, DateTime now, decimal avgSalaryPerHour, int numberOfAttendees)
        {
            decimal result = 0;

            if (start > now)
            {
                throw new ArgumentException("Start date cannot be greater than actual date");
            }


            var diff = now - start;
            var seconds = diff.TotalSeconds;

            result = avgSalaryPerHour / 3600 * Convert.ToDecimal(seconds);

            result = Math.Round(result * numberOfAttendees, 3);

            return result;
        }
    }
}