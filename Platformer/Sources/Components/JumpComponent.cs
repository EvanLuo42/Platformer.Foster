using Platformer.ECS;

namespace Platformer.Components;

public class JumpComponent : IComponent
{
    public bool IsJumping = false;
    public readonly int MaxJumpTime = 2;
    public int JumpCount = 0;
}