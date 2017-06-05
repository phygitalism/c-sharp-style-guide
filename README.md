## C# coding style, naming conventions, and best practices.

This is an attempt to encourage patterns that accomplish the following goals (in rough priority order):

 1. Increased rigor, and decreased likelihood of programmer error
 1. Increased clarity of intentions
 1. Increased conciseness, readability and simplicity.
 1. Fewer debates about aesthetics

Many paragraphs are borrowed from [C# Coding Standards and Naming Conventions](http://www.dofactory.com/reference/csharp-coding-standards)

Some paragraphs comes from [The Official raywenderlich.com C# Style Guide](https://github.com/raywenderlich/c-sharp-style-guide)

Also, this guide is written with keeping **Unity** in mind.

----

#### Whitespace

 * Indent with tabs, not spaces.
 * 4 spaces per tab.
 * Indentation for line wraps should use 1 tab.
 * Braces always go on their own lines.
 * End files with a newline.
 * Make liberal use of vertical whitespace to divide code into logical chunks.
 * Don't leave trailing whitespace.
   * Not even leading indentation on blank lines.

#### Use `PascalCase` for class names, property names with any access level and method names only with `public`-access level.
```cs
public class InfoPresenter
{
  private Dictionary InfoByTags { get; set; }
  public void PresentInfo()
  {
    //...
  }
}
```
_Rationale:_ consistent with the Microsoft's .NET Framework and easy to read.

#### Use `PascalCase` for interfaces, but prefix them with the letter `I`:
Interface names are noun (phrases) or adjectives.
```cs
public interface IShape
{
	public int NumberOfEdges { get; }
}

public interface IConnectable
{
	public bool Connected { get; }
}
```
_Rationale:_ consistent with the Microsoft's .NET Framework.

#### Use `PascalCase` for constants, but prefix them with the letter `k`:
Thus, do not use screaming caps for constants or readonly variables.
```cs
// Correct
public const string kShippingType = "DropShip";
 
// Avoid
public const string SHIPPINGTYPE = "DropShip";
```
_Rationale:_ caps grap too much attention.

#### Use `camelCase` for  local variables, field names with any access level, method names only with `private`-access level and method arguments.
```cs
public class User
{
  public string login;
  private string _veryStrongPassword; // prefix private fields with underscore

  private void encryptPasswordWithKey(string encryptionKey)
  {
    var somethindIncredible = 1;
    //...
  }
}
```
_Rationale:_ consistent with the Microsoft's .NET Framework and easy to read.

#### Use `PascalCase` for acronyms with 3 characters or more (2 chars are both _uppercase_):
```cs
public HtmlReader htmlReader; // .NET class
public HudController hudController; // our class
public UIController uiController; // our class
```
_Rationale:_ consistent with the Microsoft's .NET Framework.

#### Avoid using contractions.
Varible or method names must give as much clarity as possible. It's needed to help other people understand your code. Contractions can cause to misunderstanding.

Always, prefer these:
```cs
public UserGroup userGroup;
public Assignment employeeAssignment;
private int[] activeObjectIdentifiers;
```
... not these:
```cs
public UserGroup usrGrp;
public Assignment empAssignment;
private int[] activeObjIds;
```
**Exception**: contractions can be used only as acronyms for `HTML`, `XML`, `HUD` and so on.
_Rationale:_ prevents inconsistent contractions.

#### Don't use `snake_case` in _any_ identifiers. 
Always, write like that:
```cs
public class CheckBox 
{
	public enum State
	{
		Active,
		Inactive
	}
  
  public HudController hudController;

	private State currentState; // not prefixed with underscore
	public State CurrentState
	{
		get { return currentState; }
		set
		{
			currentState = value;
			var isActiveHud = (value == State.Active) ? true : false
			hudController.ShowHud(isActiveHud);
		}
	}
}
```
... not like that:
```cs
public class Check_Box 
{
	public enum State
	{
		Active,
		Inactive
	}

	public HudController hud_controller;

	private State _currentState;
	public State CurrentState
	{
		get { return _currentState; }
		set
		{
			_currentState = value;
			var is_active_Hud = (value == State.Active) ? true : false
			hud_controller.ShowHud(is_active_Hud);
		}
	}
}
```
_Rationale:_ line `hud_controller.ShowHud(is_active_Hud)` is able to show that inconsistency in naming makes code messy and illegible.

#### Don't use _Hungarian_ notation:
Don't specify any type identification in identifiers.
Write these:
```cs
public int counter;
public string name;
private Dictionary<string, string> userAnswers;
```
... not these:
```cs
public int iCounter;
public string strName;
private Dictionary<string, string> userAnswersDictionary;
```
**Exception**: it's clearly when variables have the same name as complex object.
```cs
private WebCamTexture webCamTexture;
private TextLocalizer textLocalizer;
```
_Rationale:_ you can determine type of variable very easy using IDE.

#### Use predefined type names instead of system type names like `Int32`, `String`, `Boolean`, etc
So, write these:
```cs
string firstName;
int lastIndex;
bool isSaved;
```
instead of these:
```cs
String firstName;
Int32 lastIndex;
Boolean isSaved;
```
_Rationale:_ increases interoperability of code and makes code more natural to read. 

#### Use implicit type `var` for local variable declarations.
When the type of the variable is obvious from the right side of the assignment, or when the precise type is not important.
```cs
// For any complex objects
var stream = File.Create("path/to/file.txt"); // IDE will prompt you how returned object can be treated
var customers = new Dictionary(); // when instantiating
 
// And for any primitive types (int, string, double, etc)
var index = 100; // int
var progress = 0.67f; // always add `f` to specify float
var description = "This obvious a string";
var isCompleted = false; // bool

// In loops
foreach (var item in collection)
{
	// Do something
}
```
**Exception**: do not use `var` when the type is not apparent from the right side of the assignment.
```cs
int result = ExampleClass.ResultSoFar();
```
_Rationale:_ removes clutter, particularly with complex generic types. Type is easily detected with IDE tooltips.

#### Use noun or noun phrases to name a classes and structs.
Entity must display either what it _really_ is or what it does.
```cs
public struct Employee
{
}
public class DispatcherBehaviour
{
}
public class AnimationStarter
{
}
```
_Rationale:_ showes clarity of intentions and makes easier to remember.

#### Vertically align braces.
All braces must get their own line. So, that code:
```cs
class SmartProgrammer
{
  public void WriteCode()
  {
    var loveToWriteCleanCode = true;
    if (loveToWriteCleanCode)
    {
      print("My code is pretty");
    }
    else
    {
      print("My code is messy");
    }
  }
}
```
... is nicely readable rather than that:
```cs
class PoorProgrammer {
  public void WriteCode() {
    var loveToWriteCleanCode = false;
    if (loveToWriteCleanCode) {
			print("My code is pretty");
		} else {
      print("My code is messy");
		}
  }
}
```
**Exeption**: propeties which has simple `get` or which wasn't been overwritten is better to define in one line.
```cs
public class Vehicle
{
	private float acceleration;
	public float Acceleration
	{
		get { return acceleration; }
	}

	public int NumberOfWheels { get; set; }
}
```
_Rationale:_ almost all developers have overwhelmingly preferred vertically aligned brackets.

#### Conditional statements are always required to be enclosed with braces, irrespective of the number of lines required.
Only write like that:
```cs
if (someTest) 
{
  DoSomething();
}  

if (someOtherTest)
{
  DoSomethingElse();
}
```
never like that:
```cs
if (someTest)
    doSomething();  

if (someOtherTest) doSomethingElse();
```

#### Use singular names for `enum`
For example:
```cs
public enum Direction
{
    North,
    East,
    South,
    West
}
```

#### Always specify access control explicitly for all variables and methods

All methods and variables should always have explicit access control specifiers:

```cs
public class HackerMachineRequester
{
  public int port = 60000;
	public int connectionAttemptTimeout = 10; // miliseconds
  public string hackerMachineIPAddress = "192.168.1.50";

	private IPEndPoint remoteHost // computed property
	{
		get { return new IPEndPoint(IPAddress.Parse(hackerMachineIPAddress), port); }
	}

	public void MakeRequestForPerfomingScript(string scriptName) { }
	private void establishConnection() { }
}
```
_Rationale:_ when defenitions have explicit access control specifiers, it ensures that careful thought goes into that decision.

#### Only explicitly refer to `this` when required
When accessing properties or methods on `this`, leave the reference to `this` implicit by default. Only include the explicit keyword when required by the language вЂ“ for example, when parameter names conflict:
```cs
public class History 
{
  public Event[] events;

  public History(Event[] events) 
  {
    this.events = events // `this` to escape conflict 
  }

  public Rewrite()
  {
    events = []; // no conflict
  }
}
```
_Rationale:_ helps to avoid verbosity elsewhere.

#### Use whitespace around *any* binary operators
Use whitespace around operators, such as `+`, `-`, `/`, `*`, `%`, `&&`, `||`, `+=` and so on.
```cs
var calculationResult = (2 * 8) / (7 + 3 % 2); 
var greeting = "Hello, " + lastName + " " + firstName;
var isAvailable = (exists && accessible && !alreadyInUse);
```
_Rationale:_ adding whitespace separation makes code clearly.

#### Don't use whitespace right after method name neither method declaration nor method call 
So, write these:
```cs
public void AnyMethod(); // method declaration

AnyMethod(); // method call
```
instead of:
```cs
public void AnyMethod (); // method declaration with whitespace

AnyMethod (); // method call with whitespace
```
