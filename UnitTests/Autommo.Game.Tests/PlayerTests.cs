using System;
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

        private readonly IUnit _newTarget = Mock.Of<IUnit>();
        private readonly Player _test;

        private readonly Subject<IObservedChange<object, object>> changed =
            new Subject<IObservedChange<object, object>>();

        private readonly IObservable<IObservedChange<object, object>> changing =
            new Subject<IObservedChange<object, object>>();

        public PlayerTests()
        {
            _meleeAttacker = Mocks.Of<IAutoAttacker>().
                First(autoAttacker => autoAttacker.Changed == changed &&
                                      autoAttacker.Changing == changing);
            _test = new Player(_meleeAttacker);
        }

        [Fact]
        public void GettingCombatStatus_WhenNotAttacking_ReturnsIdle()
        {
            Mock.Get(_meleeAttacker).
                Setup(x => x.IsAttacking).
                Returns(false);

            _test.CombatStatus.Should().Equal(CombatStatus.Idle);
        }

        [Fact]
        public void GettingCombatStatus_WhenAttackerIsAttacking_ReturnsFighting()
        {
            AttackerIsAttackingChangesTo(true);

            _test.CombatStatus.Should().Equal(CombatStatus.Fighting);
        }

        private void AttackerIsAttackingChangesTo(bool isAttacking)
        {
            Mock.Get(_meleeAttacker).
                Setup(x => x.IsAttacking).
                Returns(isAttacking);
            changed.OnNext(new ObservedChange<object, object> {PropertyName = "IsAttacking", Value = isAttacking});
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