using Capitalism.Logic.Models.Buildings;
using Capitalism.SharedKernel.Events;
using System;

namespace Capitalism.Logic.Events.BuildingEvents
{
    public class ForestWorkedEvent : IDomainEvent
    {
        public Forest Forest { get; private set; }
        public string EventType => "ForestWorkedEvent";
        public DateTime DateTimeEventOccurred { get; private set; }

        public ForestWorkedEvent(Forest forest)
        {
            this.Forest = forest;
            this.DateTimeEventOccurred = DateTime.UtcNow;
        }
    }
}
