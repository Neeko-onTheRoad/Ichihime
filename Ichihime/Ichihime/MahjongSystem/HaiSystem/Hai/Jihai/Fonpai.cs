namespace Ichihime.Mahjong;

public abstract class Fonpai : Jihai {

	public static IEnumerable<Fonpai> AllKindsOfFonapi => RuntimeTypeCatcher
		.GetDerivedConcreteTypes<Fonpai>()
		.Select(Activator.CreateInstance)
		.Cast<Fonpai>();

}