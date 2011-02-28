namespace Autommo.Console
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Nancy;
    using Nancy.Bootstrapper;

    #endregion

    public class AutommoBootstrapper : DefaultNancyBootstrapper
    {
        private readonly Type[] _moduleTypes = new[]
                                                   {
                                                       typeof(CharactersModule), 
                                                       typeof(MobsModule), 
                                                       typeof(NeighbourhoodModule), 
                                                       typeof(WorldModule)
                                                   };

        protected override IEnumerable<ModuleRegistration> GetModuleTypes(IModuleKeyGenerator moduleKeyGenerator)
        {
            return _moduleTypes.Select(x => new ModuleRegistration(x, moduleKeyGenerator.GetKeyForModuleType(x)));
        }
    }
}