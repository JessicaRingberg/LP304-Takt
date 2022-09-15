﻿

using LP304_Takt.Models;

namespace LP304_Takt.DTO
{
    public record UserDto 
    {
        public int Id { get; init; }
        public string FirstName { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        //public string Password { get; init; } = string.Empty;

    }

}
