namespace Ichihime.Mahjong;

public sealed class Hatsu : Sangenpai {
	public override Hai NextHai => new Chun();
	public override bool IsGreen => true;
}
