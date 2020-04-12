using NetCore.Fundamentals.OIC.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Fundamentals.OIC.Client.Web.Infrastructure.Agents.Attendee
{
    public interface IAttendeeAgent
    {
        Task<AttendeeModel> AddAttendee(AttendeeModel attendee);
    }
}
