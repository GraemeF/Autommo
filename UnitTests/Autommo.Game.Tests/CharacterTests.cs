namespace Autommo.Game.Tests
{
    #region Using Directives

    using System.Collections.Generic;
    using System.Linq;

    using Autommo.Game.Interfaces;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using NSubstitute;

    using ReactiveUI;

    using Should.Fluent;

    #endregion

    [TestClass]
    public class CharacterTests
    {
        private readonly IAutoAttacker _meleeAttacker = Substitute.For<IAutoAttacker>();

        private readonly Subject<IObservedChange<object, object>> _meleeAttackerPropertyChanged =
            new Subject<IObservedChange<object, object>>();

        private readonly IUnit _newTarget = Substitute.For<IUnit>();

        private readonly IUnit _originalTarget = Substitute.For<IUnit>();

        private readonly Character _test;

        public CharacterTests()
        {
            _meleeAttacker.Changed.Returns(_meleeAttackerPropertyChanged);
            _meleeAttacker.Target.Returns(_originalTarget);

            _test = new Character(new CharacterId("test"), _meleeAttacker);
        }

        [TestMethod]
        public void Attack_GivenATarget_AttacksTarget()
        {
            _test.Attack(_newTarget);

            _meleeAttacker.Received().Attack(_newTarget);
        }

        [TestMethod]
        public void GettingCombatStatus_WhenAttackerIsAttacking_ReturnsFighting()
        {
            AttackerBeginsAttacking();

            _test.CombatStatus.Should().Equal(CombatStatus.Fighting);
        }

        [TestMethod]
        public void GettingCombatStatus_WhenNotAttacking_ReturnsIdle()
        {
            AttackerStopsAttacking();

            _test.CombatStatus.Should().Equal(CombatStatus.Idle);
        }

        [TestMethod]
        public void GettingTarget__ReturnsMeleeTarget()
        {
            _test.Target.Should().Be.SameAs(_originalTarget);
        }

        [TestMethod]
        public void Target_WhenMeleeTargetChanges_IsChanged()
        {
            bool changed = false;
            _test.ObservableForProperty(x => x.Target).
                Subscribe(Observer.Create<IObservedChange<Character, IUnit>>(x => changed = true));

            AttackerTargetChangesTo(_newTarget);
            changed.Should().Be.True();
        }

        private void AttackerBeginsAttacking()
        {
            AttackerIsAttackingChangesTo(true);
        }

        private void AttackerIsAttackingChangesTo(bool newValue)
        {
            _meleeAttacker.IsAttacking.Returns(newValue);

            _meleeAttackerPropertyChanged.
                OnNext(new ObservedChange<object, object>
                           {
                               PropertyName = "IsAttacking",
                               Value = newValue
                           });
        }

        private void AttackerStopsAttacking()
        {
            AttackerIsAttackingChangesTo(false);
        }

        private void AttackerTargetChangesTo(IUnit newTarget)
        {
            _meleeAttacker.Target.Returns(newTarget);

            _meleeAttackerPropertyChanged.
                OnNext(new ObservedChange<object, object>
                           {
                               PropertyName = "Target",
                               Value = newTarget
                           });
        }
    }
}