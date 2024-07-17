using Foster.Framework;
using Platformer.ECS;

namespace Platformer.Components;

public class SpriteComponent(Batcher batcher) : IComponent
{
    public Batcher Batcher = batcher;
}