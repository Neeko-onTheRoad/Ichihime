namespace MahJongAutoCalculator.NormalForms;

public class 小四喜: NormalForm {
    public override int Id => 1016;

    public override Score Calc(Score pScore, Form pHands, Card pLastCard, HandInfo pHandInfo) {
        var cnt = pHands.Bodies.Count(body => body.StandardCard.Type == CardType.Wind);
        if (cnt >= 3 && pHands.Head.StandardCard.Type == CardType.Wind) {
            ApplyForm(pScore, 1, true);
        }

        return pScore;
    }
}