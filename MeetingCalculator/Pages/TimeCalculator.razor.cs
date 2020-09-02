using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingCalculator.Pages
{
    public partial class TimeCalculator
    {
        
        public int NumberOfAttendees { get; set; }

        
        public int AvgHourlyRate { get; set; }

        public string ButtonTitle { get; set; }



        protected override Task OnInitializedAsync()
        {
            NumberOfAttendees = 1;
            AvgHourlyRate = 40;
            ButtonTitle = "Start";

            return base.OnInitializedAsync();
        }

        public async Task OnClick()
        {
            if(ButtonTitle=="Start")
            {
                ButtonTitle = "Stop";
            }
            else
            {
                ButtonTitle = "Start";
            }
            
        }
    }
}
