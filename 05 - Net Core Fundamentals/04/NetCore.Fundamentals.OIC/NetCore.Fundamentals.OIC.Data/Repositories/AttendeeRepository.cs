using NetCore.Fundamentals.OIC.Data.Adapters;
using NetCore.Fundamentals.OIC.Data.Context;
using NetCore.Fundamentals.OIC.Data.Model;
using System.Threading.Tasks;

namespace NetCore.Fundamentals.OIC.Data.Repositories
{
    public class AttendeeRepository : IAttendeeRepository
    {
        private readonly NetcoreFundamentalsOICContext _dbContext;

        public AttendeeRepository(NetcoreFundamentalsOICContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<int> Add(AttendeeModel attendee)
        {
            var entity = EntityModelAdapter.FromAttendeeModelToAttendee(attendee);
            _dbContext.Attendees.Add(entity);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
