﻿using System;

namespace Capitalism.SharedKernel.Model
{
    public abstract class WritableEntity : Entity
    {
        protected WritableEntity() : base()
        {
            ModifiedDate = DateTime.UtcNow;
            CreatedDate = DateTime.UtcNow;
        }

        protected WritableEntity(string id, DateTime modifiedDate, DateTime createdDate)
        {
            Id = id;
            ModifiedDate = modifiedDate;
            CreatedDate = createdDate;
        }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public void SetModifiedDate()
        {
            ModifiedDate = DateTime.UtcNow;
        }

    }
}
