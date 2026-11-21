using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Command.Lists;
using Command.Records;
using OpenDis.Common;
using OpenDis.Pages;

namespace Command.Watchers;

internal sealed class WatcherRuleWatcher<T> : DynamicMetaObject
{
	private delegate DynamicMetaObject RoleProcessResolver(DynamicMetaObject errorSuggestion);

	private sealed class WrapperPrototype : GetMemberBinder
	{
		internal static object observerPrototype;

		internal WrapperPrototype(InvokeMemberBinder invokeMemberBinder_0)
			: base(invokeMemberBinder_0.Name, invokeMemberBinder_0.IgnoreCase)
		{
		}

		public override DynamicMetaObject FallbackGetMember(DynamicMetaObject target, DynamicMetaObject errorSuggestion)
		{
			throw new NotSupportedException();
		}

		internal static bool TestInterruptibleMapping()
		{
			return observerPrototype == null;
		}
	}

	[CompilerGenerated]
	private sealed class IssuerPrototype
	{
		public GetMemberBinder binder;

		public WatcherRuleWatcher<T> _003C_003E4__this;

		internal DynamicMetaObject CancelInterruptibleMapping(DynamicMetaObject e)
		{
			return binder.FallbackGetMember(_003C_003E4__this, e);
		}
	}

	[CompilerGenerated]
	private sealed class ClientPrototype
	{
		public SetMemberBinder binder;

		public WatcherRuleWatcher<T> _003C_003E4__this;

		public DynamicMetaObject value;

		internal DynamicMetaObject VerifyInterruptibleMapping(DynamicMetaObject e)
		{
			return binder.FallbackSetMember(_003C_003E4__this, value, e);
		}
	}

	[CompilerGenerated]
	private sealed class DicPrototype
	{
		public DeleteMemberBinder binder;

		public WatcherRuleWatcher<T> _003C_003E4__this;

		internal DynamicMetaObject ListInterruptibleMapping(DynamicMetaObject e)
		{
			return binder.FallbackDeleteMember(_003C_003E4__this, e);
		}
	}

	[CompilerGenerated]
	private sealed class CodeDispatcherList
	{
		public ConvertBinder binder;

		public WatcherRuleWatcher<T> _003C_003E4__this;

		internal DynamicMetaObject ResolveInterruptibleMapping(DynamicMetaObject e)
		{
			return binder.FallbackConvert(_003C_003E4__this, e);
		}
	}

	[CompilerGenerated]
	private sealed class ReaderListenerMapping
	{
		public InvokeMemberBinder binder;

		public WatcherRuleWatcher<T> _003C_003E4__this;

		public DynamicMetaObject[] args;

		internal DynamicMetaObject PostInterruptibleMapping(DynamicMetaObject e)
		{
			return binder.FallbackInvokeMember(_003C_003E4__this, args, e);
		}

		internal DynamicMetaObject RunInterruptibleMapping(DynamicMetaObject e)
		{
			return binder.FallbackInvoke(e, args, null);
		}
	}

	[CompilerGenerated]
	private sealed class BroadcasterMerchantService
	{
		public CreateInstanceBinder binder;

		public WatcherRuleWatcher<T> _003C_003E4__this;

		public DynamicMetaObject[] args;

		internal DynamicMetaObject StartInterruptibleMapping(DynamicMetaObject e)
		{
			return binder.FallbackCreateInstance(_003C_003E4__this, args, e);
		}
	}

	[CompilerGenerated]
	private sealed class PredicateCallbackCandidate
	{
		public InvokeBinder binder;

		public WatcherRuleWatcher<T> _003C_003E4__this;

		public DynamicMetaObject[] args;

		internal DynamicMetaObject AssetInterruptibleMapping(DynamicMetaObject e)
		{
			return binder.FallbackInvoke(_003C_003E4__this, args, e);
		}
	}

	[CompilerGenerated]
	private sealed class ConsumerPrototype
	{
		public BinaryOperationBinder binder;

		public WatcherRuleWatcher<T> _003C_003E4__this;

		public DynamicMetaObject arg;

		internal DynamicMetaObject PrintInterruptibleMapping(DynamicMetaObject e)
		{
			return binder.FallbackBinaryOperation(_003C_003E4__this, arg, e);
		}
	}

	[CompilerGenerated]
	private sealed class DescriptorDecoratorEntry
	{
		public UnaryOperationBinder binder;

		public WatcherRuleWatcher<T> _003C_003E4__this;

		internal DynamicMetaObject DefineInterruptibleMapping(DynamicMetaObject e)
		{
			return binder.FallbackUnaryOperation(_003C_003E4__this, e);
		}
	}

	[CompilerGenerated]
	private sealed class PropertyListenerMapping
	{
		public GetIndexBinder binder;

		public WatcherRuleWatcher<T> _003C_003E4__this;

		public DynamicMetaObject[] indexes;

		internal DynamicMetaObject PublishInterruptibleMapping(DynamicMetaObject e)
		{
			return binder.FallbackGetIndex(_003C_003E4__this, indexes, e);
		}
	}

	[CompilerGenerated]
	private sealed class FacadePrototype
	{
		public SetIndexBinder binder;

		public WatcherRuleWatcher<T> _003C_003E4__this;

		public DynamicMetaObject[] indexes;

		public DynamicMetaObject value;

		internal DynamicMetaObject AwakeInterruptibleMapping(DynamicMetaObject e)
		{
			return binder.FallbackSetIndex(_003C_003E4__this, indexes, value, e);
		}
	}

	[CompilerGenerated]
	private sealed class WorkerParameterMock
	{
		public DeleteIndexBinder binder;

		public WatcherRuleWatcher<T> _003C_003E4__this;

		public DynamicMetaObject[] indexes;

		internal DynamicMetaObject QueryInterruptibleMapping(DynamicMetaObject e)
		{
			return binder.FallbackDeleteIndex(_003C_003E4__this, indexes, e);
		}
	}

	private readonly ManagerPage<T> customerProcess;

	private static object serializerProcess;

	internal WatcherRuleWatcher(Expression expression_0, T value, ManagerPage<T> managerPage_0)
		: base(expression_0, BindingRestrictions.Empty, value)
	{
		customerProcess = managerPage_0;
	}

	private bool CalculateThread(string string_0)
	{
		return ErrorProcess.CancelThread(customerProcess.GetType(), typeof(ManagerPage<T>), string_0);
	}

	public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
	{
		if (CalculateThread("TryGetMember"))
		{
			return ReadThread("TryGetMember", binder, smethod_0(), (DynamicMetaObject e) => binder.FallbackGetMember(this, e));
		}
		return base.BindGetMember(binder);
	}

	public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value)
	{
		if (CalculateThread("TrySetMember"))
		{
			return UpdateThread("TrySetMember", binder, PopThread(value), (DynamicMetaObject e) => binder.FallbackSetMember(this, value, e));
		}
		return base.BindSetMember(binder, value);
	}

	public override DynamicMetaObject BindDeleteMember(DeleteMemberBinder binder)
	{
		if (CalculateThread("TryDeleteMember"))
		{
			return InsertThread("TryDeleteMember", binder, smethod_0(), (DynamicMetaObject e) => binder.FallbackDeleteMember(this, e));
		}
		return base.BindDeleteMember(binder);
	}

	public override DynamicMetaObject BindConvert(ConvertBinder binder)
	{
		if (CalculateThread("TryConvert"))
		{
			return ReadThread("TryConvert", binder, smethod_0(), (DynamicMetaObject e) => binder.FallbackConvert(this, e));
		}
		return base.BindConvert(binder);
	}

	public override DynamicMetaObject BindInvokeMember(InvokeMemberBinder binder, DynamicMetaObject[] args)
	{
		if (CalculateThread("TryInvokeMember"))
		{
			RoleProcessResolver roleProcessResolver = (DynamicMetaObject e) => binder.FallbackInvokeMember(this, args, e);
			return DisableThread("TryInvokeMember", binder, InstantiateThread(args), DisableThread("TryGetMember", new WrapperPrototype(binder), smethod_0(), roleProcessResolver(null), (DynamicMetaObject e) => binder.FallbackInvoke(e, args, null)), null);
		}
		return base.BindInvokeMember(binder, args);
	}

	public override DynamicMetaObject BindCreateInstance(CreateInstanceBinder binder, DynamicMetaObject[] args)
	{
		if (CalculateThread("TryCreateInstance"))
		{
			return ReadThread("TryCreateInstance", binder, InstantiateThread(args), (DynamicMetaObject e) => binder.FallbackCreateInstance(this, args, e));
		}
		return base.BindCreateInstance(binder, args);
	}

	public override DynamicMetaObject BindInvoke(InvokeBinder binder, DynamicMetaObject[] args)
	{
		if (CalculateThread("TryInvoke"))
		{
			return ReadThread("TryInvoke", binder, InstantiateThread(args), (DynamicMetaObject e) => binder.FallbackInvoke(this, args, e));
		}
		return base.BindInvoke(binder, args);
	}

	public override DynamicMetaObject BindBinaryOperation(BinaryOperationBinder binder, DynamicMetaObject arg)
	{
		if (CalculateThread("TryBinaryOperation"))
		{
			return ReadThread("TryBinaryOperation", binder, PopThread(arg), (DynamicMetaObject e) => binder.FallbackBinaryOperation(this, arg, e));
		}
		return base.BindBinaryOperation(binder, arg);
	}

	public override DynamicMetaObject BindUnaryOperation(UnaryOperationBinder binder)
	{
		if (CalculateThread("TryUnaryOperation"))
		{
			return ReadThread("TryUnaryOperation", binder, smethod_0(), (DynamicMetaObject e) => binder.FallbackUnaryOperation(this, e));
		}
		return base.BindUnaryOperation(binder);
	}

	public override DynamicMetaObject BindGetIndex(GetIndexBinder binder, DynamicMetaObject[] indexes)
	{
		if (CalculateThread("TryGetIndex"))
		{
			return ReadThread("TryGetIndex", binder, InstantiateThread(indexes), (DynamicMetaObject e) => binder.FallbackGetIndex(this, indexes, e));
		}
		return base.BindGetIndex(binder, indexes);
	}

	public override DynamicMetaObject BindSetIndex(SetIndexBinder binder, DynamicMetaObject[] indexes, DynamicMetaObject value)
	{
		if (CalculateThread("TrySetIndex"))
		{
			return UpdateThread("TrySetIndex", binder, CreateThread(indexes, value), (DynamicMetaObject e) => binder.FallbackSetIndex(this, indexes, value, e));
		}
		return base.BindSetIndex(binder, indexes, value);
	}

	public override DynamicMetaObject BindDeleteIndex(DeleteIndexBinder binder, DynamicMetaObject[] indexes)
	{
		if (CalculateThread("TryDeleteIndex"))
		{
			return InsertThread("TryDeleteIndex", binder, InstantiateThread(indexes), (DynamicMetaObject e) => binder.FallbackDeleteIndex(this, indexes, e));
		}
		return base.BindDeleteIndex(binder, indexes);
	}

	[SpecialName]
	private static Expression[] smethod_0()
	{
		return ModelProcess.FindThread<Expression>();
	}

	private static IEnumerable<Expression> PopThread(params DynamicMetaObject[] args)
	{
		return args.Select(delegate(DynamicMetaObject arg)
		{
			Expression expression = arg.Expression;
			return (!expression.Type.PostThread()) ? expression : Expression.Convert(expression, typeof(object));
		});
	}

	private static Expression[] InstantiateThread(DynamicMetaObject[] dynamicMetaObject_0)
	{
		return new NewArrayExpression[1] { Expression.NewArrayInit(typeof(object), PopThread(dynamicMetaObject_0)) };
	}

	private static Expression[] CreateThread(DynamicMetaObject[] dynamicMetaObject_0, DynamicMetaObject dynamicMetaObject_1)
	{
		Expression expression = dynamicMetaObject_1.Expression;
		return new Expression[2]
		{
			Expression.NewArrayInit(typeof(object), PopThread(dynamicMetaObject_0)),
			expression.Type.PostThread() ? Expression.Convert(expression, typeof(object)) : expression
		};
	}

	private static ConstantExpression CompareThread(DynamicMetaObjectBinder dynamicMetaObjectBinder_0)
	{
		Type type = dynamicMetaObjectBinder_0.GetType();
		while (!type.ResolveThread())
		{
			type = type.ListThread();
		}
		return Expression.Constant(dynamicMetaObjectBinder_0, type);
	}

	private DynamicMetaObject ReadThread(string string_0, DynamicMetaObjectBinder dynamicMetaObjectBinder_0, IEnumerable<Expression> ienumerable_0, RoleProcessResolver roleProcessResolver_0, RoleProcessResolver roleProcessResolver_1 = null)
	{
		DynamicMetaObject dynamicMetaObject_ = roleProcessResolver_0(null);
		return DisableThread(string_0, dynamicMetaObjectBinder_0, ienumerable_0, dynamicMetaObject_, roleProcessResolver_1);
	}

	private DynamicMetaObject DisableThread(string string_0, DynamicMetaObjectBinder dynamicMetaObjectBinder_0, IEnumerable<Expression> ienumerable_0, DynamicMetaObject dynamicMetaObject_0, RoleProcessResolver roleProcessResolver_0)
	{
		ParameterExpression parameterExpression = Expression.Parameter(typeof(object), null);
		IList<Expression> list = new List<Expression>();
		list.Add(Expression.Convert(base.Expression, typeof(T)));
		list.Add(CompareThread(dynamicMetaObjectBinder_0));
		list.RemoveThread(ienumerable_0);
		list.Add(parameterExpression);
		DynamicMetaObject dynamicMetaObject = new DynamicMetaObject(parameterExpression, BindingRestrictions.Empty);
		if (dynamicMetaObjectBinder_0.ReturnType != typeof(object))
		{
			dynamicMetaObject = new DynamicMetaObject(Expression.Convert(dynamicMetaObject.Expression, dynamicMetaObjectBinder_0.ReturnType), dynamicMetaObject.Restrictions);
		}
		if (roleProcessResolver_0 != null)
		{
			dynamicMetaObject = roleProcessResolver_0(dynamicMetaObject);
		}
		return new DynamicMetaObject(Expression.Block(new ParameterExpression[1] { parameterExpression }, Expression.Condition(Expression.Call(Expression.Constant(customerProcess), typeof(ManagerPage<T>).GetMethod(string_0), list), dynamicMetaObject.Expression, dynamicMetaObject_0.Expression, dynamicMetaObjectBinder_0.ReturnType)), PrepareThread().Merge(dynamicMetaObject.Restrictions).Merge(dynamicMetaObject_0.Restrictions));
	}

	private DynamicMetaObject UpdateThread(string string_0, DynamicMetaObjectBinder dynamicMetaObjectBinder_0, IEnumerable<Expression> ienumerable_0, RoleProcessResolver roleProcessResolver_0)
	{
		DynamicMetaObject dynamicMetaObject = roleProcessResolver_0(null);
		ParameterExpression parameterExpression = Expression.Parameter(typeof(object), null);
		IList<Expression> list = new List<Expression>();
		list.Add(Expression.Convert(base.Expression, typeof(T)));
		list.Add(CompareThread(dynamicMetaObjectBinder_0));
		list.RemoveThread(ienumerable_0);
		list[list.Count - 1] = Expression.Assign(parameterExpression, list[list.Count - 1]);
		return new DynamicMetaObject(Expression.Block(new ParameterExpression[1] { parameterExpression }, Expression.Condition(Expression.Call(Expression.Constant(customerProcess), typeof(ManagerPage<T>).GetMethod(string_0), list), parameterExpression, dynamicMetaObject.Expression, typeof(object))), PrepareThread().Merge(dynamicMetaObject.Restrictions));
	}

	private DynamicMetaObject InsertThread(string string_0, DynamicMetaObjectBinder dynamicMetaObjectBinder_0, Expression[] expression_0, RoleProcessResolver roleProcessResolver_0)
	{
		DynamicMetaObject dynamicMetaObject = roleProcessResolver_0(null);
		IList<Expression> list = new List<Expression>();
		list.Add(Expression.Convert(base.Expression, typeof(T)));
		list.Add(CompareThread(dynamicMetaObjectBinder_0));
		list.RemoveThread(expression_0);
		return new DynamicMetaObject(Expression.Condition(Expression.Call(Expression.Constant(customerProcess), typeof(ManagerPage<T>).GetMethod(string_0), list), Expression.Empty(), dynamicMetaObject.Expression, typeof(void)), PrepareThread().Merge(dynamicMetaObject.Restrictions));
	}

	private BindingRestrictions PrepareThread()
	{
		if (base.Value == null && base.HasValue)
		{
			return BindingRestrictions.GetInstanceRestriction(base.Expression, null);
		}
		return BindingRestrictions.GetTypeRestriction(base.Expression, base.LimitType);
	}

	public override IEnumerable<string> GetDynamicMemberNames()
	{
		return customerProcess.GetDynamicMemberNames((T)base.Value);
	}

	internal static bool ReflectThread()
	{
		return serializerProcess == null;
	}
}
