using Foster.Framework;

namespace Platformer.Game;

class Program
{
    public static void Main()
    {
        App.Register<Manager>();
        App.Run("Platformer", 1280, 720);
    }
}

public class Manager : Module
{

}
