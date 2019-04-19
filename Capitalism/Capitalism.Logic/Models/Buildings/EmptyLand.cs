using Capitalism.SharedKernel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capitalism.Logic.Models.Buildings
{
    public class EmptyLand : WritableEntity, IMappable, IOwnable
    {
        public string TownId => throw new NotImplementedException();

        public int XCoordinate => throw new NotImplementedException();

        public int YCoordinate => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public string OwnerId => throw new NotImplementedException();

        public bool IsForSale => throw new NotImplementedException();

        public int Price => throw new NotImplementedException();

        
    }
}
