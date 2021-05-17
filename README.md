# Slutprojekt-prog
Explanations for some commonly used methods. 
```csharp
public void Update() //Updates this instance of this class. 
```
```csharp
public void Draw() //Draws this instance of this class
```
```csharp
public static void UpdateAll() //Updates every instance of this class. Contains the Update() method.
```
```csharp
public static void DrawAll() //Draws every instance of this class. Contains the Draw() method.
```
```csharp
public Class Example
{		
    public static List<Example> examples = new List<Examples>(); //a static list shared by all instances of the class "Example" where instances of the class "Example" is added.

	public Example()
	{
		examples.Add(this); //Constructor that says that every added Example in the static list "examples" is an instance of the Class "Example".
	}
}
```
