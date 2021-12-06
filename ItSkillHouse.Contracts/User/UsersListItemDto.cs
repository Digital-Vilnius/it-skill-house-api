﻿using System;
using System.Collections.Generic;
using ItSkillHouse.Contracts.Role;

namespace ItSkillHouse.Contracts.User
{
    public class UsersListItemDto : BaseDto
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public string Phone { get; set; }
        
        public string Status { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public List<RolesListItemDto> Roles { get; set; }
    }
}