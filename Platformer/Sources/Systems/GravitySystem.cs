using Foster.Framework;
using Platformer.Components;
using Platformer.ECS;

namespace Platformer.Systems;

public class GravitySystem(World world) : ECS.System(world)
{
    private readonly World _world = world;

    private const float Gravity = 10;

    public override void Update()
    {
        foreach (var entity in _world.FindEntitiesByComponents(typeof(VelocityComponent)))
        {
            var velocityComponent = entity.GetComponent<VelocityComponent>();
            velocityComponent.Velocity.Y += Gravity;
        }
    }
}