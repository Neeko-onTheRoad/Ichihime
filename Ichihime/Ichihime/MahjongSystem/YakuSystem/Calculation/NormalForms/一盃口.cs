namespace MahJongAutoCalculator.NormalForms;

public class 一盃口: NormalForm {
    public override int Id => 1004;

    public override Score Calc(Score pScore, Form pHands, Card pLastCard, HandInfo pHandInfo) {
        if (pHandInfo is { HaveCried: true }) return pScore;
        
        var targets = pHands.Bodies.Where(body => body.IsStraight);
        Card last = null;
        var cnt = 0;
        foreach (var target in targets) {
            if (last == null) {
                last = target.StandardCard;
                continue;
            }
            if(!last.Equals(target.StandardCard)) continue;
            cnt++;
            last = null;
        }
        if(cnt == 1) ApplyForm(pScore, 1);
        return pScore;
    }
}