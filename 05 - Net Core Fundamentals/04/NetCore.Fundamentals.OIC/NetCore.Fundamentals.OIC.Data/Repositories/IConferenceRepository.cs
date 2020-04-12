using NetCore.Fundamentals.OIC.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.Fundamentals.OIC.Data.Repositories
{
    public interface IConferenceRepository
    {
        Task<int> Add(ConferenceModel model);
        Task<List<ConferenceModel>> GetAll();
        Task<ConferenceModel> GetById(int id);
    }
}