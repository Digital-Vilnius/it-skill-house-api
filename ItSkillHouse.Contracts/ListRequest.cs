namespace ItSkillHouse.Contracts
{
    public class ListRequest
    {
        public int? Take { get; set; }
        public int? Skip { get; set; }
        public string SortDirection { get; set; }
        public string SortBy { get; set; }
    }
}