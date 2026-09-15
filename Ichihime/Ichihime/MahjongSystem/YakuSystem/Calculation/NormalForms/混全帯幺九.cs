namespace MahJongAutoCalculator.NormalForms;

public class 混全帯幺九: NormalForm {
    public override int Id => 1018;

    public override Score Calc(Score pScore, Form pHands, Card pLastCard, HandInfo pHandInfo) {
        var condition1 = pHands.Bodies.All(body =>
            (body.StandardCard.Type & CardType.Head) != CardType.None
            || body is { IsStraight: true, StandardCard: NumberCard { Number: 7 } }
        );
        var condition2 = pHands.Bodies.Any(body => body is { IsStraight: true });
        var condition3 = pHands.Bodies.Any(body => body is not { StandardCard: NumberCard });
        if (condition1 && condition2 && condition3) {
            ApplyForm(pScore, pHandInfo.HaveCried ? 1 : 2);
        }

        return pScore;
    }
}