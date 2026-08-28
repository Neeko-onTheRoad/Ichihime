namespace Ichihime;

[AttributeUsage(
	AttributeTargets.All,
	Inherited = true,
	AllowMultiple = false
)]

public sealed class MyAttribute(string identifier) : Attribute {
	public string Identifier => identifier;
}