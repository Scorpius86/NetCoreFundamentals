using NetCore.Fundamentals.OIC.Data.Entities;
using NetCore.Fundamentals.OIC.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCore.Fundamentals.OIC.Data.Adapters
{
    public static class EntityModelAdapter
    {
        public static Attendee FromAttendeeModelToAttendee(AttendeeModel attendeeModel)
        {
            return new Attendee
            {
                ConferenceId = attendeeModel.ConferenceId,
                Name = attendeeModel.Name
            };
        }
        public static ConferenceModel FromConferenceToConferenceModel(Conference conference)
        {
            return new ConferenceModel
            {
                ConferenceId = conference.ConferenceId,
                Location = conference.Location,
                Name = conference.Name,
                Start = conference.Start,
                AttendeeCount = conference.Attendees == null ? 0 : conference.Attendees.Count()
            };
        }

        public static Conference FromConferenceModelToConference(ConferenceModel conferenceModel)
        {
            return new Conference
            {
                Location = conferenceModel.Location,
                Name = conferenceModel.Name,
                Start = conferenceModel.Start
            };
        }

        public static ProposalModel FromProposalToProposalModel(Proposal proposal)
        {
            return new ProposalModel
            {
                ProposalId = proposal.ProposalId,
                ConferenceId = proposal.ConferenceId,
                Speaker = proposal.Speaker,
                Title = proposal.Title,
                Approved = proposal.Approved
            };
        }

        public static Proposal FromProposalModelToProposal(ProposalModel proposalModel)
        {
            return new Proposal
            {
                ConferenceId = proposalModel.ConferenceId,
                Speaker = proposalModel.Speaker,
                Title = proposalModel.Title,
                Approved = proposalModel.Approved
            };
        }
    }
}
