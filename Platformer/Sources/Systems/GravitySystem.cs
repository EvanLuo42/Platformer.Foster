using Platformer.Components;
using Platformer.ECS;

namespace Platformer.Systems;

public class GravitySystem(World world) : ECS.System
{
    private const float Gravity = 10;

    public override void Update()
    {
        foreach (var entity in world.FindEntitiesByComponents(typeof(VelocityComponent)))
        {
            var velocityComponent = entity.GetComponent<VelocityComponent>();
            velocityComponent.Velocity.Y += Gravity;
        }
    }
}