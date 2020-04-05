using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Fundametals.Security.Dtos
{
    public class ProposalDto
    {
        public int ProposalId { get; set; }
        public int ConferenceId { get; set; }
        public string Speaker { get; set; }
        public string Title { get; set; }
        public bool Approved { get; set; }
    }
}
