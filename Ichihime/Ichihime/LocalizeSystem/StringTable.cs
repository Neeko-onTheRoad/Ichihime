using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Ichihime;

public class StringTable(IReadOnlyDictionary<string, string> dataSet) : IReadOnlyDictionary<string, string> {

	//======================================================================| Properties

	public int Count => dataSet.Count;

	public IEnumerable<string> Keys => dataSet.Keys;
	public IEnumerable<string> Values => dataSet.Values;

	//======================================================================| Methods

	public bool ContainsKey(string key) => dataSet.ContainsKey(key);
	public bool TryGetValue(string key, [MaybeNullWhen(false)] out string value) => dataSet.TryGetValue(key, out value);

	public IEnumerator<KeyValuePair<string, string>> GetEnumerator() => dataSet.GetEnumerator();
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	
	//======================================================================| Operators

	public string this[string key] => dataSet[key];

}
