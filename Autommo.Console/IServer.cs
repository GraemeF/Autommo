namespace Autommo.Console
{
    #region Using Directives

    using System;

    #endregion

    public interface IServer : IDisposable
    {
        int Port { get; set; }

        void Start();
    }
}