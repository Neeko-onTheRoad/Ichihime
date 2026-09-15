namespace Ichihime.Mahjong;

public abstract class Sangenpai : Jihai {

	public static IReadOnlyList<Sangenpai> AllKindsOfSangenpai { get; } = [
		new Haku(), new Hatsu(), new Chun()
	];

}