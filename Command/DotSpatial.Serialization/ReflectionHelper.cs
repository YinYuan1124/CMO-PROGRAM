using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace DotSpatial.Serialization;

public static class ReflectionHelper
{
	[CompilerGenerated]
	private sealed class InstanceProcessProducer
	{
		public Type baseType;

		public Func<Type, bool> _003C_003E9__0;

		public Func<Type, bool> _003C_003E9__1;

		internal bool CloneInterruptibleMock(Type t)
		{
			if (t.BaseType != null && t.BaseType.IsGenericType)
			{
				return t.BaseType.GetGenericTypeDefinition().Equals(baseType);
			}
			return false;
		}

		internal bool ConnectInterruptibleMock(Type t)
		{
			if (!t.Equals(baseType))
			{
				return baseType.IsAssignableFrom(t);
			}
			return false;
		}
	}

	public static IEnumerable<Type> FindDerivedClasses<T>()
	{
		return FindDerivedClasses(typeof(T));
	}

	public static IEnumerable<Type> FindDerivedClasses(Type type_0)
	{
		List<Type> list = new List<Type>();
		string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.AllDirectories);
		string[] array = files;
		foreach (string assemblyFile in array)
		{
			Assembly assembly;
			try
			{
				assembly = Assembly.LoadFrom(assemblyFile);
			}
			catch (BadImageFormatException)
			{
				continue;
			}
			catch (FileLoadException)
			{
				continue;
			}
			try
			{
				if (type_0.IsGenericTypeDefinition)
				{
					list.AddRange(from t in assembly.GetTypes()
						where t.BaseType != null && t.BaseType.IsGenericType && t.BaseType.GetGenericTypeDefinition().Equals(type_0)
						select t);
				}
				else
				{
					list.AddRange(from t in assembly.GetTypes()
						where !t.Equals(type_0) && type_0.IsAssignableFrom(t)
						select t);
				}
			}
			catch (Exception)
			{
			}
		}
		return list;
	}
}
