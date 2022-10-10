namespace Azox.Core.Reflection
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITypeFinder
    {
        /// <summary>
        /// 
        /// </summary>
        void AddDirectoryPaths(params string[] paths);

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<Type> FindClassesOf<T>();

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<Type> FindClassesOf(Type type);

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<T> FindInstancesOf<T>();

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<Type> FindInterfacesOf<T>();
    }
}
