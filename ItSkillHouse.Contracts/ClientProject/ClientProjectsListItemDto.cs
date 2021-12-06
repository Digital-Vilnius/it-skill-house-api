using ItSkillHouse.Contracts.Client;

namespace ItSkillHouse.Contracts.ClientProject
{
    public class ClientProjectsListItemDto : BaseDto
    {
        public string Name { get; set; }
        public ClientDto Client { get; set; }
    }
}