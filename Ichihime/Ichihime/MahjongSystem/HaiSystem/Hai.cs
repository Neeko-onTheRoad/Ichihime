namespace Ichihime.Mahjong;

public abstract class Hai {

	public abstract string DisplayName { get; }
	public abstract Hai NextHai { get; }

	public virtual bool IsRōtōhai => false;
	public virtual bool IsYaochūhai => IsRōtōhai;
	public virtual bool IsGreen => false;

	public abstract	bool IsSameKindWith(Hai other);

}