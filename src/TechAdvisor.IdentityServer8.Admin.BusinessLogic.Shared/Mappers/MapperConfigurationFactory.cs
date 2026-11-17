using System;
using System.Collections.Generic;
using System.Linq;
using Mapster;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Shared.Mappers
{
    /// <summary>
    /// Builds Mapster configurations with the conventions the Admin relies on.
    /// </summary>
    public static class MapperConfigurationFactory
    {
        public static TypeAdapterConfig Create(params IRegister[] registers)
        {
            return Create((IEnumerable<IRegister>)registers);
        }

        public static TypeAdapterConfig Create(IEnumerable<Type> registerTypes)
        {
            return Create(registerTypes.Select(CreateRegister));
        }

        public static TypeAdapterConfig Create(IEnumerable<IRegister> registers)
        {
            var config = new TypeAdapterConfig();

            // Null source collections are mapped to empty collections (the AutoMapper default the views and APIs were built on)
            config.Default.AddDestinationTransform(DestinationTransform.EmptyCollectionIfNull);

            foreach (var register in registers)
            {
                register.Register(config);
            }

            // Compile eagerly so that an invalid configuration fails at startup instead of on first use
            config.Compile();

            return config;
        }

        private static IRegister CreateRegister(Type registerType)
        {
            if (!typeof(IRegister).IsAssignableFrom(registerType))
            {
                throw new ArgumentException($"Mapping type '{registerType.FullName}' must implement {typeof(IRegister).FullName}.", nameof(registerType));
            }

            return (IRegister)Activator.CreateInstance(registerType);
        }
    }
}
