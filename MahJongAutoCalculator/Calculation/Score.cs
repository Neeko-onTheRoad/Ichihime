using System.Text;

namespace MahJongAutoCalculator;

public record HanScore(int Id, int Han);

public record DistributeScore(int Parent, int Child);

public class Score() {
	public int Fu { get; private set; }
	public bool FuLock { get; set; }
	public bool IsYakuman => _yakumans.Count > 0;
	public bool IsValid => _hans.Count > 0 || _yakumans.Count > 0;

	public int Han => IsYakuman
		? _yakumans.Aggregate(0, (han, applied) => han + applied.Han)
		: _hans.Aggregate(0, (han, applied) => han + applied.Han);

	public readonly static IReadOnlyList<(int, int)> ValueList = new List<(int, int)>() {
		(5, 8000),
		(6, 12000),
		(8, 16000),
		(11, 24000),
		(13, 32000),
	};
	public IEnumerable<HanScore> Applied => _yakumans.Count == 0 
		? _hans 
		: _yakumans;
	private List<HanScore> _hans = new();
	private List<HanScore> _yakumans = new();

	public DistributeScore GetScore(HandInfo pHandInfo) {
		if (IsYakuman) {
			var point = Han * ValueList[^1].Item2;
			if (pHandInfo.IsParent) {
				return new(0, point / 2);
			}
			return new(point / 2, point / 4);
		}

		var han = Han;
		var defaultScore = 960;
		var term = 32;
		if (ValueList[0].Item1 <= han) {
			var point = 0;
			for (int i = 0; i < ValueList.Count; i++) {
				if(han >= ValueList[i].Item1) continue;
				point = ValueList[i - 1].Item2;
				break;
			}
			if (point == 0) point = ValueList[^1].Item2;
			if (pHandInfo.IsParent) return new(0, point / 2);
			return new(point / 2, point / 4);
		}

		var fu = Fu * (1 << (han - 1)) - 30;
		var result = Math.Min(defaultScore + fu * term, 8000);
		if (pHandInfo.IsParent) return new(0, Ceil(result / 2));
		return new(Ceil(result / 2), Ceil(result / 4));

		int Ceil(int pPoint) {
			if (pPoint % 100 == 0) return pPoint;
			return pPoint - pPoint % 100 + 100;
		} 
	}
	
	public void CeilFu() {
		if (FuLock) return;
		var mod = Fu % 10;
		if (mod == 0) return;
		Fu += 10 - mod;  
	} 
    
	public void Set(int pFu = -1) {
		if (!FuLock && pFu != -1)
			Fu = pFu;
	}
    
	public void ApplyForm(int pId, int pAmount, bool pIsYakuman = false) {
		if(pIsYakuman)
			_yakumans.Add(new(pId, pAmount));
		else
			_hans.Add(new(pId, pAmount));    
	}

	public void AddFu(int pFu = 0) {
		if (FuLock) return;
		Fu += pFu;
	}
}