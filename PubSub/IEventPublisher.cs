namespace PubSub
{
    public interface IEventPublisher<KeyType>
    {
        ISubscription Subscribe(KeyType key, System.Action<IEvent> handler);
        ISubscription Subscribe(KeyType[] key, System.Action<IEvent> handler);
        void Unsubscribe(ISubscription hook);
        void Publish(KeyType key, IEvent ev);
    }
}