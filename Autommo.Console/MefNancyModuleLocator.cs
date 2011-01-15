namespace Autommo.Console
{
    #region Using Directives

    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    using Nancy;

    #endregion

    [Export(typeof(INancyModuleLocator))]
    public class MefNancyModuleLocator : INancyModuleLocator
    {
#pragma warning disable 649
        [ImportMany(typeof(NancyModule), AllowRecomposition = true)]
        private IEnumerable<NancyModule> _modules;
#pragma warning restore 649

        #region INancyModuleLocator Members

        public IEnumerable<NancyModule> GetModules()
        {
            return _modules;
        }

        #endregion
    }
}