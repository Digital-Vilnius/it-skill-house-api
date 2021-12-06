using System.Collections.Generic;

namespace ItSkillHouse.Contracts
{
    public class ListResponse<T> : ResultResponse<List<T>>
    {
        public int Count { get; set; }
        
        public ListResponse(List<T> result, int count) : base(result)
        {
            Count = count;
        }
    }
}