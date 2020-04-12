using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Fundametals.Security.Dtos
{
    public class AttendeeDto
    {
        public int AttendeeId { get; set; }
        public int ConferenceId { get; set; }
        public string Name { get; set; }
    }
}
