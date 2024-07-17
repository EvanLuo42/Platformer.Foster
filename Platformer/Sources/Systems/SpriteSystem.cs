using System.Numerics;
using Foster.Framework;
using Platformer.Components;
using Platformer.ECS;

namespace Platformer.Systems;

public class SpriteSystem(World world) : ECS.System(world)
{
    private readonly World _world = world;

    public override void Render()
    {
        base.Render();
        foreach (var entity in _world.FindEntitiesByComponents(typeof(SpriteComponent), typeof(PositionComponent)))
        {
            var spriteComponent = entity.GetComponent<SpriteComponent>();
            var positionComponent = entity.GetComponent<PositionComponent>();
            var texture = new Texture(new Image(128, 128, Color.Blue));
            spriteComponent.Batcher.Image(texture,
                new Vector2(positionComponent.X, positionComponent.Y), Color.White);
            spriteComponent.Batcher.Render();
            spriteComponent.Batcher.Clear();
        }
    }
}