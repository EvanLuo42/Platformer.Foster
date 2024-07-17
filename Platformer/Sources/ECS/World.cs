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
        return
            from entity in _entities
            let hasComponents = components.Aggregate(false,
                (current, component) => current && entity.HasComponent(component))
            select entity;
    }
}