namespace Autommo.Game.Tests
{
    #region Using Directives

    using System.Collections.Generic;
    using System.Linq;

    using Autommo.Game.Interfaces;

    using Moq;

    using ReactiveXaml;

    using Should.Fluent;

    using Xunit;

    #endregion

    public class CharacterTests
    {
        private readonly IAutoAttacker _meleeAttacker;

        private readonly Subject<IObservedChange<object, object>> _meleeAttackerPropertyChanged =
            new Subject<IObservedChange<object, object>>();

        private readonly IUnit _newTarget = Mock.Of<IUnit>();

        private readonly IUnit _originalTarget = Mock.Of<IUnit>();

        private readonly Character _test;

        public CharacterTests()
        {
            _meleeAttacker = Mocks.Of<IAutoAttacker>().
                First(autoAttacker => autoAttacker.Changed == _meleeAttackerPropertyChanged &&
                                      autoAttacker.Target == _originalTarget);

            _test = new Character(new CharacterId("test"), _meleeAttacker);
        }

        [Fact]
        public void Attack_GivenATarget_AttacksTarget()
        {
            _test.Attack(_newTarget);

            Mock.Get(_meleeAttacker).Verify(x => x.Attack(_newTarget));
        }

        [Fact]
        public void GettingCombatStatus_WhenAttackerIsAttacking_ReturnsFighting()
        {
            AttackerBeginsAttacking();

            _test.CombatStatus.Should().Equal(CombatStatus.Fighting);
        }

        [Fact]
        public void GettingCombatStatus_WhenNotAttacking_ReturnsIdle()
        {
            AttackerStopsAttacking();

            _test.CombatStatus.Should().Equal(CombatStatus.Idle);
        }

        [Fact]
        public void GettingTarget__ReturnsMeleeTarget()
        {
            _test.Target.Should().Be.SameAs(_originalTarget);
        }

        [Fact]
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

        private void AttackerStopsAttacking()
        {
            AttackerIsAttackingChangesTo(false);
        }

        private void AttackerTargetChangesTo(IUnit newTarget)
        {
            Mock.Get(_meleeAttacker).
                Setup(x => x.Target).
                Returns(newTarget);

            _meleeAttackerPropertyChanged.
                OnNext(new ObservedChange<object, object>
                           {
                               PropertyName = "Target", 
                               Value = newTarget
                           });
        }
    }
}