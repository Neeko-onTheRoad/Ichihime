namespace MahJongAutoCalculator.SpecialForms;

public class 緑一色: SpecialForm {
	public override int Id => 1037;

	public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, HandInfo pHandInfo, bool pHaveForm) {
		if (pHands.All(card => card.IsGreen)) {
			ApplyForm(pScore, 1, true);
		}
		return pScore;
	}
}