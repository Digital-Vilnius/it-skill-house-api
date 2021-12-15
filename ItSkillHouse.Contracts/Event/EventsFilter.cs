using System;

namespace ItSkillHouse.Contracts.Event
{
    public class EventsFilter
    {
        public string Query { get; set; }
        public int? ContractorId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}