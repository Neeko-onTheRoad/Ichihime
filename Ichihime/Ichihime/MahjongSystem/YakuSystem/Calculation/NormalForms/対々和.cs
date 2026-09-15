namespace MahJongAutoCalculator.NormalForms;


public class 対々和: NormalForm {
    public override int Id => 1014;

    public override Score Calc(Score pScore, Form pHands, Card pLastCard, HandInfo pHandInfo) {
        if (pHands.Bodies.All(body => !body.IsStraight)) {
            ApplyForm(pScore, 2);
        }
        return pScore;
    }   
}