namespace Autommo.Game
{
    public class CombatStatus : SimpleValue<string>
    {
        public static readonly CombatStatus Idle = new CombatStatus("Idle");
        public static readonly CombatStatus Fighting = new CombatStatus("Fighting");

        private CombatStatus(string value) : base(value)
        {
        }
    }
}