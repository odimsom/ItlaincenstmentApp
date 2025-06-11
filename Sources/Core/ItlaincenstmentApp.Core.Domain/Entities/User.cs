﻿namespace ItlaincenstmentApp.Core.Domain.Entities
{
    public class User
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? Phone { get; set; }
        public string? ProfileImage { get; set; }
        public required string Role { get; set; }
        public ICollection<InvestmentPorfolio>? InvestmentPorfolios { get; set; }
    }
}
