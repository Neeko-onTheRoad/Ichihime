namespace MahJongAutoCalculator.NormalForms;

public class Sanankō: NormalForm {
    public override int Id => 1005;

    public override Score Calc(Score pScore, Form pHands, Card pLastCard, HandInfo pHandInfo) {
        var cnt = pHands.Bodies.Count(body => body is { IsStraight: false, IsOpen: false });
        if (cnt >= 3) {
            ApplyForm(pScore, 2);
        }

        return pScore;
    }
}