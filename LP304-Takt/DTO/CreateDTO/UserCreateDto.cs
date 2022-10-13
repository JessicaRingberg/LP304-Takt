﻿namespace LP304_Takt.DTO.CreateDTO
{
    public record UserCreateDto
    {
        public string FirstName { get; init; } = null!;
        public string LastName { get; init; } = null!;
        public string Email { get; init; } = null!;
        public string Password { get; init; } = null!;
    }
}
