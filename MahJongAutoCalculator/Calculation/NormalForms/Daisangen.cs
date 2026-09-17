namespace MahJongAutoCalculator.NormalForms;

public class Daisangen: NormalForm {
    public override int Id => 1012;

    public override Score Calc(Score pScore, Form pHands, Card pLastCard, HandInfo pHandInfo) {
        var cnt = pHands.Bodies.Where(body => body.StandardCard is LetterCard)
            .Select(body => body.StandardCard)
            .Distinct()
            .Count();
        if (cnt == 3) {
            ApplyForm(pScore, 1, true);
        }

        return pScore;
    }
}