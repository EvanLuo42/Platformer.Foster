using Platformer.Components;
using Platformer.ECS;

namespace Platformer.Systems;

public class MovementSystem(World world) : ECS.System
{
    public override void Update()
    {
        foreach (var entity in world.FindEntitiesByComponents(typeof(PositionComponent), typeof(VelocityComponent)))
        {
            var positionComponent = entity.GetComponent<PositionComponent>();
            var velocityComponent = entity.GetComponent<VelocityComponent>();
            positionComponent.Position += velocityComponent.Velocity;
        }
    }

    public override float Priority()
    {
        return 100;
    }
}