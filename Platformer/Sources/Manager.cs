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
        _world.AddSystem(new ControlSystem(_world));
        _world.AddSystem(new GravitySystem(_world));
        _world.AddSystem(new CollisionSystem(_world));
        _world.AddSystem(new MovementSystem(_world));
        _world.AddSystem(new JumpSystem(_world));
        var entity1 = _world.CreateEntity();
        entity1.AddComponent(new SpriteComponent(_batcher));
        entity1.AddComponent(new PositionComponent(20, 20));
        entity1.AddComponent(new VelocityComponent(maxSpeed: 12, acceleration: 0.5f));
        entity1.AddComponent(new GravityComponent());
        entity1.AddComponent(new RigidBodyComponent());
        entity1.AddComponent(new BoxColliderComponent(100, 100));
        entity1.AddComponent(new JumpComponent());
        for (var i = 0; i < 20; i++)
        {
            var entity = _world.CreateEntity();
            entity.AddComponent(new SpriteComponent(_batcher));
            entity.AddComponent(new PositionComponent(20 + i * 100, 500));
            entity.AddComponent(new BoxColliderComponent(100, 100));
        }
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