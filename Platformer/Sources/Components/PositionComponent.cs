using Platformer.ECS;

namespace Platformer.Components;

public class PositionComponent(float x, float y) : IComponent
{
    public float X { get; set; } = x;
    public float Y { get; set; } = y;
}