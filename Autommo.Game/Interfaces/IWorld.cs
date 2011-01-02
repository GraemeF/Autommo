using ReactiveXaml;

namespace Autommo.Game.Interfaces
{
    public interface IWorld
    {
        ReactiveCollection<IUnit> Units { get; }
    }
}