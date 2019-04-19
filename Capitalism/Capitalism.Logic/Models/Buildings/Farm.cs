using Capitalism.Logic.Types;
using Capitalism.SharedKernel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capitalism.Logic.Models.Buildings
{
    public class Farm : WritableEntity, IMappable, IOwnable, IWorkable
    {
        public string TownId { get; private set; }
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }
        public string Name { get; private set; }

        public int EnergyRequirement => throw new NotImplementedException();

        public int Wage => throw new NotImplementedException();

        public string OwnerId => throw new NotImplementedException();

        public bool IsForSale => throw new NotImplementedException();

        public int Price => throw new NotImplementedException();

        

        public WorkResult Work(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
