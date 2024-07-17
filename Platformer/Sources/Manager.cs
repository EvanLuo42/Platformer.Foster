using Foster.Framework;
using Platformer.Components;
using Platformer.ECS;
using Platformer.Systems;

namespace Platformer;

public class Manager : Module
{
    private readonly World _world = new();
    private readonly Batcher _batcher = new();

    public override void Startup()
    {
        base.Startup();
        Controls.Init();
        _world.AddSystem(new SpriteSystem(_world));
        _world.AddSystem(new MovementSystem(_world));
        _world.AddSystem(new GravitySystem(_world));
        var entity1 = _world.CreateEntity();
        entity1.AddComponent(new SpriteComponent(_batcher));
        entity1.AddComponent(new PositionComponent(20, 20));
        entity1.AddComponent<VelocityComponent>();
    }

    public override void Update()
    {
        base.Update();
        _world.Update();
    }

    public override void Render()
    {
        Graphics.Clear(0x44aa77);
        _world.Render();
        _batcher.Render();
        _batcher.Clear();
    }
}