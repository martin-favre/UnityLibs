using System;

namespace PubSub
{
    public class Subscription<KeyType> : ISubscription
    {
        private KeyType[] keys;
        private Action<IEvent> handler;
        private IEventPublisher<KeyType> eventManager;

        public Subscription(KeyType[] keys, Action<IEvent> handler, IEventPublisher<KeyType> eventManager)
        {
            this.keys = keys;
            this.handler = handler;
            this.eventManager = eventManager;
        }

        public KeyType[] Keys => keys;

        public Action<IEvent> Handler => handler;

        public void Dispose()
        {
            if(eventManager != null) eventManager.Unsubscribe(this);
            handler = null;
            eventManager = null;
            keys = null;
        }
    }

}