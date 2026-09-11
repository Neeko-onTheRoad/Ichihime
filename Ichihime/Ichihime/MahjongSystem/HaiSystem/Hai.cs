using Ichihime.Localizing;

namespace Ichihime.Mahjong;

public abstract class Hai {

	//======================================================================| Properties

	public abstract Hai NextHai { get; }

	public virtual bool IsRōtōhai => false;
	public virtual bool IsYaochūhai => IsRōtōhai;
	public virtual bool IsGreen => false;

	public static IEnumerable<Hai> AllKinds => [
		..Sūpai.AllKindOfSūpai, ..Jihai.AllKindsOfJihai
	];

	//======================================================================| Methods

	public abstract bool IsSameKindWith(Hai? other);
	public abstract string DisplayName(StringTable stringTable);

}