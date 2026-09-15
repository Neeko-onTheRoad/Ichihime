namespace MahJongAutoCalculator.SpecialForms;

public class 混老頭: SpecialForm {
    public override int Id => 1034;

    public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, HandInfo pHandInfo, bool pHaveForm) {
        var correct = pHands.All(card => (card.Type & CardType.Head) != CardType.None);
        if (correct) {
            ApplyForm(pScore, 2);
        }

        return pScore;
    }
}