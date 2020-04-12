using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Fundametals.Security.Dtos
{
    public class ConferenceDto
    {
        public ConferenceDto()
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
