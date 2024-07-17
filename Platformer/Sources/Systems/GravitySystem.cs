using Platformer.Components;
using Platformer.ECS;

namespace Platformer.Systems;

public class GravitySystem(World world) : ECS.System
{
    public override void Update()
    {
        foreach (var entity in world.FindEntitiesByComponents(typeof(VelocityComponent), typeof(GravityComponent)))
        {
            var velocityComponent = entity.GetComponent<VelocityComponent>();
            var gravityComponent = entity.GetComponent<GravityComponent>();
            velocityComponent.Velocity.Y += gravityComponent.Gravity;
        }
    }

    public override float Priority()
    {
        return 2;
    }
}