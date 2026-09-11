namespace Ichihime.Mahjong;

public sealed class Sōzuhai(int number, bool isAkadora = false) : Sūpai(number, isAkadora) {

	protected override string IroName => "Sō";
	public override Hai NextHai => new Sōzuhai(Number % 9 + 1);

	public override bool IsGreen => Number is 2 or 3 or 4 or 6 or 8;

	public static IEnumerable<Sōzuhai> AllKindsOfSōzuhai { get; } =
		GetAllKinds((number, isAkadora) => new Sōzuhai(number, isAkadora));

}