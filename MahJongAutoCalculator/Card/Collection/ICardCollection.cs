namespace MahJongAutoCalculator;

public interface ICardCollection {
	WaitType GetWaitType(Card pLast);
	int GetFu(HandInfo pHandInfo);
	bool IsOpen { get; set; }
}