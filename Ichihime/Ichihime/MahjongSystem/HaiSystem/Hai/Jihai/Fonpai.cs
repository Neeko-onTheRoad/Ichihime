namespace Ichihime.Mahjong;

public abstract class Fonpai : Jihai {

	public static IReadOnlyList<Fonpai> AllKindsOfFonapi { get; } = [
		new Ton(), new Nan(), new Shā(), new Pē()
	];

}