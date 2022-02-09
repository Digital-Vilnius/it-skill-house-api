using System;

namespace ItSkillHouse.Contracts.Event
{
    public class ListEventsRequest : ListRequest
    {
        public int? ContractorId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}