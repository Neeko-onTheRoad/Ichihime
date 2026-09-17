namespace MahJongAutoCalculator.SpecialForms;

public class Tanyaochū: SpecialForm {
    public override int Id => 1029;

    public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, HandInfo pHandInfo, bool pHaveForm) {
        if (pHands.All(card => card.Type == CardType.Middle)) {
            ApplyForm(pScore, 1);
        }
        return pScore;
    }
}