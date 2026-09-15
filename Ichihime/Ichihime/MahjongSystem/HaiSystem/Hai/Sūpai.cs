using Ichihime.Localizing;

namespace Ichihime.Mahjong;

public abstract class Sūpai : Hai {

	//======================================================================| Fields

	public readonly int Number;
	public readonly bool IsAkadora;

	//======================================================================| Properties

	public sealed override bool IsRōtōhai => Number is 1 or 9;

	protected abstract string IroName { get; }

	public static IReadOnlyList<Sūpai> AllKindOfSūpai { get; } = [
		..Manzuhai.AllKindsOfManzuhai, ..Pinzuhai.AllKindsOfPinzuhai, ..Sōzuhai.AllKindsOfSōzuhai
	];

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

	public override bool IsSameKindWith(Hai? other) =>
		GetType() == other?.GetType() &&
		Number == (other as Sūpai)!.Number;

	protected static IReadOnlyList<T> GetAllKinds<T>(Func<int, bool, T> factory) where T : Sūpai => [
		..Enumerable.Range(1, 5).Select(i => factory(i, false)),
		factory(5, true),
		..Enumerable.Range(6, 4).Select(i => factory(i, false))
	];

	public override string DisplayName(StringTable stringTable) =>
		stringTable[$"Mahjong.Sūpai.{GetType().Name}"]
			.Replace("{number}", Number.ToString())
			.Replace("{aka}", IsAkadora ? stringTable["Mahjong.Akadora"] : "")
			.Trim();

}
