using System.Numerics;
using Platformer.ECS;

namespace Platformer.Components;

public class VelocityComponent(float x, float y) : IComponent
{
    public Vector2 Velocity = new(x, y);

    public VelocityComponent() : this(0, 0)
    {

    }
}