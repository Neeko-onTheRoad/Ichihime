namespace MahJongAutoCalculator.SpecialForms;

public class 字一色: SpecialForm {
    public override int Id => 1027;

    public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, HandInfo pHandInfo, bool pHaveForm) {
        if (pHands.All(card => (card.Type & CardType.LetterMask) != CardType.None)) {
            ApplyForm(pScore, 1, true);
        }

        return pScore;
    }
}