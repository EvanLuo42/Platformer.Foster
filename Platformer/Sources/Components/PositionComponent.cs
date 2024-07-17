using System.Numerics;
using Platformer.ECS;

namespace Platformer.Components;

public class PositionComponent(float x, float y) : IComponent
{
    public Vector2 Position = new(x, y);
}