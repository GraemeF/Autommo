using System.Collections.Generic;
using System.Linq;
using Autommo.Game.Interfaces;
using Moq;
using ReactiveXaml;
using Should.Fluent;
using Xunit;

namespace Autommo.Game.Tests
{
    public class PlayerTests
    {
        private readonly IAutoAttacker _meleeAttacker;

        private readonly Subject<IObservedChange<object, object>> _meleeAttackerPropertyChanged =
            new Subject<IObservedChange<object, object>>();

        private readonly IUnit _newTarget = Mock.Of<IUnit>();
        private readonly Player _test;

        public PlayerTests()
        {
            _meleeAttacker = Mocks.Of<IAutoAttacker>().
                First(autoAttacker => autoAttacker.Changed == _meleeAttackerPropertyChanged);
            _test = new Player(_meleeAttacker);
        }

        [Fact]
        public void GettingCombatStatus_WhenNotAttacking_ReturnsIdle()
        {
            AttackerStopsAttacking();

            _test.CombatStatus.Should().Equal(CombatStatus.Idle);
        }

        [Fact]
        public void GettingCombatStatus_WhenAttackerIsAttacking_ReturnsFighting()
        {
            AttackerBeginsAttacking();

            _test.CombatStatus.Should().Equal(CombatStatus.Fighting);
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

        private void AttackerStopsAttacking()
        {
            AttackerIsAttackingChangesTo(false);
        }

        private void AttackerBeginsAttacking()
        {
            AttackerIsAttackingChangesTo(true);
        }

        private void AttackerIsAttackingChangesTo(bool newValue)
        {
            Mock.Get(_meleeAttacker).
                Setup(x => x.IsAttacking).
                Returns(newValue);

            _meleeAttackerPropertyChanged.
                OnNext(new ObservedChange<object, object>
                           {
                               PropertyName = "IsAttacking",
                               Value = newValue
                           });
        }
    }
}