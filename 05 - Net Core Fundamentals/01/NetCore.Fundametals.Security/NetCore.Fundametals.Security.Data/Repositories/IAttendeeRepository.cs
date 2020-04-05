using NetCore.Fundametals.Security.Dtos;
using System.Threading.Tasks;

namespace NetCore.Fundametals.Security.Data.Repositories
{
    public interface IAttendeeRepository
    {
        Task<int> Add(AttendeeDto attendee);
        Task<int> GetAttendeesTotal(int conferenceId);
    }
}