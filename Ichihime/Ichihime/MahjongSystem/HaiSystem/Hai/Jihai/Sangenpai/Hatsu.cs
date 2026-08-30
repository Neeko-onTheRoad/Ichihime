namespace Ichihime.Mahjong;

public sealed class Hatsu : Sangenpai {

	public override string DisplayName => "発";
	public override Hai NextHai => new Chun();

	public override bool IsGreen => true;

}
