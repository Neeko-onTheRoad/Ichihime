namespace Ichihime.Mahjong;

public sealed class Pinzuhai(int number, bool isAkadora = true) : Sūpai(number, isAkadora) {

	public override string DisplayName => $"{Number}筒{(IsAkadora ? "*" : "")}";
	public override Hai NextHai => new Pinzuhai(Number % 9 + 1);

}