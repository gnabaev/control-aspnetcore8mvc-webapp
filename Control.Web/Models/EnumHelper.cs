using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Control.Web.Models
{
	public class EnumHelper
	{
		public static string GetDisplayName(Enum enumValue)
		{
			return enumValue.GetType()
				.GetMember(enumValue.ToString())
				.First()
				.GetCustomAttribute<DisplayAttribute>()
				.GetName();
		}
	}
}
