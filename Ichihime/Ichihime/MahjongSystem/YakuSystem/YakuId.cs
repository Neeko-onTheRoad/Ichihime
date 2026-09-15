using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Ichihime;

public class YakuId(SpreadsheetClient spreadsheetClient) : IReadOnlyDictionary<int, string> {

	//======================================================================| Fields

	private readonly Dictionary<int, string> _dataSet = spreadsheetClient
		.Read(SpreadsheetId.MainSheet, "Yaku")?
		.Select(list => (int.Parse(list[0] as string ?? "-1"), list[1] as string))
		.Cast<(int, string)>()
		.ToDictionary() ?? [];

	//======================================================================| Properties

	public int Count => _dataSet.Count;

	public IEnumerable<int> Keys => _dataSet.Keys;
	public IEnumerable<string> Values => _dataSet.Values;

	//======================================================================| Methods

	public bool ContainsKey(int key) => _dataSet.ContainsKey(key);
	public bool TryGetValue(int key, [MaybeNullWhen(false)] out string value) => _dataSet.TryGetValue(key, out value);

	public IEnumerator<KeyValuePair<int, string>> GetEnumerator() => _dataSet.GetEnumerator();
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	
	//======================================================================| Operators

	public string this[int key] => _dataSet[key];

}
