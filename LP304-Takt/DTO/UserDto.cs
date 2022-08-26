using LP304_Takt.Models;

namespace LP304_Takt.DTO
{
    public class UserDto
    {
        private object p;

        public UserDto(object p)
        {
            this.p = p;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual Company Company { get; set; }
        public virtual Role Role { get; set; }
    }
}
