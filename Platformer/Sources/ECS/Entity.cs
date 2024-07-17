namespace Platformer.ECS;

public class Entity
{
    private readonly Dictionary<Type, IComponent> _components = [];

    public void AddComponent<T>(T component) where T : IComponent
    {
        _components.Add(typeof(T), component);
    }

    public void AddComponent<T>() where T : IComponent, new()
    {
        _components.Add(typeof(T), new T());
    }

    public T GetComponent<T>() where T: IComponent
    {
        return (T) _components[typeof(T)];
    }

    public bool HasComponent<T>() where T : IComponent
    {
        return _components.ContainsKey(typeof(T));
    }

    public bool HasComponent(Type component)
    {
        return _components.ContainsKey(component);
    }
}