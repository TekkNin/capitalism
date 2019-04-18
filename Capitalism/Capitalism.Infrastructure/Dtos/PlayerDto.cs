using System;
using Capitalism.Logic.Models;
using Dapper.Contrib.Extensions;

namespace Capitalism.Infrastructure.Dtos
{
    [Table("Players")]
    public class PlayerDto
    {
        [ExplicitKey]
        public string Id { get; set; }
        public string UserId { get; set; }
        public string DisplayName { get; set; }
        public int Health { get; set; }
        public int Energy { get; set; }
        public int Happiness { get; set; }
        public int Swagger { get; set; }
        public long MoneyOnHand { get; set; }
        public int Carpentry { get; set; }
        public int Cooking { get; set; }
        public int Science { get; set; }
        public int Technology { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public Player ToPlayer()
        {
            return new Player(
                this.Id,
                this.UserId,
                this.DisplayName,
                this.Health,
                this.Energy,
                this.Happiness,
                this.Swagger,
                this.MoneyOnHand,
                new Skills(this.Carpentry, this.Cooking, this.Science, this.Technology),
                this.ModifiedDate,
                this.CreatedDate);
        }
    }

    public static class PlayerExtension
    {
        public static PlayerDto ToPlayerDto(this Player player)
        {
            return new PlayerDto
            {
                Id = player.Id,
                UserId = player.UserId,
                DisplayName = player.DisplayName,
                Health = player.Health,
                Energy = player.Energy,
                Happiness = player.Happiness,
                Swagger = player.Swagger,
                MoneyOnHand = player.MoneyOnHand,
                Carpentry = player.Skills.Carpentry,
                Cooking = player.Skills.Cooking,
                Science = player.Skills.Science,
                Technology = player.Skills.Technology,
                ModifiedDate = player.ModifiedDate,
                CreatedDate = player.CreatedDate
            };
        }
    }
}
