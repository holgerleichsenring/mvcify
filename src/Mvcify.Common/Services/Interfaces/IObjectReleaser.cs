namespace Mvcify.Common.Services.Interfaces
{
    /// <summary>
    ///     Contract for releasing class instances.
    /// </summary>
    public interface IObjectReleaser
    {
        void Release(object instance);
    }
}