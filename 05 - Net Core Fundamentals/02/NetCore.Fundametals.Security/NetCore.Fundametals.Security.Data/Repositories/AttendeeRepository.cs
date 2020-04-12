using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCore.Fundametals.Security.Data.Adapters;
using NetCore.Fundametals.Security.Data.Context;
using NetCore.Fundametals.Security.Dtos;

namespace NetCore.Fundametals.Security.Data.Repositories
{
    public class AttendeeRepository : IAttendeeRepository
    {
        private readonly NetcoreFundametalsSecurityDbContext _dbContext;

        public AttendeeRepository(NetcoreFundametalsSecurityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> Add(AttendeeDto attendeeDto)
        {
            var entity = ConferenceAdapter.FromAttendeeDtoToAttendee(attendeeDto);
            _dbContext.Attendees.Add(entity);
            return _dbContext.SaveChangesAsync();
        }

        public Task<int> GetAttendeesTotal(int conferenceId)
        {
            return _dbContext.Attendees.CountAsync(a => a.ConferenceId == conferenceId);
        }
    }
}
