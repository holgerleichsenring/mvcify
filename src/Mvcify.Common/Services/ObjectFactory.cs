﻿using System;
using System.Collections;
using Mvcify.Common.Services.Interfaces;

namespace Mvcify.Common.Services
{
    public class ObjectFactory : IObjectFactory
    {
        /// <summary>
        ///     Creates the specified class instance. Uses ctor injection to populate the dependencies.
        /// </summary>
        /// <typeparam name="T">type of object to be created</typeparam>
        /// <param name="arguments">ctor arguments in right order (dependencies will be added automatically)</param>
        /// <returns>instance of T</returns>
        public T Resolve<T>(IDictionary arguments)
        {
            return ServiceLocator.Instance.Resolve<T>(arguments);
        }

        /// <summary>
        ///     Creates the specified class instance. Uses ctor injection to populate the dependencies.
        /// </summary>
        /// <typeparam name="T">type of object to be created</typeparam>
        /// <returns>instance of T</returns>
        public T Resolve<T>()
        {
            return ServiceLocator.Instance.Resolve<T>();
        }

        /// <summary>
        ///     Creates the specified class instance. Uses ctor injection to populate the dependencies.
        /// </summary>
        /// <param name="service">type of object to be created</param>
        /// <returns>instance of specified type</returns>
        public object Resolve(Type service)
        {
            return ServiceLocator.Instance.Resolve(service);
        }
    }
}