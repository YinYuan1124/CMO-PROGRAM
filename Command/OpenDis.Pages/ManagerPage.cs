using System.Collections.Generic;
using System.Dynamic;
using Command.Lists;

namespace OpenDis.Pages;

internal class ManagerPage<T>
{
	private static object advisorProcess;

	public virtual IEnumerable<string> GetDynamicMemberNames(T instance)
	{
		return ModelProcess.FindThread<string>();
	}

	public virtual bool TryBinaryOperation(T instance, BinaryOperationBinder binaryOperationBinder_0, object object_0, out object object_1)
	{
		object_1 = null;
		return false;
	}

	public virtual bool TryConvert(T instance, ConvertBinder convertBinder_0, out object object_0)
	{
		object_0 = null;
		return false;
	}

	public virtual bool TryCreateInstance(T instance, CreateInstanceBinder createInstanceBinder_0, object[] object_0, out object object_1)
	{
		object_1 = null;
		return false;
	}

	public virtual bool TryDeleteIndex(T instance, DeleteIndexBinder deleteIndexBinder_0, object[] object_0)
	{
		return false;
	}

	public virtual bool TryDeleteMember(T instance, DeleteMemberBinder deleteMemberBinder_0)
	{
		return false;
	}

	public virtual bool TryGetIndex(T instance, GetIndexBinder getIndexBinder_0, object[] object_0, out object object_1)
	{
		object_1 = null;
		return false;
	}

	public virtual bool TryGetMember(T instance, GetMemberBinder getMemberBinder_0, out object object_0)
	{
		object_0 = null;
		return false;
	}

	public virtual bool TryInvoke(T instance, InvokeBinder invokeBinder_0, object[] object_0, out object object_1)
	{
		object_1 = null;
		return false;
	}

	public virtual bool TryInvokeMember(T instance, InvokeMemberBinder invokeMemberBinder_0, object[] object_0, out object object_1)
	{
		object_1 = null;
		return false;
	}

	public virtual bool TrySetIndex(T instance, SetIndexBinder setIndexBinder_0, object[] object_0, object object_1)
	{
		return false;
	}

	public virtual bool TrySetMember(T instance, SetMemberBinder setMemberBinder_0, object object_0)
	{
		return false;
	}

	public virtual bool TryUnaryOperation(T instance, UnaryOperationBinder unaryOperationBinder_0, out object object_0)
	{
		object_0 = null;
		return false;
	}

	internal static bool SetThread()
	{
		return advisorProcess == null;
	}
}
