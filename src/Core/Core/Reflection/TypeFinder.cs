namespace Azox.Core.Reflection
{
    using System.Reflection;
    using System.Text.RegularExpressions;

    /// <summary>
    /// 
    /// </summary>
    public class TypeFinder :
        ITypeFinder
    {
        #region Fields

        private readonly object _lock = new object();

        private List<Assembly> _assemblies;
        private readonly List<string> _assemblyDirectoryPaths;
        private readonly List<string> _assemblySkipLoadingPatterns;

        #endregion Fields

        #region Ctor

        public TypeFinder()
        {
            _assemblies = new();
            _assemblyDirectoryPaths = new()
            {
                AppDomain.CurrentDomain.BaseDirectory
            };
            _assemblySkipLoadingPatterns = new()
            {
                "^Autofac",
                "^Castle",
                "^dotnet",
                "^Humanizer",
                "^Microsoft",
                "^mscorlib",
                "^netstandard",
                "^Newtonsoft",
                "^NuGet",
                "^RestSharp",
                "^System",
                "^Swashbuckle"
            };
        }

        #endregion Ctor

        #region Utilities

        private IEnumerable<Assembly> GetAssemblies()
        {
            if (_assemblies.Count > 0)
            {
                return _assemblies;
            }

            lock (_lock)
            {
                foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    if (!Matches(assembly.FullName))
                    {
                        continue;
                    }

                    if (_assemblies.Any(x => x.FullName == assembly.FullName))
                    {
                        continue;
                    }

                    _assemblies.Add(assembly);
                }

                foreach (string directory in _assemblyDirectoryPaths)
                {
                    foreach (string assemblyFilePath in Directory.GetFiles(directory, "*.dll", SearchOption.AllDirectories))
                    {
                        try
                        {
                            AssemblyName assemblyName = AssemblyName.GetAssemblyName(assemblyFilePath);
                            if (assemblyName != null
                                && Matches(assemblyName.FullName)
                                && !_assemblies.Any(x => x.FullName == assemblyName.FullName))
                            {
                                Assembly? assembly = null;
                                try
                                {
                                    assembly = AppDomain.CurrentDomain.Load(assemblyName);
                                }
                                catch (FileNotFoundException)
                                {
                                    assembly = Assembly.LoadFrom(assemblyFilePath);
                                }
                                finally
                                {
                                    if (assembly != null)
                                    {
                                        _assemblies.Add(assembly);
                                        AppDomain.CurrentDomain.Load(assembly.GetName());
                                    }
                                }
                            }
                        }
                        catch (BadImageFormatException)
                        {
                            continue;
                        }
                    }
                }
            }

            return _assemblies;
        }

        private bool Matches(string assemblyFullName)
        {
            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Compiled;
            string pattern = string.Join("|", _assemblySkipLoadingPatterns);

            return !Regex.IsMatch(assemblyFullName, pattern, options)
                && Regex.IsMatch(assemblyFullName, ".*", options);
        }

        #endregion Utilities

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<Type> FindClassesOf<T>() =>
            FindClassesOf(typeof(T));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IEnumerable<Type> FindClassesOf(Type type)
        {
            return GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => type.IsAssignableFrom(x) && !x.IsAbstract && x.IsClass);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> FindInstancesOf<T>()
        {
            foreach (Type type in FindClassesOf<T>())
            {
                yield return (T)Activator.CreateInstance(type);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<Type> FindInterfacesOf<T>()
        {
            return GetAssemblies()
                 .SelectMany(x => x.GetTypes())
                 .Where(x => typeof(T).IsAssignableFrom(x) && x.IsInterface && typeof(T) != x);
        }

        #endregion Methods
    }
}
