namespace Ichihime.Mahjong;

public abstract class Sangenpai : Jihai {

	public static IEnumerable<Sangenpai> AllKindsOfSangenpai { get; } = RuntimeTypeCatcher
		.GetDerivedConcreteTypes<Sangenpai>()
		.Select(Activator.CreateInstance)
		.Cast<Sangenpai>();


}