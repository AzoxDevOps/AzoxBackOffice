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
                if (@enum.GetType().GetCustomAttribute<FlagsAttribute>() != null)
                {
                    List<string> descriptions = new();

                    foreach (var item in Enum.GetValues(@enum.GetType()))
                    {
                        if (@enum.HasFlag((Enum)item))
                        {
                            FieldInfo field = @enum.GetType().GetField(Enum.GetName(@enum.GetType(), item));

                            DescriptionAttribute descriptionAttribute = field
                                .GetCustomAttribute<DescriptionAttribute>();

                            if (descriptionAttribute != null)
                            {
                                descriptions.Add(descriptionAttribute.Description);
                            }
                            else
                            {
                                descriptions.Add(item.ToString());
                            }
                        }
                    }

                    return String.Join(", ", descriptions);
                }
                else
                {

                    FieldInfo field = @enum.GetType().GetField(@enum.ToString());

                    DescriptionAttribute descriptionAttribute = field
                        .GetCustomAttribute<DescriptionAttribute>();

                    if (descriptionAttribute != null)
                    {
                        return descriptionAttribute.Description;
                    }

                    return @enum.ToString();
                }
            });

            return description;
        }
    }
}
