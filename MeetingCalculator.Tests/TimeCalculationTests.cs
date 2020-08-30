using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MeetingCalculator.Tests
{
    [TestClass]
    public class TimeCalculationTests
    {
        private TimeCalculation _timeCalculation;

        [TestInitialize]
        public void Initialize()
        {
            _timeCalculation = new TimeCalculation();
        }

        [TestMethod]
        public void ReturnCostPerTime_One_Second_Salary_Zero_Ok()
        {
            var averageSalaryPerHour = 0;

            DateTime start = new DateTime(2020, 08, 31, 0, 0, 1);
            DateTime now = new DateTime(2020, 08, 31, 0, 0, 2);

            var actualCost = _timeCalculation.ReturnCostPerTime(start, now, averageSalaryPerHour);

            Assert.AreEqual(0, actualCost);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ReturnCostPerTime_Start_Greater_Than_Now_ArgumentException()
        {
            var averageSalaryPerHour = 30;

            DateTime start = new DateTime(2020, 08, 31, 0, 0, 1);
            DateTime now = new DateTime(2020, 07, 30, 0, 0, 2);

            var actualCost = _timeCalculation.ReturnCostPerTime(start, now, averageSalaryPerHour);
        }

        [TestMethod]
        public void ReturnCostPerTime_One_Second_Ok()
        {
            var averageSalaryPerHour = 30;

            DateTime start = new DateTime(2020, 08, 31, 0, 0, 1);
            DateTime now = new DateTime(2020, 08, 31, 0, 0, 2);

            var actualCost = _timeCalculation.ReturnCostPerTime(start, now, averageSalaryPerHour);

            Assert.AreEqual(0.008m, actualCost);
        }

        [TestMethod]
        public void ReturnCostPerTime_One_Minute_Ok()
        {
            var averageSalaryPerHour = 30;

            DateTime start = new DateTime(2020, 08, 31, 0, 1, 0);
            DateTime now = new DateTime(2020, 08, 31, 0, 2, 0);

            var actualCost = _timeCalculation.ReturnCostPerTime(start, now, averageSalaryPerHour);

            Assert.AreEqual(0.5m, actualCost);
        }

        [TestMethod]
        public void ReturnCostPerTime_One_Hour_Ok()
        {
            var averageSalaryPerHour = 30;

            DateTime start = new DateTime(2020, 08, 31, 0, 0, 0);
            DateTime now = new DateTime(2020, 08, 31, 1, 0, 0);

            var actualCost = _timeCalculation.ReturnCostPerTime(start, now, averageSalaryPerHour);

            Assert.AreEqual(30, actualCost);
        }

        [TestMethod]
        public void ReturnCostPerTime_Two_Hour_Ok()
        {
            var averageSalaryPerHour = 30;

            DateTime start = new DateTime(2020, 08, 31, 0, 0, 0);
            DateTime now = new DateTime(2020, 08, 31, 2, 0, 0);

            var actualCost = _timeCalculation.ReturnCostPerTime(start, now, averageSalaryPerHour);

            Assert.AreEqual(60, actualCost);
        }
    }
}