namespace MahJongAutoCalculator.SpecialForms;

public class Haitēraoyui: SpecialForm {
    public override int Id => 1032;

    public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, HandInfo pHandInfo, bool pHaveForm) {
        if (pHandInfo is { IsLastCard: true, IsRon: false }) {
            ApplyForm(pScore, 1);
        }

        return pScore;
    }
}