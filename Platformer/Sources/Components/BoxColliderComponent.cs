using Foster.Framework;
using Platformer.ECS;

namespace Platformer.Components;

public class BoxColliderComponent(float x, float y) : IComponent
{
    public Rect Rect = new(x, y);
}