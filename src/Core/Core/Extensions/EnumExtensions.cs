namespace Azox.Core.Extensions
{
    using System.Collections.Concurrent;
    using System.ComponentModel;
    using System.Reflection;

    /// <summary>
    /// 
    /// </summary>
    public static class EnumExtensions
    {
        private static readonly ConcurrentDictionary<string, string> _descriptions = new();

        public static string GetDescription(this Enum @enum)
        {
            string key = $"{@enum.GetType().FullName}.{@enum}";

            string description = _descriptions.GetOrAdd(key, x =>
            {
                FieldInfo field = @enum.GetType().GetField(@enum.ToString());

                DescriptionAttribute descriptionAttribute = field
                    .GetCustomAttribute<DescriptionAttribute>();

                if (descriptionAttribute != null)
                {
                    return descriptionAttribute.Description;
                }

                return @enum.ToString();
            });

            return description;
        }
    }
}
