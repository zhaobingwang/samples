using System;
using System.Collections.Generic;
using System.Text;

namespace Samples.Domain.Abstractions
{
    public abstract class Entity : IEntity
    {
        public object[] GetKeys()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class Entity<TKey> : Entity, IEntity<TKey>
    {
        public TKey Id => throw new NotImplementedException();
    }
}
