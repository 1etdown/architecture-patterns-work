namespace Curseddd3.common.myevent;

public static class EventBus
{
    private static readonly List<Action<IEvent>> _subs = new();
    public static void Publish(IEvent ev)
    {
        foreach (var sub in _subs) sub(ev);
    }

    public static void Subscribe(object handler)
    {
        var methods = handler.GetType()
            .GetMethods()
            .Where(m =>
                m.GetParameters().Length == 1 &&
                typeof(IEvent).IsAssignableFrom(m.GetParameters()[0].ParameterType));

        foreach (var m in methods)
            _subs.Add(ev => m.Invoke(handler, new[] { ev }));
    }
}
