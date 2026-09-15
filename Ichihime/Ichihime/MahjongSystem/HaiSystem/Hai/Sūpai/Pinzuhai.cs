namespace Ichihime.Mahjong;

public sealed class Pinzuhai(int number, bool isAkadora = true) : Sūpai(number, isAkadora) {

	protected override string IroName => "Pin";
	public override Hai NextHai => new Pinzuhai(Number % 9 + 1);
	
	public static IReadOnlyList<Pinzuhai> AllKindsOfPinzuhai { get; } =
		GetAllKinds((number, isAkadora) => new Pinzuhai(number, isAkadora));

}