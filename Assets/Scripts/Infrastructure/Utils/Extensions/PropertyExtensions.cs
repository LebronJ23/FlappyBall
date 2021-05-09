using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace FlappyTest.Extensions
{
	public static class PropertyExtensions
	{
		public static string Description<TEnum>(this TEnum @enum) where TEnum : Enum
		{
			var name = Enum.GetName(typeof(TEnum), @enum);
			var displayName = typeof(TEnum).GetMembers().FirstOrDefault(p => p.Name == name)?.GetCustomAttribute<DescriptionAttribute>()?.Description;

			return displayName;
		}
	}
}