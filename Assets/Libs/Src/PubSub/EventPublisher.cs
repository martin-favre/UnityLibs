using System;
using System.Collections.Generic;

namespace PubSub
{
    public class EventPublisher<KeyType> : IEventPublisher<KeyType>
    {
        readonly Dictionary<KeyType, List<Action<IEvent>>> handlers = new();

        public ISubscription Subscribe(KeyType key, Action<IEvent> handler)
        {
            return Subscribe(new KeyType[] { key }, handler);
        }

        public ISubscription Subscribe(KeyType[] keys, Action<IEvent> handler)
        {
            foreach (var key in keys)
            {
                bool success = handlers.TryGetValue(key, out List<Action<IEvent>> list);
                if (!success)
                {
                    list = new List<Action<IEvent>>();
                    handlers[key] = list;
                }
                list.Add(handler);
            }
            return new Subscription<KeyType>(keys, handler, this);
        }

        public void Unsubscribe(ISubscription hook)
        {
            var realHook = hook as Subscription<KeyType>;
            
            foreach (var key in realHook.Keys)
            {
                bool success = handlers.TryGetValue(key, out List<Action<IEvent>> list);
                if (!success) continue;
                list.Remove(realHook.Handler);
            }
        }

        public void Publish(KeyType key, IEvent ev)
        {
            bool success = handlers.TryGetValue(key, out List<Action<IEvent>> list);
            if (!success) return;
            var pubCopy = list.ToArray(); // To allow subs/unsubs when handling events
            foreach (var e in pubCopy)
            {
                e(ev);
            }
        }
    }
}