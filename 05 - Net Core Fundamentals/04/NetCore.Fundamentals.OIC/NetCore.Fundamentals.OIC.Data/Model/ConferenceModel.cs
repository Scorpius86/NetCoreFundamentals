using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Fundamentals.OIC.Data.Model
{
    public class ConferenceModel
    {
        public ConferenceModel()
        {
            Start = DateTime.Now;
        }
        public int ConferenceId { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public string Location { get; set; }
        public int AttendeeCount { get; set; }
    }
}
