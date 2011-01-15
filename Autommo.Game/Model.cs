namespace Autommo.Game
{
    #region Using Directives

    using System;
    using System.Collections.Generic;

    using ReactiveXaml;

    #endregion

    public abstract class Model : ReactiveObject
    {
        protected readonly IList<IDisposable> Subscriptions = new List<IDisposable>();
    }
}