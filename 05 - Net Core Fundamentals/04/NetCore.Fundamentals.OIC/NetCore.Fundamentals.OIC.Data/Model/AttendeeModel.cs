using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Fundamentals.OIC.Data.Model
{
    public class AttendeeModel
    {
        public int AttendeeId { get; set; }
        public int ConferenceId { get; set; }
        public string Name { get; set; }
    }
}
