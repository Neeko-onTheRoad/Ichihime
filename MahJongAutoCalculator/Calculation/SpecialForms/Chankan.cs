namespace MahJongAutoCalculator.SpecialForms;

public class Chankan: SpecialForm {
	public override int Id => 1030;

	public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, HandInfo pHandInfo, bool pHaveForm) {
		if(pHandInfo.IsStealFour) ApplyForm(pScore, 1);
		return pScore;
	}
}