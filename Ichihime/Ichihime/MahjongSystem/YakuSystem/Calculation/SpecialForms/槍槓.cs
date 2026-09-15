namespace MahJongAutoCalculator.SpecialForms;

public class 槍槓: SpecialForm {
	public override int Id => 1030;

	public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, HandInfo pHandInfo, bool pHaveForm) {
		if(pHandInfo.IsStealFour) ApplyForm(pScore, 1);
		return pScore;
	}
}