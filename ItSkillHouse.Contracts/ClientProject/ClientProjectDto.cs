using ItSkillHouse.Contracts.Client;
using ItSkillHouse.Contracts.Contract;

namespace ItSkillHouse.Contracts.ClientProject
{
    public class ClientProjectDto : BaseDto
    {
        public string Name { get; set; }
        public ClientDto Client { get; set; }
        public ContractDto Contract { get; set; }
    }
}