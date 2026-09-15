using Ichihime.Localizing;

namespace Ichihime.Mahjong;

public abstract class Hai : IComparable<Hai> {

	//======================================================================| Properties

	public abstract Hai NextHai { get; }

	public virtual bool IsRōtōhai => false;
	public virtual bool IsYaochūhai => IsRōtōhai;
	public virtual bool IsGreen => false;

	public static IReadOnlyList<Hai> AllKinds { get; } = [
		..Sūpai.AllKindOfSūpai, ..Jihai.AllKindsOfJihai
	];

	//======================================================================| Methods

	public abstract bool IsSameKindWith(Hai? other);
	public abstract string DisplayName(StringTable stringTable);

	public int CompareTo(Hai? other) {

		var index = AllKinds.IndexOf(this);
		var otherIndex = AllKinds.IndexOf(other);

		return index.CompareTo(otherIndex);

	}

}