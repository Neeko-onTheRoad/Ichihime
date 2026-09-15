namespace MahJongAutoCalculator;

public record HandInfo(
	bool IsParent,
	WindDirection RoundWind,
	WindDirection SeatWind,
	int NorthCnt,
	bool IsRich,
	bool IsDoubleRich,
	bool IsStealFour,
	bool IsFirstTurn,
	bool IsLastCard,
	bool IsRon,
	bool IsOneShot,
	bool IsOpenInKingTable,
	bool Nagashi
) {
	public bool HaveCried { get; set; }
}