namespace MahJongAutoCalculator.SpecialForms;

public class Chihō: SpecialForm {
    public override int Id => 1025;

    public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, HandInfo pHandInfo, bool pHaveForm) {
        if (pHandInfo.IsParent) return pScore;
        if (pHandInfo is { IsFirstTurn: true, IsRon: false }) {
            ApplyForm(pScore, 1, true);
        }

        return pScore;
    }
}