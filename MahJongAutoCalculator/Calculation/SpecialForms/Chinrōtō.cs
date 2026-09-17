namespace MahJongAutoCalculator.SpecialForms;

public class Chinrōtō: SpecialForm {
    public override int Id => 1036;

    public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, HandInfo pHandInfo, bool pHaveForm) {
        if (pHands.All(card => card.Type == CardType.Head)) {
            ApplyForm(pScore, 1, true);
        }

        return pScore;
    }
}