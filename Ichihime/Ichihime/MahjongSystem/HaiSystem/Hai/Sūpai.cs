namespace Ichihime.Mahjong;

public abstract class Sūpai : Hai {

	//======================================================================| Fields

	public readonly int Number;
	public readonly bool IsAkadora;

	//======================================================================| Properties

	public override bool IsRōtōhai => Number is 1 or 9;

	//======================================================================| Constructors

	public Sūpai(int number, bool isAkadora = false) {
		
		ArgumentOutOfRangeException.ThrowIfLessThan(number, 1, nameof(number));
		ArgumentOutOfRangeException.ThrowIfGreaterThan(number, 9, nameof(number));

		if (isAkadora) {
			ArgumentOutOfRangeException.ThrowIfNotEqual(number, 5, nameof(number));
		}

		Number = number;
		IsAkadora = isAkadora;

	}

	//======================================================================| Methods

	public override bool IsSameKindWith(Hai other) =>
		GetType() == other.GetType() &&
		Number == (other as Sūpai)!.Number;

}
