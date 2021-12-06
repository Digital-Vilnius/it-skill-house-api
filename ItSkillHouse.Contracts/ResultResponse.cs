namespace ItSkillHouse.Contracts
{
    public class ResultResponse<T>
    {
        public T Result { get; set; }
        
        public ResultResponse(T result)
        {
            Result = result;
        }
    }
}