﻿using System;

namespace ItSkillHouse.Contracts.Event
{
    public class AddEventRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string Link { get; set; }
        public string Location { get; set; }
        public int ContractorId { get; set; }
    }
}