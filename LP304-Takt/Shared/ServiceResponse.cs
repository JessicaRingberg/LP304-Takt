using LP304_Takt.DTO;

namespace LP304_Takt.Shared
{
    public class ServiceResponse<T> 
    {
        public T? Data { get; set; }
        public bool Success { get; set; } = false;
        public string Message { get; set; } = null!;
        
        
    }
}
