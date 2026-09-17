namespace MahJongAutoCalculator.NormalForms;

public class Junchantaiyaochū: NormalForm {
    public override int Id => 1019;

    public override Score Calc(Score pScore, Form pHands, Card pLastCard, HandInfo pHandInfo) {
        var condition1 = pHands.Bodies.All(body =>
            body is 
                { IsStraight: true, StandardCard: NumberCard { Number: 7} } or 
                { StandardCard: NumberCard {Type: CardType.Head}}
        );
        if (condition1) {
            ApplyForm(pScore, pHandInfo.HaveCried ? 2 : 3);
        }
    
        return pScore;
    }
}