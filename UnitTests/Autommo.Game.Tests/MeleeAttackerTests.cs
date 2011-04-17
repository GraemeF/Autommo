namespace Autommo.Game.Tests
{
    #region Using Directives

    using Autommo.Game.Interfaces;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using NSubstitute;

    using Should.Fluent;

    #endregion

    [TestClass]
    public class MeleeAttackerTests
    {
        private readonly IUnit _newTarget = Substitute.For<IUnit>();

        private readonly MeleeAttacker _test = new MeleeAttacker();

        [TestMethod]
        public void Attack_GivenATarget_EntersCombat()
        {
            _test.Attack(_newTarget);

            _test.IsAttacking.Should().Be.True();
        }

        [TestMethod]
        public void Attack_GivenATarget_TargetsTarget()
        {
            _test.Attack(_newTarget);

            _test.Target.Should().Be.SameAs(_newTarget);
        }

        [TestMethod]
        public void GettingIsAttacking_Initially_ReturnsFalse()
        {
            _test.IsAttacking.Should().Be.False();
        }
    }
}