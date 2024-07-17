namespace Platformer.ECS;

public abstract class System
{
    public virtual void Update() {}
    public virtual void Render() {}

    public virtual float Priority()
    {
        return 0;
    }
}