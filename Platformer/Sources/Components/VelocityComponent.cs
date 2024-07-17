using System.Numerics;
using Platformer.ECS;

namespace Platformer.Components;

public class VelocityComponent(
    float x = 0,
    float y = 0,
    float maxSpeed = 15,
    float acceleration = 0.5f,
    float jumpSpeed = -20) : IComponent
{
    public Vector2 Velocity = new(x, y);
    public readonly float MaxSpeed = maxSpeed;
    public readonly float Acceleration = acceleration;
    public readonly float JumpSpeed = jumpSpeed;
}