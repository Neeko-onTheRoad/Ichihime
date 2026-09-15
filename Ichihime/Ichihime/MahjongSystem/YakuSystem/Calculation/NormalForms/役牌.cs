namespace MahJongAutoCalculator.NormalForms;

public class 役牌: NormalForm {
    public override int Id => -1;

    public override Score Calc(Score pScore, Form pHands, Card pLastCard, HandInfo pHandInfo) {
        foreach (var body in pHands.Bodies) {
            if(body.IsStraight) continue; 
            if(body.StandardCard is not LetterCard letter) continue;
            var id = letter.LetterType switch {
                LetterType.Bloom => 10146,
                LetterType.Middle => 1047,
                LetterType.White => 1017
            };
            pScore.ApplyForm(id, 1);
        }
        return pScore;
    }
}