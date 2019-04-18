using Capitalism.Logic.Models;
using Capitalism.Logic.Models.Buildings;
using Capitalism.SharedKernel.Events;
using System;

namespace Capitalism.Logic.Events
{
    public class PlayerWorkedEvent : IDomainEvent
    {
        public Player Player { get; private set; }
        public IWorkable Building { get; private set; }

        public string EventType => "PlayerDisplayNameUpdatedEvent";
        public DateTime DateTimeEventOccurred { get; private set; }

        public PlayerWorkedEvent(Player player, IWorkable buildinging)
        {
            this.Player = player;
            this.Building = buildinging;
            this.DateTimeEventOccurred = DateTime.UtcNow;
        }
    }
}
