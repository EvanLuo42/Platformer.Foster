using Platformer.ECS;

namespace Platformer.Components;

public class GravityComponent(float gravity = 1) : IComponent
{
    public readonly float Gravity = gravity;
}