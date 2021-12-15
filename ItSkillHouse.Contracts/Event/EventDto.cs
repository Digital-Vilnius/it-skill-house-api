using System;

namespace ItSkillHouse.Contracts.Event
{
    public class EventDto : BaseDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string Link { get; set; }
        public string Location { get; set; }
    }
}