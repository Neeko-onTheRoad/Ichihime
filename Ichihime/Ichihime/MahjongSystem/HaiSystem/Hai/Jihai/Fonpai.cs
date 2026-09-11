namespace Ichihime.Mahjong;

public abstract class Fonpai : Jihai {

	public static IEnumerable<Fonpai> AllKindsOfFonapi { get; } = RuntimeTypeCatcher
		.GetDerivedConcreteTypes<Fonpai>()
		.Select(Activator.CreateInstance)
		.Cast<Fonpai>();

}