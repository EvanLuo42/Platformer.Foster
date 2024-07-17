using Foster.Framework;
using Platformer.Components;
using Platformer.ECS;

namespace Platformer.Systems;

public class ControlSystem(World world) : ECS.System
{
    public override void Update()
    {
        foreach (var entity in world.FindEntitiesByComponents(typeof(VelocityComponent)))
        {
            var velocityComponent = entity.GetComponent<VelocityComponent>();
            var direction = Controls.Move.Horizontal.IntValue;
            velocityComponent.Velocity.X = Calc.Lerp(velocityComponent.Velocity.X, direction * velocityComponent.MaxSpeed, velocityComponent.Acceleration);
        }
    }

    public override float Priority()
    {
        return 1;
    }
}