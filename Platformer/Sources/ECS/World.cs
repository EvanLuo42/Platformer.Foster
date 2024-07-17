namespace Platformer.ECS;

public class World
{
    private readonly List<Entity> _entities = [];
    private readonly List<System> _systems = [];

    public Entity CreateEntity()
    {
        var entity = new Entity();
        _entities.Add(entity);
        return entity;
    }

    public void AddSystem(System system)
    {
        _systems.Add(system);
        _systems.Sort((x, y) => x.Priority().CompareTo(y.Priority()));
    }

    public void Update()
    {
        foreach (var system in _systems)
        {
            system.Update();
        }
    }

    public void Render()
    {
        foreach (var system in _systems)
        {
            system.Render();
        }
    }

    public IEnumerable<Entity> FindEntitiesByComponents(params Type[] components)
    {
        return _entities.Where(entity => components.Aggregate(true,
            (current, component) => current && entity.HasComponent(component)));
    }
}