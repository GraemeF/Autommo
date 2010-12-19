using System.Collections.Generic;
using System.ComponentModel.Composition;
using Nancy;

namespace Autommo.Console
{
    [Export(typeof (INancyModuleLocator))]
    public class MefNancyModuleLocator : INancyModuleLocator
    {
        [ImportMany(typeof (NancyModule), AllowRecomposition = true)]
        private IEnumerable<NancyModule> _modules;

        #region INancyModuleLocator Members

        public IEnumerable<NancyModule> GetModules()
        {
            return _modules;
        }

        #endregion
    }
}