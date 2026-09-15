namespace MahJongAutoCalculator.NormalForms;

public class 三槓子: NormalForm {
    public override int Id => 1006;

    public override Score Calc(Score pScore, Form pHands, Card pLastCard, HandInfo pHandInfo) {
        if (pHands.Bodies.Count(body => body.IsFour) >= 3) {
            ApplyForm(pScore, 2);
        }
        return pScore;
    }
}