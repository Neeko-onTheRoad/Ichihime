namespace MahJongAutoCalculator.NormalForms;

public abstract class NormalForm: IForm {
	public abstract int Id { get; }
    public abstract Score Calc(Score pScore, Form pHands, Card pLastCard, HandInfo pHandInfo);

    protected void ApplyForm(Score pScore, int pAmount, bool pIsYakuman = false) =>
         pScore.ApplyForm(Id, pAmount, pIsYakuman);
}