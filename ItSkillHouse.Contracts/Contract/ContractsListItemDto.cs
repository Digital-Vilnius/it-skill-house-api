using System;
using ItSkillHouse.Contracts.ClientProject;
using ItSkillHouse.Contracts.Contractor;
using ItSkillHouse.Contracts.Rate;
using ItSkillHouse.Contracts.Recruiter;

namespace ItSkillHouse.Contracts.Contract
{
    public class ContractsListItemDto : BaseDto
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public ContractorsListItemDto Contractor { get; set; }
        public RatesListItemDto Rate { get; set; }
        public ClientProjectsListItemDto ClientProject { get; set; }
        public RecruitersListItemDto Recruiter { get; set; }
    }
}