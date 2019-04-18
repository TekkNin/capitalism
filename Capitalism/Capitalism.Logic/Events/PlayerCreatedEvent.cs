using Capitalism.Logic.Models;
using Capitalism.SharedKernel.Events;
using System;

namespace Capitalism.Logic.Events
{
    public class PlayerCreatedEvent : IDomainEvent
    {
        public Player Player { get; private set; }
        public string EventType => "PlayerCreatedEvent";
        public DateTime DateTimeEventOccurred { get; private set; }

        public PlayerCreatedEvent(Player player)
        {
            this.Player = player;
            this.DateTimeEventOccurred = DateTime.UtcNow;
        }
    }
}
