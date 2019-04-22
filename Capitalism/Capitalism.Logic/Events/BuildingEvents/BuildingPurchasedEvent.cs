using Capitalism.Logic.Models;
using Capitalism.Logic.Models.Interfaces;
using Capitalism.SharedKernel.Events;
using System;

namespace Capitalism.Logic.Events.BuildingEvents
{
    public class BuildingPurchasedEvent : IDomainEvent
    {
        public IOwnable Building { get; set; }
        public Player PurchasingPlayer { get; set; }
        public string EventType => "BuildingPurchasedEvent";
        public DateTime DateTimeEventOccurred { get; private set; }

        public BuildingPurchasedEvent(IOwnable building, Player purchasingPlayer)
        {
            this.Building = building;
            this.PurchasingPlayer = purchasingPlayer;
            this.DateTimeEventOccurred = DateTime.UtcNow;
        }
    }
}
