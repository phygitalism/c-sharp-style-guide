using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LibraryNamespace;
using LibraryNamespace;
using OurNamespace;
using OurNamespace;

namespace Mandatory.Namespace
{
	/*
	 * Static members example
	 */
	public static class StaticExample
	{
		public const string Const2 = "Const2";
		private const string Const1 = "Const1";

		public static string publicStaticField;
		private static string _privateStaticField;

		static StaticExample()
		{
			PrivateStaticField = Const1 + Const1.GetHashCode();
		}

		public static string StaticProperty { get; set; }

		public static string PublicStaticMethod(string argument) => PrivateStaticMethod(argument);

		private static string PrivateStaticMethod(string argument) => argument + Const1;
	}

	public static class ExampleExtensions
	{
		public static T[] AsArray<T>(this T value) => new[] { value };

		public static IEnumerable<string> CreateString<T>(this IEnumerable<T> enumerable)
			=> enumerable.Select(val => val.ToString())
				.Aggregate((sum, val) => sum + " " + val)
				.AsArray();
	}

	/*
	 * Methods example
	 */
	public class MethodsExample
	{
		public string Name { get; set; }

		public IEnumerator<T> YieldExample<T>(T[,] valuesGrid, (int x, int y) from, (int x, int y) to)
		{
			for (int i = from.x; i <= to.x; i++)
				for (int j = from.y; j <= to.y; j++)
					yield return valuesGrid[i, j];
		}

		public void ComplexMethod<T>(IEnumerable<T> arguments) where T : class
		{
			if (arguments == null)
				throw new NullReferenceException();

			var parser = new Parser();
			var exceptions = new List<Exception>();

			foreach (var value in arguments)
				if (value != null)
				{
					StaticExample.PublicStaticMethod($"{this}.{nameof(LongMethod)} - {item}");

					if (!ValidateExample(value, parser))
						exceptions.Add(new Exception($"{value} - is not valid"));
				}
				else
					throw new NullReferenceException("One of arguments is null");

			if (exceptions.Any())
				throw new AggregateException(exceptions);
		}

		private bool ValidateExample<T>(string value, ParserExample parser)
		{
			using (var stream = new Stream())
			using (var reader = new StreamReader(stream))
			{
				try
				{
					parser.Parse<T>(reader);
					return true;
				}
				catch (Exception e)
				{
					StaticExample.PublicStaticMethod(e.Message);
					return false;
				}
			}
		}

		public void MultilineStatemenstExample()
		{
			var value = "line1"
				+ "line2"
				+ "line3";

			var value = IsValue1
				&& IsValue2
				|| IsValue3;

			var value = someObject.ChainedMethod1()
				?.ChainedMethod2()
				?.ChainedMethod3()
				?? FallbackValue;
		}

		public void LongArgsMethod(
			StructExample firstLongArgument,
			EnumExample secondLongArgument,
			FlagsExample thirdLongargument
		)
		{
			EmptyMethod();
			EmptyMethod();
		}

		public void LambdaMethod()
			=> CallBackMethod(() => EmptyMethod());

		public void LambdaMethod()
			=> CallBackMethod(() =>
			{
				for (int i = 0; i <= 10; i++)
					EmptyMethod();
			});

		public void CallBackMethod(Action action) => action();

		public void EmptyMethod() { }

		public override string ToString() => $"[{nameof(MethodsExample)}]{Name}";

		public class ParserExample
		{
			public T Parse<T>(TextReader reader) => throw new NotImplementedException();
		}
	}

	/*
	 * Complex type declaration example
	 */
	public class BaseClass { }
	public interface ISomeInterface { }
	public interface IAnotherInterface { }

	public class ComplexType<TArg1, TArg2, TArg3> : BaseClass, ISomeInterface, IAnotherInterface
		where TArg1 : IEnumerable<TArg2>
		where TArg2 : class
		where TArg3 : TArg2
	{

	}

	/*
	 * MonoBehaviour example
	 */
	[RequireComponent(typeof(Rigidbody))]
	public sealed class ComponentExample : MonoBehaviour
	{
		[Range(0, 10)]
		[SerializeField]
		private float _inspectorValue;

		private Rigidbody _rigidbody;

		public float InspectorValue
		{
			get => _inspectorValue;
			set => _inspectorValue = value;
		}

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody>();
		}

		private void Start()
		{

		}

		private void Update()
		{

		}
	}

	/*
	 * Struct example
	 */
	public struct StructExample
	{
		public int IntValue { get; private set; }
		public string StringValue { get; private set; }

		public StructExample(int intValue, string stringValue) : this()
			=> (IntValue, StringValue) = (intValue, stringValue);

		public static StructExample CreateStructExample(int intValue, string stringValue)
			=> new StructExample()
			{
				IntValue = intValue,
				StringValue = stringValue
			};
	}

	/*
	 * Enums examples
	 */
	public enum EnumExample
	{
		ValueOne,
		ValueTwo,
		ValueThree
	}

	[Flags]
	public enum FlagsExample
	{
		None = 0x0000,
		Up = 0x1000,
		Down = 0x0100,
		Left = 0x0010,
		Right = 0x0001,
		Vertical = 0x1100,
		Horizontal = 0x0011,
		All = 0x1111
	}
}
