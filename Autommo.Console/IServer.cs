using System;

namespace Autommo.Console
{
    public interface IServer : IDisposable
    {
        int Port { get; set; }
        void Start();
    }
}