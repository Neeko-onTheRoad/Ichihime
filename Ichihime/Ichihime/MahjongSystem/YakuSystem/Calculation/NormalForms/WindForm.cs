namespace MahJongAutoCalculator.NormalForms;

public class WindForm: NormalForm {
    public override int Id => -1;

    public override Score Calc(Score pScore, Form pHands, Card pLastCard, HandInfo pHandInfo) {
        var seatWind = pHands.Bodies.Any(body =>
            body.StandardCard is WindCard wind && wind.Direction == pHandInfo.SeatWind);
        var roundWind = pHands.Bodies.Any(body =>
                    body.StandardCard is WindCard wind && wind.Direction == pHandInfo.RoundWind);
        if (seatWind) {
            pScore.ApplyForm(1001, 1);
        }
        if (roundWind) {
            pScore.ApplyForm(1002, 1);
        }
        return pScore;
    }
}