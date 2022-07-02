using System;

namespace PubSub
{
    public class KeylessEventPublisher : EventPublisher<int>
    {
        public ISubscription Subscribe(Action<IEvent> handler)
        {
            return base.Subscribe(0, handler);
        }

        public void Publish(IEvent ev)
        {
            base.Publish(0, ev);
        }
    }
}