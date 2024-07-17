namespace Platformer.ECS;

public abstract class System(World world)
{
    public virtual void Update() {}
    public virtual void Render() {}
}