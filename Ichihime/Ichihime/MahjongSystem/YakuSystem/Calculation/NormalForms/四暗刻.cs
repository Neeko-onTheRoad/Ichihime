namespace MahJongAutoCalculator.NormalForms;

public class 四暗刻: NormalForm {
	public override int Id => -1;

	public override Score Calc(Score pScore, Form pHands, Card pLastCard, HandInfo pHandInfo) {
		if (pHands.Bodies.All(body => body is {IsStraight: false, IsOpen: false})) {
			var isDouble = pLastCard.Equals(pHands.Head.StandardCard);
			if(isDouble)
				pScore.ApplyForm(1045, 2, true);
			else
				pScore.ApplyForm(1010, 1, true);
		}

		return pScore;
	}
}