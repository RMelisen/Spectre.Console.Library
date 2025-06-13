using System.ComponentModel;
using System.Reflection;

namespace SpectreConsoleLibrary.Commons.Enums
{
    internal enum MainMenuOption
    {
        [Description("View Markup Samples")]
        ViewMarkup,
        [Description("View Table Samples")]
        ViewTable,
        [Description("Ask to Enter Data")]
        AskInput,
        Canvas,
        Quit
    }

    internal static class EnumUtils
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            if (field != null)
            {
                DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    return attribute.Description;
                }
            }

            return value.ToString();
        }
    }
}
