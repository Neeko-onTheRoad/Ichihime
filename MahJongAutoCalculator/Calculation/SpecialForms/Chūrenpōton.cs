namespace MahJongAutoCalculator.SpecialForms;

public class Chūrenpōton: SpecialForm {
	public override int Id => -1;
	public override Score Calc(Score pScore, IOrderedEnumerable<Card> pHands, Card pLastCard, HandInfo pHandInfo, bool pHaveForm) {
		if (pLastCard is not NumberCard lastNumber) return pScore;
		var type = lastNumber.NumberType;
		var cnt = new int[9]; 
		foreach (var card in pHands) {
			if (card is not NumberCard number) return pScore;
			if (type != number.NumberType) return pScore;
			cnt[number.Number - 1]++;
		}

		cnt[0] -= 2;
		cnt[8] -= 2;
		var duplication = -1; 
		for (int i = 0; i < 9; i++) {
			if (cnt[i] < 1) return pScore;
			if (cnt[i] > 1) duplication = i;
		}
		if(lastNumber.Number == duplication + 1) 
			pScore.ApplyForm(1044, 2, true);
		else 
			pScore.ApplyForm(1043, 1, true);
		return pScore;	
	}
}