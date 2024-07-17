using Foster.Framework;

namespace Platformer;

public class Controls
{
    public static readonly VirtualStick Move = new();

    public static void Init()
    {
        Move.AddLeftJoystick(0, 0.2f, 0.2f);
        Move.Add(0, Buttons.Left, Buttons.Right, Buttons.Up, Buttons.Down);
        Move.Add(Keys.Left, Keys.Right, Keys.Up, Keys.Down);
    }
}