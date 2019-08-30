# C# code style

## SOME GENERAL RULES (mandatory)

### Naming:
- `camelCase` for fields and arguments
- `PascalCase` for types and methods
- Avoid contractions and acronyms if it's not common or well-known (e.g. `Html`, `Jpeg`)
- Identifiers should be meaningful (e.g. `vertexArray` or `loadedPage`, no `abc`, `number`)
- Names:
	- Noun for types, fields and properties (e.g. `CarDescription`, `humanNames`, `MeatBicycle`)
	- Verb for methods (e.g. `Initialize`, `UpdateState`, `KillAllHumans`)
	- Question for bool fields, properties and methods (`isDisposed`, `ShouldUpdate`, `AreValid`)
- Conventions:
	- `camelCase` for public and protected fields, variables and method arguments
	- `_camelCase` for private and internal fields
	- `PascalCase` for types, methods, properties and constants
	- `PascalCaseAsync` for `async` methods
	- `OnPascalCase` for events
	- `PascalCaseExtensions` for extension classes
	- `IPascalCase` for interfaces
	- `T` or `TPascalCase` for generic arguments
	- `PascalCaseAttribute` for attributes

### Modifiers:

- Always add access modifiers(`public`/`protected`/`internal`/`private`). Even to Unity event methods (e.g. `Awake()`, `Start()`, `Update()` etc.)
- Use `readonly` where possible

#### Modifiers order:

[`public`/`protected`/`internal`/`private`] ?[`static`] ?[`readonly`/`const`/`override`/`new`]

### Type members order:

1. Constants -> Static -> Not static -> Nested types
2. Fields -> Properties -> Events -> Constructors -> Methods
3. `public` -> `protected` -> `internal` -> `private`

### Blocks and indentation:

- Only spaces are used for indentation, one tab = 4 spaces
- Blocks begin on a new line. Exception for single line block (e.g. `{ get; set; }`, `{ }` or `{ return 0; }`)
```csharp
bool IsValid { get; set; }

void DoNothing() { }

void Initialize()
{
	foreach (var element in collection)
	{
		...
	}
}
```
- Multi line statements should start with an indentation level and an operator on every line except first
```csharp
var result = veryLongArgumentName1
	+ veryLongArgumentName2
	+ veryLongArgumentName3;

var linqResult = someEnumerable.Select(...)
	.Where(...)
	.Aggregate(...)
	.ToArray();
```
- Nested using statments should be on one indentation level
```csharp
using (var stream = new Stream(path))
using (var reader = new StringReader(stream))
{
	...
}
```
- Long arguments list should be formatted on one line per argument next to method declaration/call
```csharp
var Method(
	string arg1,
	string arg2,
	string arg
)
{
	...
}

Method(
	value1,
	value2,
	value3
);
```
## Spaces
- Should be no spaces:
	- before brackets on method declarartion/call
	- before `,` and `;`
	- before `:` in named arguments
	- before and after `.` and `?.`
	- before and after `?[`, `[` and `]`
	- before `?` for nullables (e.g. `int?`)
	- between any unary operator and argument (e.g. `++`, `!`, `(T)`)
	- after `(` and before `)`
	- after `{` and before `}` in interpolated strings
	- before and after `<` and `>` in generic types
	- before parentheses for `nameof(...)`, `typeof(...)` and `default(...)`
	- before and after indentation
	- at the end of the line
- Should be space:
	- before single line blocks
	- before and after `{` and `}` in one line
	- before and after `=`, `=>`, `??`
	- before and after `:` and `where` in type declaration
	- before and after `?` and `:` in ternary expressions
	- before and after any binary operators
		- arithmetical operators (e.g. `+`, `*`)
		- logical operators (e.g. `&&`, `||`)
		- relational operators (e.g. `==`, `<`, `>=`)
		- type operators (`as`, `is`)
	- before and after `new`
	- before parentheses in control structures: `for (...)`, `foreach (...)`, `while (...)`, `if (...)`, `catch (...)`, `lock (...)`

### `using` namespaces order

1. `System.*` namespaces
2. External dependencies (e.g. `UnityEngine`, `Zenject`, `Newtonsoft.Json`);
3. Internal dependencies (e.g. `Phygitalism.*`, `{ProjectName}.*`) 

### Misc:

- Lines should be no longer than 120 symbols. Better less than 100
- Always specify namespaces for declared types
- Avoid `this.` unless absolutely necessary
- Every attribute on its own line. Exception for argument attributes
```csharp
[Attribute1]
[Attribute2]
void SomeMethod() { ... }

void AnotherMethod([Attribute3] object argument) { ... }
```
- Use `nameof(...)` instead if `"..."`
```csharp
class SomeType
{
	string TypeName => nameof(SomeType);
}
```
- Avoid code commenting. Exception for unclear code, that can't be understood without comments.

## GENERAL ADVISES (not mandatory, but very desirable)

- Use `var` instead of type in variable declarations. Exception for primitive types(e.g. `int`, `string`, `double` etc.)
- Replace `public` fields should be replaced with properties
- Use expression syntax in methods and properties
```csharp
string SomeValue => "result";

string CreateString()
	=> enumerable.Select( ... )
		.ToString();
```
- Use string interpolation to format strings
```csharp
Console.WriteLine($"My name is {me.Name}");
```
- Split long method call chains to one call per line
- Do not use nested functions
- Do not use `#region`
- Conditional compilation should be an exception

### Inspired by:

- https://www.dofactory.com/reference/csharp-coding-standards
- https://github.com/dotnet/corefx/blob/master/Documentation/coding-guidelines/coding-style.md
- https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide
- https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines
- https://referencesource.microsoft.com
- https://github.com/Unity-Technologies/UnityCsReference
