namespace Ichihime.Mahjong;

public abstract class Jihai : Hai {

	public override bool IsYaochūhai => true;
	public override bool IsSameKindWith(Hai other) => GetType() == other.GetType();

}
