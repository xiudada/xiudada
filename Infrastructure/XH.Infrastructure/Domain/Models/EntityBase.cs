using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Infrastructure.Domain.Models
{
    /// <summary>
    /// Base entity
    /// </summary>
    public abstract class BaseEntity<TPrimaryKey>
    {
        /// <summary>
        /// Id
        /// </summary>
        public virtual TPrimaryKey Id { get; protected set; }

        /// <summary>
        /// Version handling versioning and concurrency
        /// </summary>
        public virtual int Version { get; set; }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as BaseEntity<TPrimaryKey>);
        }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public virtual bool Equals(BaseEntity<TPrimaryKey> other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (!IsTransient(this) && !IsTransient(other) && Equals(this.Id, other.Id))
            {
                var otherType = other.GetUnproxiedType();
                var thisType = this.GetUnproxiedType();

                return thisType.IsAssignableFrom(otherType) ||
                       otherType.IsAssignableFrom(thisType);
            }

            return false;
        }

        /// <summary>
        /// Get hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            if (Equals(this.Id, default(TPrimaryKey)))
            {
                return base.GetHashCode();
            }

            return Id.GetHashCode();
        }

        /// <summary>
        /// Is tranasient
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static bool IsTransient(BaseEntity<TPrimaryKey> obj)
        {
            return obj != null && Equals(obj.Id, default(TPrimaryKey));
        }

        /// <summary>
        /// Get unproxied type
        /// </summary>
        /// <returns></returns>
        private Type GetUnproxiedType()
        {
            return GetType();
        }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator ==(BaseEntity<TPrimaryKey> x, BaseEntity<TPrimaryKey> y)
        {
            return Equals(x, y);
        }

        /// <summary>
        /// Not equals
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator !=(BaseEntity<TPrimaryKey> x, BaseEntity<TPrimaryKey> y)
        {
            return !(x == y);
        }
    }

    /// <summary>
    /// Base entity
    /// </summary>
    public abstract class BaseEntity : BaseEntity<string>
    {
        /// <summary>
        /// Constuctor
        /// </summary>
        protected BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
