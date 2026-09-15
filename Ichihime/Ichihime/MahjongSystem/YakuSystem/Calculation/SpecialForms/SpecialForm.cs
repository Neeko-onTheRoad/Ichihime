namespace MahJongAutoCalculator.SpecialForms;

public abstract class SpecialForm: IForm {
    public abstract int Id { get; }
    public abstract Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, HandInfo pHandInfo, bool pHaveForm);
    protected void ApplyForm(Score pScore, int pAmount, bool pIsYakuman = false) => 
         pScore.ApplyForm(Id, pAmount, pIsYakuman);
}