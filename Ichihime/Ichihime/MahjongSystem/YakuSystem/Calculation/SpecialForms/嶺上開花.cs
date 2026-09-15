namespace MahJongAutoCalculator.SpecialForms;

public class 嶺上開花: SpecialForm {
    public override int Id => 1028;

    public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, HandInfo pHandInfo, bool pHaveForm) {
        if (pHandInfo is { IsOpenInKingTable: true }) {
            ApplyForm(pScore, 1);
        }

        return pScore;
    }
}