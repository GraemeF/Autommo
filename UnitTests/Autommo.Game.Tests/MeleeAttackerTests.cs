namespace Autommo.Game.Tests
{
    #region Using Directives

    using Autommo.Game.Interfaces;

    using NSubstitute;

    using Should.Fluent;

    using Xunit;

    #endregion

    public class MeleeAttackerTests
    {
        private readonly IUnit _newTarget = Substitute.For<IUnit>();

        private readonly MeleeAttacker _test = new MeleeAttacker();

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

        [Fact]
        public void GettingIsAttacking_Initially_ReturnsFalse()
        {
            _test.IsAttacking.Should().Be.False();
        }
    }
}