using System;

namespace Autommo.EndToEndTestEntities
{
    public class AutommoServer : IDisposable
    {
        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        ~AutommoServer()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
        }
    }
}