using System;
using System.Collections.Generic;
using ReactiveXaml;

namespace Autommo.Game
{
    public abstract class Model : ReactiveObject
    {
        protected readonly IList<IDisposable> Subscriptions = new List<IDisposable>();
    }
}