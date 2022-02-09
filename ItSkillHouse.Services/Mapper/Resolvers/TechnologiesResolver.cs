using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ItSkillHouse.Contracts.Contractor;
using ItSkillHouse.Models;

namespace ItSkillHouse.Services.Mapper.Resolvers
{
    public class TechnologiesResolver : IValueResolver<EditContractorRequest, object, List<ContractorTechnology>>
    {
        public List<ContractorTechnology> Resolve(EditContractorRequest request, object destination, List<ContractorTechnology> destMember, ResolutionContext context)
        {
            var mainTechnologies = request.MainTechnologiesIds.Select(id => new ContractorTechnology { TechnologyId = id, IsMain = true });
            var otherTechnologies = request.TechnologiesIds.Select(id => new ContractorTechnology { TechnologyId = id });
            return mainTechnologies.Concat(otherTechnologies).ToList();
        }
    }
}