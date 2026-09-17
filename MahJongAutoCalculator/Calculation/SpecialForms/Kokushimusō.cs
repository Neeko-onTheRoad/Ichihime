namespace MahJongAutoCalculator.SpecialForms;

public class Kokushimusō: SpecialForm {
	public override int Id => -1;

	public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, HandInfo pHandInfo, bool pHaveForm) {
		Card? shootCard = null;
		Card? lastCard = null;
		foreach (var card in pHands ) {
			if (lastCard == null) {
				lastCard = card;
				continue;
			}

			if ((card.Type & CardType.Head) == CardType.None) 
				return pScore;
			if (lastCard.Equals(card)) {
				if (shootCard != null) return pScore;
				shootCard = card;
			}
			lastCard = card;
		}

		if (shootCard == null) return pScore;

		var isDouble = pLastCard.Equals(shootCard);
		if(isDouble)
			pScore.ApplyForm(1023, 2, true);
		else
			pScore.ApplyForm(1024, 1, true);
		return pScore;
	}
}