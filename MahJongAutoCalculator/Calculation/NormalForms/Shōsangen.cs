namespace MahJongAutoCalculator.NormalForms;

public class Shōsangen: NormalForm {
    public override int Id => 1015;

    public override Score Calc(Score pScore, Form pHands, Card pLastCard, HandInfo pHandInfo) {
        var cnt = pHands.Bodies.Count(body => body.StandardCard.Type == CardType.Letter);
        if (cnt >= 2 && pHands.Head.StandardCard.Type == CardType.Letter) {
            ApplyForm(pScore, 2);
        }

        return pScore;  
    }
}