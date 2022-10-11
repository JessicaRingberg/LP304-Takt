﻿namespace LP304_Takt.DTO
{
    public record QueueDto
    {
        public int Id { get; init; }
        public ICollection<OrderDto> Orders { get; init; } = null!;
    }
}
