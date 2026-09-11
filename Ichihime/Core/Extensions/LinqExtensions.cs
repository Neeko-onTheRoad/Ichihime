using System.ComponentModel;

[EditorBrowsable(EditorBrowsableState.Never)]
public static class LinqExtensions {

	public static T MinOrDefault<T>(this IEnumerable<T> enumerable, T @default) where T : IComparable<T> {
		if (enumerable.Any()) {
			var min = enumerable.Min();
			if (min is not null) return min;
		}
		return @default;
	}

	public static T MaxOrDefault<T>(this IEnumerable<T> enumerable, T @default) where T : IComparable<T> {
		if (enumerable.Any()) {
			var max = enumerable.Max();
			if (max is not null) return max;
		}
		return @default;
	}

	public static T MinByOrDefault<T, TKey>(this IEnumerable<T> enumerable, Func<T, TKey> keySelector, T @default) where TKey : IComparable<TKey> {
		if (enumerable.Any()) {
			var min = enumerable.MinBy(keySelector);
			if (min is not null) return min;
		}
		return @default;
	}

	public static T MaxOrDefault<T, TKey>(this IEnumerable<T> enumerable, Func<T, TKey> keySelector, T @default) where TKey : IComparable<TKey> {
		if (enumerable.Any()) {
			var max = enumerable.MaxBy(keySelector);
			if (max is not null) return max;
		}
		return @default;
	}

}