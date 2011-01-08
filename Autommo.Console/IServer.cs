namespace Autommo.Console
{
    using System;

    public interface IServer : IDisposable
    {
        int Port { get; set; }

        void Start();
    }
}