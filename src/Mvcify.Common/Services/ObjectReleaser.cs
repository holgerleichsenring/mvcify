using Mvcify.Common.Services.Interfaces;

namespace Mvcify.Common.Services
{
    public class ObjectReleaser : IObjectReleaser
    {
        /// <summary>
        ///     Releases the specified instance from dependency injection framework.
        /// </summary>
        /// <param name="instance"></param>
        public void Release(object instance)
        {
            ServiceLocator.Instance.Release(instance);
        }
    }
}