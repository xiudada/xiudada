﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Infrastructure.Domain.Models
{
    /// <summary>
    /// Base entity
    /// </summary>
    public abstract class EntityBase<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Id
        /// </summary>
        public virtual TPrimaryKey Id { get; set; }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as EntityBase<TPrimaryKey>);
        }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public virtual bool Equals(EntityBase<TPrimaryKey> other)
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
        private static bool IsTransient(EntityBase<TPrimaryKey> obj)
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

        public bool IsTransient()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator ==(EntityBase<TPrimaryKey> x, EntityBase<TPrimaryKey> y)
        {
            return Equals(x, y);
        }

        /// <summary>
        /// Not equals
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator !=(EntityBase<TPrimaryKey> x, EntityBase<TPrimaryKey> y)
        {
            return !(x == y);
        }
    }

    /// <summary>
    /// Base entity
    /// </summary>
    public abstract class EntityBase : EntityBase<string>, IEntity<string>
    {
        /// <summary>
        /// Constuctor
        /// </summary>
        public EntityBase()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
