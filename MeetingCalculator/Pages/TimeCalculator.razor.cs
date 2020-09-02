using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace MeetingCalculator.Pages
{
    public partial class TimeCalculator
    {
        private int NumberOfAttendees { get; set; }

        private int AvgHourlyRate { get; set; }

        private string ButtonTitle { get; set; }

        [Inject]
        public ITimeCalculation _TimeCalculation { get; set; }

        private TimeSpan stopWatchValue;
        private decimal moneySpent;
        private bool is_stopwatchRunning = false;

        private DateTime? startDate = null;
        private DateTime? finishDate = null;

        protected override Task OnInitializedAsync()
        {
            NumberOfAttendees = 1;
            AvgHourlyRate = 40;
            ButtonTitle = "Start";

            stopWatchValue = new TimeSpan();

            return base.OnInitializedAsync();
        }

        private async Task StopWatch()
        {
            is_stopwatchRunning = true;

            while (is_stopwatchRunning)
            {
                await Task.Delay(1000);
                if (is_stopwatchRunning)
                {
                    stopWatchValue = stopWatchValue.Add(new TimeSpan(0, 0, 1));

                    finishDate = startDate + stopWatchValue;

                    moneySpent = _TimeCalculation.ReturnCostPerTime(startDate.Value, finishDate.Value, AvgHourlyRate, NumberOfAttendees);


                    StateHasChanged();
                }
            }
        }

        public async Task OnClick()
        {
            if (ButtonTitle == "Start")
            {
                if(!startDate.HasValue)
                {
                    startDate = DateTime.Now;
                }

                ButtonTitle = "Stop";

                await StopWatch();
            }
            else
            {
                ButtonTitle = "Start";
                is_stopwatchRunning = false;
            }
        }
    }
}