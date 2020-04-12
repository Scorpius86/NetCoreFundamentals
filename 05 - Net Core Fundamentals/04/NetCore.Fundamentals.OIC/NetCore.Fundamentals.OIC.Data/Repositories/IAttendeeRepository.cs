using System.Threading.Tasks;
using NetCore.Fundamentals.OIC.Data.Model;

namespace NetCore.Fundamentals.OIC.Data.Repositories
{
    public interface IAttendeeRepository
    {
        Task<int> Add(AttendeeModel attendee);
    }
}