using LP304_Takt.DTO.ReadDto;
using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Services
{
    public interface ICompanyService : IBaseService<Company>
    {
        Task<ICollection<User>> GetUserByCompany(int companyId);
        Task<ServiceResponse<Company>> Add(Company company);
    }
}
