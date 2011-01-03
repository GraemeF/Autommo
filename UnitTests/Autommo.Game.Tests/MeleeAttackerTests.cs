using Autommo.Game.Interfaces;
using Moq;
using Should.Fluent;
using Xunit;

namespace Autommo.Game.Tests
{
    public class MeleeAttackerTests
    {
        private readonly IUnit _newTarget = Mock.Of<IUnit>();
        private readonly MeleeAttacker _test = new MeleeAttacker();

        [Fact]
        public void GettingIsAttacking_Initially_ReturnsFalse()
        {
            _test.IsAttacking.Should().Be.False();
        }

        [Fact]
        public void Attack_GivenATarget_EntersCombat()
        {
            _test.Attack(_newTarget);

            _test.IsAttacking.Should().Be.True();
        }

        [Fact]
        public void Attack_GivenATarget_TargetsTarget()
        {
            _test.Attack(_newTarget);

            _test.Target.Should().Be.SameAs(_newTarget);
        }
    }
}