using System.Collections.Generic;
using System.Linq;

namespace Marketplace.Framework
{
    public abstract class AggregateRoot<TId> where TId : Value<TId>
    {
        private readonly List<object> changes;
        protected AggregateRoot() => changes = new List<object>();
        protected abstract void When(object @event);
        protected abstract void EnsureValidState();
        protected void Apply(object @event)
        {
            When(@event);
            EnsureValidState();
            changes.Add(@event);
        }
        
        public TId Id{ get; protected set; }
        public IEnumerable<object> GetChanges() => changes.AsEnumerable();
        public void ClearChanges() => changes.Clear();
    }
}
