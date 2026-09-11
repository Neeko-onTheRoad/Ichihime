namespace Ichihime.Mahjong;

public abstract class Sangenpai : Jihai {

	public static IEnumerable<Sangenpai> AllKindsOfSangenpai => RuntimeTypeCatcher
		.GetDerivedConcreteTypes<Sangenpai>()
		.Select(Activator.CreateInstance)
		.Cast<Sangenpai>();


}