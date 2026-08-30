namespace Ichihime.Mahjong;

public sealed class Haku : Sangenpai {

	public override string DisplayName => "白";
	public override Hai NextHai => new Hatsu();

}