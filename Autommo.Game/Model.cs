namespace Autommo.Game
{
    using System;
    using System.Collections.Generic;

    using ReactiveXaml;

    public abstract class Model : ReactiveObject
    {
        protected readonly IList<IDisposable> Subscriptions = new List<IDisposable>();
    }
}