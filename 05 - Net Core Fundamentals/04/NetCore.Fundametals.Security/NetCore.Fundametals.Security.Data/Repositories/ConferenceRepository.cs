using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCore.Fundametals.Security.Data.Adapters;
using NetCore.Fundametals.Security.Data.Context;
using NetCore.Fundametals.Security.Dtos;

namespace NetCore.Fundametals.Security.Data.Repositories
{
    public class ConferenceRepository : IConferenceRepository
    {
        private readonly NetcoreFundametalsSecurityDbContext _dbContext;

        public ConferenceRepository(NetcoreFundametalsSecurityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<ConferenceDto>> GetAll()
        {
            return _dbContext.Conferences.Include(c => c.Attendees).Select(c => ConferenceAdapter.FromConferenceToConferenceDto(c)).ToListAsync();
        }

        public async Task<ConferenceDto> GetById(int conferenceId)
        {
            var entity = await _dbContext.Conferences.FirstAsync(c => c.ConferenceId == conferenceId);
            return ConferenceAdapter.FromConferenceToConferenceDto(entity);
        }

        public Task<int> Add(ConferenceDto conferenceDto)
        {
            var entity = ConferenceAdapter.FromConferenceDtoToConference(conferenceDto);
            _dbContext.Conferences.Add(entity);
            return _dbContext.SaveChangesAsync();
        }
    }
}
