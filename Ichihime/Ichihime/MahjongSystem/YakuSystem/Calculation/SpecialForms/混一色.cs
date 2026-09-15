namespace MahJongAutoCalculator.SpecialForms;

public class 混一色: SpecialForm {
    public override int Id => 1033;

    public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, HandInfo pHandInfo, bool pHaveForm) {
        if (pHands.All(card => card is NumberCard)) return pScore;
        
        var init = false;
        NumberType type = default;
        foreach (var card in pHands) {
            if (card is not NumberCard number) continue;
            if (!init) {
                type = number.NumberType;
                continue;
            }

            if (number.NumberType != type)
                return pScore;
            
        }
        ApplyForm(pScore, pHandInfo.HaveCried ? 2 : 3);
        return pScore;
    }
}