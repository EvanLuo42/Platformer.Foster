using Platformer.Components;
using Platformer.ECS;

namespace Platformer.Systems;

public class JumpSystem(World world) : ECS.System
{
    public override void Update()
    {
        foreach (var entity in world.FindEntitiesByComponents(typeof(JumpComponent), typeof(VelocityComponent)))
        {
            var jumpComponent = entity.GetComponent<JumpComponent>();
            if (!Controls.Jump.Pressed || jumpComponent.JumpCount >= jumpComponent.MaxJumpTime) continue;
            var velocityComponent = entity.GetComponent<VelocityComponent>();
            velocityComponent.Velocity.Y = velocityComponent.JumpSpeed;
            jumpComponent.JumpCount += 1;
        }
    }

    public override float Priority()
    {
        return 9;
    }
}