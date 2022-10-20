using System.ComponentModel.DataAnnotations;

namespace LP304_Takt.Models
{
    public Role RoleAsString { get; set; }
    [Required]
    public virtual int RoleTypeId
    {
        get
        {
            return (int)this.RoleAsString;
        }
        set
        {
            RoleAsString = (RoleAsString)value;
        }
    }
    public enum Role
    {
        Admin,
        SuperUser,
        User
    }
}
