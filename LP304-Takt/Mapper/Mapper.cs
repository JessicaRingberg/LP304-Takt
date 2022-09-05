using LP304_Takt.DTO;
using LP304_Takt.Models;

namespace LP304_Takt.Mapper
{
    public static class Mapper
    {
        public static UserDto AsDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password
            };
        }

        public static CompanyDto AsDto(this Company company)
        {
            return new CompanyDto
            {
                Id = company.Id,
                Name = company.Name,
                Users = company.Users.Select(u => u.AsDto()).ToList(),
                Areas = company.Areas.Select(a => a.AsDto()).ToList()
            };
        }

        public static AreaDto AsDto(this Area area)
        {
            return new AreaDto
            {
                Id = area.Id,
                Name = area.Name,
                Stations = area.Stations.Select(s => s.AsDto()).ToList()
            };
        }

        public static StationDto AsDto(this Station station)
        {
            return new StationDto
            {
                Id = station.Id,
                Name = station.Name
            };
        }

        public static User AsEntity(this UserCreateDto user)
        {
            return new User
            {
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
            };
        }

        public static Company AsEntity(this CompanyCreateDto company)
        {
            return new Company
            {
                Name = company.Name
            };
        }

        public static Area AsEntity(this AreaCreateDto area)
        {
            return new Area
            {
                Name = area.Name
            };
        }

        public static Station AsEntity(this StationCreateDto station)
        {
            return new Station
            {
                Name = station.Name
            };
        }
    }
}
