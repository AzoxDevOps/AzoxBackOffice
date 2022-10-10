namespace Azox.XQR.Presentation.Core.Themes
{
    using Azox.Core;
    using Azox.Core.Reflection;

    using System.Text.Json;

    internal class ThemeContext :
        IThemeContext
    {
        #region Fields

        private readonly Dictionary<string, Type> _themeMainComponentTypes;

        #endregion Fields

        #region Ctor

        public ThemeContext(ITypeFinder typeFinder)
        {
            _themeMainComponentTypes = new();

            string themePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Themes");

            foreach (var item in Directory.GetFiles(themePath, "theme-info.json", SearchOption.AllDirectories))
            {
                ThemeInfo themeInfo = null;
                using (StreamReader streamReader = new(item))
                {
                    string fileContent = streamReader.ReadToEnd();
                    themeInfo = JsonSerializer.Deserialize<ThemeInfo>(fileContent);
                }

                if (themeInfo != null)
                {
                    foreach (Type componentType in typeFinder.FindClassesOf<IThemeMainComponent>())
                    {
                        if (componentType.Assembly.GetName().Name == themeInfo.SystemName)
                        {
                            _themeMainComponentTypes[$"{themeInfo.SystemName}-{themeInfo.Version}"] = componentType;
                        }
                    }
                }
            }
        }

        #endregion Ctor

        #region Methods

        public Type GetThemeMainComponentType(string themeFullName)
        {
            if (!_themeMainComponentTypes.TryGetValue(themeFullName, out Type componentType))
            {
                throw new AzoxBugException();
            }

            return componentType;
        }

        #endregion Methods
    }
}
