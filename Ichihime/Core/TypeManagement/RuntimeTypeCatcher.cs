public static class RuntimeTypeCatcher {

	//======================================================================| Fields

	private static readonly HashSet<Type> _types = [..AppDomain.CurrentDomain
		.GetAssemblies()
		.SelectMany(assembly => assembly.DefinedTypes)
		.Select(typeInfo => typeInfo.AsType())
	];

	private static readonly Dictionary<Type, HashSet<Type>> _derivedTypes = [];
	private static readonly Dictionary<Type, HashSet<Type>> _derivedConcreteTypes = [];

	//======================================================================| Methods

	public static IReadOnlySet<Type> GetDerivedTypes<T>() {

		if (_derivedTypes.TryGetValue(typeof(T), out var result))
			return result;

		var minimumSet = _derivedTypes
			.Where(pair => pair.Key.IsAssignableTo(typeof(T)))
			.MinBy(pair => pair.Value.Count)
			.Value ?? _types;

		return _derivedTypes[typeof(T)] = [..minimumSet
			.Where(type => typeof(T).IsAssignableFrom(type))
		];
			
	}

	public static IReadOnlySet<Type> GetDerivedConcreteTypes<T>() {
		
		if (_derivedConcreteTypes.TryGetValue(typeof(T), out var result))
			return result;

		IEnumerable<Type> minimumSet;

		if (_derivedTypes.TryGetValue(typeof(T), out var set)) {
			minimumSet = set;
		}
		else {
			minimumSet = _derivedConcreteTypes
				.Where(pair => pair.Key.IsAssignableTo(typeof(T)))
				.MinBy(pair => pair.Value.Count)
				.Value ?? _types;
		}

		return _derivedConcreteTypes[typeof(T)] = [..minimumSet
			.Where(type => typeof(T).IsAssignableFrom(type))
			.Where(type => type is { IsAbstract: false, IsInterface: false })
		];

	}

}
