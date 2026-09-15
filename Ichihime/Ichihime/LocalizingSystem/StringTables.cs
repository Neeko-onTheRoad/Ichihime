	using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Ichihime.Localizing;

public class StringTables : IReadOnlyDictionary<string, StringTable> {

	//======================================================================| Constructors

	private readonly Dictionary<string, StringTable> _tables = [];

	//======================================================================| Constructors

	public StringTables(SpreadsheetClient spreadsheetClient) {

		LoadDataFromSpreadSheet(spreadsheetClient);
		

	}

	//======================================================================| Methods

	public IEnumerable<string> Keys => _tables.Keys;
	public IEnumerable<StringTable> Values => _tables.Values;

	public int Count => _tables.Count;

	public bool ContainsKey(string key) => _tables.ContainsKey(key);
	public bool TryGetValue(string key, [MaybeNullWhen(false)] out StringTable value) => _tables.TryGetValue(key, out value);
	public IEnumerator<KeyValuePair<string, StringTable>> GetEnumerator() => _tables.GetEnumerator();

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	private void LoadDataFromSpreadSheet(SpreadsheetClient spreadsheetClient) {
	
		var rawList = spreadsheetClient.Read(SpreadsheetId.MainSheet, "StringTable");

		var header = rawList[0];
		var rows = rawList.Skip(1);

		Console.WriteLine(
			$"{header.Count - 1} of Locale found: [{string.Join(", ", header.Skip(1))}]"
		);

		for (int i = 1; i < header.Count; i++) {
			
			if (header[i] is not string locale) continue;

			Console.WriteLine($"Loading locale data: {locale}");

			_tables[locale] = new(rows
				.Select(row => (
					Key: row[0] as string ?? "", 
					Value: row[i] as string ?? ""
				))
				.Where(pair => !string.IsNullOrEmpty(pair.Key))
				.ToDictionary()
			);

		}

	}

	private void 

	//======================================================================| Operators

	public StringTable this[string key] => _tables[key];

}