using NetCore.Fundamentals.OIC.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Fundamentals.OIC.Client.Web.Infrastructure.Agents.Conference
{
    public interface IConferenceAgent
    {
        Task AddConference(ConferenceModel model);
        Task<IEnumerable<ConferenceModel>> GetAllConferences();
    }
}
