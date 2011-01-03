﻿using Autommo.Game.Interfaces;
using ReactiveXaml;

namespace Autommo.Game
{
    public class MeleeAttacker : Model, IAutoAttacker
    {
        private bool _IsAttacking;
        private Length _MaxRange;
        private IUnit _Target;

        #region IAutoAttacker Members

        public IUnit Target
        {
            get { return _Target; }
            private set { this.RaiseAndSetIfChanged(x => x.Target, value); }
        }

        public bool IsAttacking
        {
            get { return _IsAttacking; }
            private set { this.RaiseAndSetIfChanged(x => x.IsAttacking, value); }
        }

        public Length MaxRange
        {
            get { return _MaxRange; }
            private set { this.RaiseAndSetIfChanged(x => x.MaxRange, value); }
        }

        public void Attack(IUnit target)
        {
            Target = target;
            IsAttacking = true;
        }

        #endregion
    }
}