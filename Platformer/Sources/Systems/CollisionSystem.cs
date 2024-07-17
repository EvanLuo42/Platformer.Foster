using Foster.Framework;
using Platformer.Components;
using Platformer.ECS;

namespace Platformer.Systems;

public class CollisionSystem(World world) : ECS.System
{
    public override void Update()
    {
        foreach (var entity in world.FindEntitiesByComponents(typeof(BoxColliderComponent)))
        {
            var boxCollider = entity.GetComponent<BoxColliderComponent>();
            var positionComponent = entity.GetComponent<PositionComponent>();
            boxCollider.Rect.Position = positionComponent.Position;
        }
        foreach (var rigidBody in world.FindEntitiesByComponents(typeof(RigidBodyComponent), typeof(BoxColliderComponent), typeof(PositionComponent), typeof(VelocityComponent)))
        {
            var boxCollider1 = rigidBody.GetComponent<BoxColliderComponent>();
            foreach (var entity in world.FindEntitiesByComponents(typeof(BoxColliderComponent)))
            {
                var boxCollider2 = entity.GetComponent<BoxColliderComponent>();
                if (boxCollider1.Rect.Position == boxCollider2.Rect.Position) continue;
                var velocityComponent = rigidBody.GetComponent<VelocityComponent>();

                var futurePosition = boxCollider1.Rect.Position + velocityComponent.Velocity;
                var futureCollider = new Rect(futurePosition.X, futurePosition.Y, boxCollider1.Rect.Width,
                    boxCollider1.Rect.Height);

                if (!futureCollider.Overlaps(boxCollider2.Rect)) continue;
                var newCollider1 = new Rect(boxCollider1.Rect.Position.X + velocityComponent.Velocity.X, boxCollider1.Rect.Position.Y, boxCollider1.Rect.Width, boxCollider1.Rect.Height);

                if (newCollider1.Overlaps(boxCollider2.Rect))
                {
                    while (!boxCollider1.Rect.Overlaps(boxCollider2.Rect))
                    {
                        boxCollider1.Rect.X += float.Sign(velocityComponent.Velocity.X);
                    }
                    boxCollider1.Rect.X -= float.Sign(velocityComponent.Velocity.X);
                    velocityComponent.Velocity.X = 0;
                }

                var newCollider2 = new Rect(boxCollider1.Rect.Position.X, boxCollider1.Rect.Position.Y + velocityComponent.Velocity.Y, boxCollider1.Rect.Width, boxCollider1.Rect.Height);

                if (newCollider2.Overlaps(boxCollider2.Rect))
                {
                    while (!boxCollider1.Rect.Overlaps(boxCollider2.Rect))
                    {
                        boxCollider1.Rect.Y += float.Sign(velocityComponent.Velocity.Y);
                    }
                    boxCollider1.Rect.Y -= float.Sign(velocityComponent.Velocity.Y);
                    velocityComponent.Velocity.Y = 0;
                }
                var positionComponent = rigidBody.GetComponent<PositionComponent>();
                positionComponent.Position = boxCollider1.Rect.Position;
            }
        }
    }

    public override float Priority()
    {
        return 3;
    }
}