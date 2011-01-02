using Autommo.Game.Interfaces;
using Moq;
using Should.Fluent;
using Xunit;

namespace Autommo.Game.Tests
{
    public class PlayerTests
    {
        private readonly Player _test = new Player();
        private readonly IUnit _newTarget = Mock.Of<IUnit>();

        [Fact]
        public void CombatStatus_Initially_IsIdle()
        {
            _test.CombatStatus.Should().Equal(CombatStatus.Idle);
        }

        [Fact]
        public void Attack_GivenATarget_EntersCombat()
        {
            _test.Attack(_newTarget);

            _test.CombatStatus.Should().Equal(CombatStatus.Fighting);
        }

        [Fact]
        public void Attack_GivenATarget_TargetsTarget()
        {
            _test.Attack(_newTarget);

            _test.Target.Should().Be.SameAs(_newTarget);
        }
    }
}