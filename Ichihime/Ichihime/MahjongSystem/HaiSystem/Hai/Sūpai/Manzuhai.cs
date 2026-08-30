namespace Ichihime.Mahjong;

public class Manzuhai(int number, bool isAkadora = false) : Sūpai(number, isAkadora) {

	public override string DisplayName => $"{Number}萬{(IsAkadora ? "*" : "")}";
	public override Hai NextHai => new Manzuhai(Number % 9 + 1);

}