namespace Curseddd3.common.myevent;

public interface IEvent { }

public interface IEventHandler<in T> where T : IEvent
{
    void HandleEvent(T ev);
}

public static class EventBus
{
    private static readonly List<object> _subscribers = new();

    public static void Subscribe(object subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public static void Publish(IEvent ev)
    {
        foreach (var sub in _subscribers)
        {
            var type = sub.GetType();
            var method = type.GetMethod("HandleEvent", new[] { ev.GetType() });
            if (method != null)
            {
                method.Invoke(sub, new object[] { ev });
            }
        }
    }
}