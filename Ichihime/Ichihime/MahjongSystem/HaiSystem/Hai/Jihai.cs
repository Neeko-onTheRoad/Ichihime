namespace Ichihime.Mahjong;

public abstract class Jihai : Hai {

	//======================================================================| Properties

	public override bool IsYaochūhai => true;
	public override string DisplayName => GetType().Name;

	public static IEnumerable<Jihai> AllKindsOfJihai { get; } = [
		..Fonpai.AllKindsOfFonapi, ..Sangenpai.AllKindsOfSangenpai
	];

	//======================================================================| Methods

	public override bool IsSameKindWith(Hai other) => GetType() == other.GetType();

}
