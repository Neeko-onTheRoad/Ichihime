namespace MahJongAutoCalculator;
public class Head: ICardCollection {
	public bool IsOpen { get; set; }
	public readonly Card StandardCard;
	
	public Head(Card pStandardCard) => StandardCard = pStandardCard;
	public override string ToString() => $"{StandardCard} x 2";
	
	public WaitType GetWaitType(Card pLast) =>
		pLast.CompareTo(StandardCard) == 0 ? MahJongAutoCalculator.WaitType.SingleHead : MahJongAutoCalculator.WaitType.Except;
	
	public int GetFu(HandInfo pHandInfo) {
		var v = 0;
		if (StandardCard is WindCard wind) {
			if (wind.Direction == pHandInfo.RoundWind)
				v += 2;
			if (wind.Direction == pHandInfo.SeatWind)
				v += 2;
		}

		if (StandardCard is LetterCard) v += 2;
		return v;
	}

}