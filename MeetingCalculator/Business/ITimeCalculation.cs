using System;

namespace MeetingCalculator
{
    public interface ITimeCalculation
    {
        decimal ReturnCostPerTime(DateTime start, DateTime now, decimal salaryPerHour);
    }
}