using System;

namespace Capitalism.SharedKernel.Model
{
    public abstract class Entity
    {
        public string Id { get; set; }
        protected Entity() : this(Guid.NewGuid().ToString()) { }
        protected Entity(string id)
        {
            if (Equals(id, Guid.Empty.ToString()))
            {
                throw new ArgumentException("The ID cannot be the type's default value.", "id");
            }

            Id = id;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Entity;

            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            if (Id == null || other.Id == null)
                return false;

            return Id == other.Id;
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }
}
