using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Ichihime;

public class Properties(SpreadsheetClient spreadsheetClient) : IReadOnlyDictionary<string, string> {

	//======================================================================| Fields

	private readonly Dictionary<string, string> _dataSet = spreadsheetClient
		.Read(SpreadsheetId.MainSheet, "Properties")?
		.Select(list => (list[0] as string, list[1] as string))
		.Cast<(string, string)>()
		.ToDictionary() ?? [];

	//======================================================================| Properties

	public int Count => _dataSet.Count;

	public IEnumerable<string> Keys => _dataSet.Keys;
	public IEnumerable<string> Values => _dataSet.Values;

	//======================================================================| Methods

	public bool ContainsKey(string key) => _dataSet.ContainsKey(key);
	public bool TryGetValue(string key, [MaybeNullWhen(false)] out string value) => _dataSet.TryGetValue(key, out value);

	public IEnumerator<KeyValuePair<string, string>> GetEnumerator() => _dataSet.GetEnumerator();
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	
	//======================================================================| Operators

	public string this[string key] => _dataSet[key];

}
