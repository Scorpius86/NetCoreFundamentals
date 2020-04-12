using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCore.Fundamentals.OIC.Data.Adapters;
using NetCore.Fundamentals.OIC.Data.Context;
using NetCore.Fundamentals.OIC.Data.Model;

namespace NetCore.Fundamentals.OIC.Data.Repositories
{
    public class ConferenceRepository : IConferenceRepository
    {
        private readonly NetcoreFundamentalsOICContext _dbContext;

        public ConferenceRepository(NetcoreFundamentalsOICContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<List<ConferenceModel>> GetAll()
        {
            try
            {
                var conferences = await _dbContext.Conferences.Include(c => c.Attendees).Select(c => EntityModelAdapter.FromConferenceToConferenceModel(c)).ToListAsync();
                return conferences;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public async Task<ConferenceModel> GetById(int conferenceId)
        {
            var entity = await _dbContext.Conferences.FirstAsync(c => c.ConferenceId == conferenceId);
            return EntityModelAdapter.FromConferenceToConferenceModel(entity);
        }

        public async Task<int> Add(ConferenceModel model)
        {
            try
            {
                var entity = EntityModelAdapter.FromConferenceModelToConference(model);
                _dbContext.Conferences.Add(entity);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }            
        }
    }
}
