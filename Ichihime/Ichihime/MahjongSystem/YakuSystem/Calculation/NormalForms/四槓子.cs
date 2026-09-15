namespace MahJongAutoCalculator.NormalForms;

public class 四槓子: NormalForm {
    public override int Id => 1011;

    public override Score Calc(Score pScore, Form pHands, Card pLastCard, HandInfo pHandInfo) {
        if (pHands.Bodies.All(body => body.IsFour)) {
            ApplyForm(pScore, 1, true);
        }
        return pScore;
    }
}