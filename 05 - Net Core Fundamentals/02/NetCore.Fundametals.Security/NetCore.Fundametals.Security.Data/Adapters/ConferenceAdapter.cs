using NetCore.Fundametals.Security.Data.Entities;
using NetCore.Fundametals.Security.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCore.Fundametals.Security.Data.Adapters
{
    public static class ConferenceAdapter
    {
        public static Attendee FromAttendeeDtoToAttendee(AttendeeDto attendeeDto)
        {
            return new Attendee
            {
                ConferenceId = attendeeDto.ConferenceId,
                Name = attendeeDto.Name
            };
        }
        public static ConferenceDto FromConferenceToConferenceDto(Conference conference)
        {
            return new ConferenceDto
            {
                ConferenceId = conference.ConferenceId,
                Location = conference.Location,
                Name = conference.Name,
                Start = conference.Start,
                AttendeeCount = conference.Attendees == null ? 0 : conference.Attendees.Count()
            };
        }

        public static Conference FromConferenceDtoToConference(ConferenceDto conferenceDto)
        {
            return new Conference
            {
                Location = conferenceDto.Location,
                Name = conferenceDto.Name,
                Start = conferenceDto.Start
            };
        }

        public static ProposalDto FromProposalToProposalDto(Proposal proposal)
        {
            return new ProposalDto
            {
                ProposalId = proposal.ProposalId,
                ConferenceId = proposal.ConferenceId,
                Speaker = proposal.Speaker,
                Title = proposal.Title,
                Approved = proposal.Approved
            };
        }

        public static Proposal FromProposalDtoToProposal(ProposalDto proposalDto)
        {
            return new Proposal
            {
                ConferenceId = proposalDto.ConferenceId,
                Speaker = proposalDto.Speaker,
                Title = proposalDto.Title,
                Approved = proposalDto.Approved
            };
        }
    }
}
