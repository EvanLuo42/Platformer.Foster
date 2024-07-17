using Foster.Framework;
using Platformer.Components;
using Platformer.ECS;

namespace Platformer.Systems;

public class MovementSystem(World world) : ECS.System(world)
{
    private readonly World _world = world;

    private const float MaxSpeed = 300;
    private const float Acceleration = 10;

    public override void Update()
    {
        foreach (var entity in _world.FindEntitiesByComponents(typeof(PositionComponent), typeof(VelocityComponent)))
        {
            var positionComponent = entity.GetComponent<PositionComponent>();
            var velocityComponent = entity.GetComponent<VelocityComponent>();
            var direction = Controls.Move.Horizontal.IntValue;
            velocityComponent.Velocity.X = Calc.Lerp(velocityComponent.Velocity.X, direction * MaxSpeed, Acceleration * Time.Delta);
            positionComponent.Position += velocityComponent.Velocity * Time.Delta;
        }
    }
}