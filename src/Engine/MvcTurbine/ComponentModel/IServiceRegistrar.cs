namespace MvcTurbine.ComponentModel {
    using System;

    /// <summary>
    /// Process registration as a queued batch.
    /// </summary>
    public interface IServiceRegistrar : IDisposable {
        /// <summary>
        /// Registers all the services of type <typeparamref name="Interface"/> into the container.
        /// </summary>
        /// <typeparam name="Interface"></typeparam>
        void RegisterAll<Interface>();

        /// <summary>
        /// Registers the implemation type, <paramref name="implType"/>, with the locator under
        /// the <see cref="Interface"/> service type.
        /// </summary>
        /// <typeparam name="Interface">Type of the service to register.</typeparam>
        /// <param name="implType">Implementation type to use for registration.</param>
        void Register<Interface>(Type implType) where Interface : class;

        /// <summary>
        /// Registers the implemation type, <see cref="Implementation"/>, with the locator under
        /// the <see cref="Interface"/> service type.
        /// </summary>
        /// <typeparam name="Interface">Type of the service to register.</typeparam>
        /// <typeparam name="Implementation">Implementation type to use for registration.
        /// </typeparam>
        void Register<Interface, Implementation>() where Implementation : class, Interface;

        /// <summary>
        /// Registers the implemation type, <see cref="Implementation"/>, with the locator under
        /// the <see cref="Interface"/> service type.
        /// </summary>
        /// <typeparam name="Interface">Type of the service to register.</typeparam>
        /// <typeparam name="Implementation">Implementation type to use for registration.
        /// </typeparam>
        /// <param name="key">Unique key to distinguish the service.</param>
        void Register<Interface, Implementation>(string key)
        where Implementation : class, Interface;

        /// <summary>
        /// Registers the implementation type, <paramref name="type"/>, with the locator
        /// by the given string key.
        /// </summary>
        /// <param name="key">Unique key to distinguish the service.</param>
        /// <param name="type">Implementation type to use.</param>
        void Register(string key, Type type);

        /// <summary>
        /// Registers the implementation type, <paramref name="implType"/>, with the locator
        /// by the given service type, <paramref name="serviceType"/>
        /// </summary>
        /// <param name="serviceType">Type of the service to register.</param>
        /// <param name="implType">Implementation to associate with the service.</param>
        void Register(Type serviceType, Type implType);

        /// <summary>
        /// Registers the implementation type, <paramref name="implType"/>, with the locator
        /// by the given service type, <paramref name="serviceType"/>
        /// </summary>
        /// <param name="serviceType">Type of the service to register.</param>
        /// <param name="implType">Implementation to associate with the service.</param>
        /// <param name="key">Unique key to distinguish the service.</param>
        void Register(Type serviceType, Type implType, string key);

        /// <summary>
        /// Registers the instance of type, <typeparamref name="Interface"/>, with the locator.
        /// </summary>
        /// <typeparam name="Interface">Type of the service to register.</typeparam>
        /// <param name="instance">Instance of the type to register.</param>
        void Register<Interface>(Interface instance) where Interface : class;

        void Register<Interface>(Func<Interface> factoryMethod) where Interface : class;
    }
}
