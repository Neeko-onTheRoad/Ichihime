using Ichihime.Localizing;

namespace Ichihime.Mahjong;

public abstract class Jihai : Hai {

	//======================================================================| Properties

	public override bool IsYaochūhai => true;

	public static IEnumerable<Jihai> AllKindsOfJihai => [
		..Fonpai.AllKindsOfFonapi, ..Sangenpai.AllKindsOfSangenpai
	];

	//======================================================================| Methods

	public override bool IsSameKindWith(Hai? other) => GetType() == other?.GetType();
	public override string DisplayName(StringTable stringTable) => stringTable[$"Mahjong.Jihai.{GetType().Name}"];

}
