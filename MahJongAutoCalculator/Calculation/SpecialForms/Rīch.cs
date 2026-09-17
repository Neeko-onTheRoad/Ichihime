namespace MahJongAutoCalculator.SpecialForms;

public class Rīch: SpecialForm {
    public override int Id => -1;

    public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, HandInfo pHandInfo,
        bool pHaveForm) {
        if(pHandInfo.IsDoubleRich)
            pScore.ApplyForm(1049, 2);
        else if (pHandInfo.IsRich)
            pScore.ApplyForm(1020, 1);
        if (pHandInfo.IsOneShot)
            pScore.ApplyForm(1021, 1);

        return pScore;
    }
}