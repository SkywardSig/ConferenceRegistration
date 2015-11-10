using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConferenceRegistration.Models
{
    public class Conference
    {
        public long ConferenceId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Coordinator { get; set; }
        public string Description { get; set; }
    }
}
