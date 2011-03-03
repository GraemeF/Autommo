namespace Autommo.Console
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using AutoMapper;

    using Autommo.Game;
    using Autommo.Game.Interfaces;

    using Nancy;
    using Nancy.Bootstrapper;

    using TinyIoC;

    using Character = Autommo.Dto.Character;

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

        protected override void ConfigureApplicationContainer(TinyIoCContainer existingContainer)
        {
            base.ConfigureApplicationContainer(existingContainer);

            RegisterTypes(existingContainer);
            CreateMaps();
        }

        protected override IEnumerable<ModuleRegistration> GetModuleTypes(IModuleKeyGenerator moduleKeyGenerator)
        {
            return _moduleTypes.Select(x => new ModuleRegistration(x, moduleKeyGenerator.GetKeyForModuleType(x)));
        }

        private ICharacter CreateCharacter(CharacterId characterId)
        {
            return ResolveWithInstance<CharacterId, ICharacter>(characterId);
        }

        private void CreateMaps()
        {
            Mapper.CreateMap<ICharacter, Character>();
            Mapper.CreateMap<Character, Game.Character>();
        }

        private void OverrideRegistrationForMultiInstanceTypes(TinyIoCContainer registerWithContainer)
        {
        }

        private void RegisterAllAutommoTypesAsSingletons(TinyIoCContainer registerWithContainer)
        {
            registerWithContainer.AutoRegister(Assembly.GetExecutingAssembly());
            registerWithContainer.AutoRegister(typeof(World).Assembly);
        }

        private void RegisterFactoriesAndMappers(TinyIoCContainer registerWithContainer)
        {
            registerWithContainer.Register<Func<CharacterId, ICharacter>>(x => CreateCharacter(x));
        }

        private void RegisterTypes(TinyIoCContainer registerWithContainer)
        {
            RegisterAllAutommoTypesAsSingletons(registerWithContainer);
            OverrideRegistrationForMultiInstanceTypes(registerWithContainer);
            RegisterFactoriesAndMappers(registerWithContainer);
        }

        private TResolve ResolveWithInstance<TInstance, TResolve>(TInstance instance)
            where TInstance : class
            where TResolve : class
        {
            TinyIoCContainer childContainer = container.GetChildContainer();

            // TODO: Find out why the types resolved from the parent don't
            // pick up the instance registered with the child. They should.
            // Reregister everything for now (so parent isn't used).
            RegisterTypes(childContainer);

            childContainer.Register(instance);
            return childContainer.Resolve<TResolve>();
        }

        private TResolve ResolveWithInstance<TInstance1, TInstance2, TResolve>(TInstance1 instance1, 
                                                                               TInstance2 instance2)
            where TInstance1 : class
            where TInstance2 : class
            where TResolve : class
        {
            TinyIoCContainer childContainer = container.GetChildContainer();

            // TODO: Find out why the types resolved from the parent don't
            // pick up the instance registered with the child. They should.
            // Reregister everything for now (so parent isn't used).
            RegisterTypes(childContainer);

            childContainer.Register(instance1);
            childContainer.Register(instance2);
            return childContainer.Resolve<TResolve>();
        }
    }
}