﻿using System;

namespace ItSkillHouse.Contracts.Authentication
{
    public class LoggedUserDto : BaseDto
    {
        public string FirstName { get; set; }
                
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public string Phone { get; set; }
        
        public string Status { get; set; }

        public DateTime LastLoginDate { get; set; }
    }
}