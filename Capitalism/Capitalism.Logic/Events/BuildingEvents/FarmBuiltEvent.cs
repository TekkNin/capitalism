using Capitalism.Logic.Models;
using Capitalism.Logic.Models.Buildings;
using Capitalism.SharedKernel.Events;
using System;

namespace Capitalism.Logic.Events.BuildingEvents
{
    public class FarmBuiltEvent : IDomainEvent
    {
        public Player Player { get; set; }
        public Farm Farm { get; set; }

        public string EventType => "FarmBuiltEvent";
        public DateTime DateTimeEventOccurred { get; private set; }

        public FarmBuiltEvent(Player player, Farm farm)
        {
            this.Player = player;
            this.Farm = farm;
            this.DateTimeEventOccurred = DateTime.UtcNow;
        }
    }
}
