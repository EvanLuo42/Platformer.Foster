using System.Numerics;
using Foster.Framework;
using Platformer.Components;
using Platformer.ECS;

namespace Platformer.Systems;

public class SpriteSystem(World world) : ECS.System
{
    public override void Render()
    {
        foreach (var entity in world.FindEntitiesByComponents(typeof(SpriteComponent), typeof(PositionComponent)))
        {
            var spriteComponent = entity.GetComponent<SpriteComponent>();
            var positionComponent = entity.GetComponent<PositionComponent>();
            spriteComponent.Batcher.Rect(positionComponent.Position, new Vector2(100, 100), Color.White);
        }
    }
}