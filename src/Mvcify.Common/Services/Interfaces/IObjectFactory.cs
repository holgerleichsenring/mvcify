using System;
using System.Collections;

namespace Mvcify.Common.Services.Interfaces
{
    public interface IObjectFactory
    {
        /// <summary>
        ///     Creates the specified public class instances. Uses ctor injection to populate the dependencies.
        /// </summary>
        /// <typeparam name="T">type of object to be created</typeparam>
        /// <param name="arguments">ctor arguments in right order (dependencies will be added automatically)</param>
        /// <returns>instance of T</returns>
        T Resolve<T>(IDictionary arguments);

        /// <summary>
        ///     Creates the specified public class instance. Uses ctor injection to populate the dependencies.
        /// </summary>
        /// <typeparam name="T">type of object to be created</typeparam>
        /// <returns>instance of T</returns>
        T Resolve<T>();

        /// <summary>
        ///     Creates the specified class instance. Uses ctor injection to populate the dependencies.
        /// </summary>
        /// <param name="service">type of object to be created</param>
        /// <returns>instance of specified type</returns>
        object Resolve(Type service);
    }
}