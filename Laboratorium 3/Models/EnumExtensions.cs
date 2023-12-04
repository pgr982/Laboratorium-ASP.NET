using System.ComponentModel.DataAnnotations;
using System.Reflection;


//namespace Laboratorium_3.Models
//{
//    public static class EnumExtensions
//    {
//        public static string GetDisplayName(this Enum enumValue)
//        {
//            var memberInfo = enumValue.GetType().GetMember(enumValue.ToString()).FirstOrDefault();

//            if (memberInfo != null)
//            {
//                var displayAttribute = memberInfo.GetCustomAttribute<DisplayAttribute>();
//                return displayAttribute?.Name ?? enumValue.ToString();
//            }

//            // Obsługa sytuacji, gdy nie ma informacji o elemencie enuma
//            return enumValue.ToString();
//        }
//    }
//}


namespace Laboratorium_3.Models
{
    static public class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }
    }
}
