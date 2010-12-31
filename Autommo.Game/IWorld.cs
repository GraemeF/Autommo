using ReactiveXaml;

namespace Autommo.Game
{
    public interface IWorld
    {
        ReactiveCollection<IUnit> Units { get; }
    }
}