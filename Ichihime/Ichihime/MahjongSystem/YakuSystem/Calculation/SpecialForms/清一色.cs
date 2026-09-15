namespace MahJongAutoCalculator.SpecialForms;


public class 清一色: SpecialForm {
    public override int Id => 1035;

    public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, HandInfo pHandInfo, bool pHaveForm) {
        var type = NumberType.Wheel;
        bool find = false;
        foreach (var card in pHands) {
            if (card is not NumberCard number) return pScore;
            if (!find) {
                type = number.NumberType;
                find = true;
            }
            if (number.NumberType != type) return pScore;
        }

        ApplyForm(pScore, pHandInfo.HaveCried ? 5 : 6);
        return pScore;
    }
}