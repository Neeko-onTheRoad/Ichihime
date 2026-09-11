using System.Diagnostics.CodeAnalysis;

namespace Ichihime.Mahjong;

public class HaiKindEqualityComparer : IEqualityComparer<Hai> {

	public bool Equals(Hai? x, Hai? y) =>
		ReferenceEquals(x, y) ||
		(x?.IsSameKindWith(y) ?? false);

	public int GetHashCode([DisallowNull] Hai obj) {

		if (obj is not Sūpai sūpai)
			return obj.GetType().GetHashCode();

		return HashCode.Combine(sūpai.GetType(), sūpai.Number, sūpai.IsAkadora);

	}

}