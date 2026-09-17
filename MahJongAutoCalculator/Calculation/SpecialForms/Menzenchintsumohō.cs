namespace MahJongAutoCalculator.SpecialForms;

public class Menzenchintsumohō: SpecialForm {
	public override int Id => 1038;

	public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, HandInfo pHandInfo, bool pHaveForm) {
		if (pHandInfo is { IsRon: false, HaveCried: false }) {
			ApplyForm(pScore, 1);
		}

		return pScore;
	}
}