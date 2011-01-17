namespace Autommo.Game
{
    #region Using Directives

    using System;
    using System.Collections.Generic;

    using ReactiveUI;

    #endregion

    public abstract class Model : ReactiveObject
    {
        protected readonly IList<IDisposable> Subscriptions = new List<IDisposable>();
    }
}