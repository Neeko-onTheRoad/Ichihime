namespace Ichihime.Mahjong;

public sealed class Manzuhai(int number, bool isAkadora = false) : Sūpai(number, isAkadora) {

	protected override string IroName => "Man";
	public override Hai NextHai => new Manzuhai(Number % 9 + 1);

	public static IEnumerable<Manzuhai> AllKindsOfManzuhai { get; } =
		GetAllKinds((number, isAkadora) => new Manzuhai(number, isAkadora));

}