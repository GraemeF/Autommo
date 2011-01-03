﻿using System;
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
        private readonly IAutoAttacker _meleeAttacker =
            Mocks.Of<IAutoAttacker>().
                First(x => x.Changed == Mock.Of<IObservable<IObservedChange<object, object>>>());

        private readonly IUnit _newTarget = Mock.Of<IUnit>();
        private readonly Player _test;

        public PlayerTests()
        {
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
            Mock.Get(_meleeAttacker).
                Setup(x => x.IsAttacking).
                Returns(true);

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
    }
}