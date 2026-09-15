namespace MahJongAutoCalculator.SpecialForms;

public class 河底撈魚: SpecialForm {
    public override int Id => 1031;

    public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, HandInfo pHandInfo, bool pHaveForm) {
        if (pHandInfo is { IsLastCard: true, IsRon: true }) {
            ApplyForm(pScore, 1);
        }
        return pScore;
    }
}