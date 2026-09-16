using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Ichihime.Localizing;

public partial class StringTables : IReadOnlyDictionary<string, StringTable> {

	//======================================================================| Constructors

	private readonly Dictionary<string, StringTable> _tables = [];

	//======================================================================| Constructors

	public StringTables(SpreadsheetClient spreadsheetClient) {

		var rawList = spreadsheetClient.Read(SpreadsheetId.MainSheet, "StringTable");

		var header = rawList[0];
		var rows = rawList.Skip(1);

		Console.WriteLine(
			$"{header.Count - 1} of Locale found: [{string.Join(", ", header.Skip(1))}]"
		);

		for (int i = 1; i < header.Count; i++) {
			
			if (header[i] is not string locale) continue;

			Console.WriteLine($"Loading locale data: {locale}");

			var data = rows
				.Select(row => (
					Key: row[0] as string ?? "", 
					Value: row[i] as string ?? ""
				))
				.Where(pair => !string.IsNullOrEmpty(pair.Key))
				.ToDictionary();

			LoadReference(data);
			_tables[locale] = new(data);

		}

	}

	//======================================================================| Methods

	public IEnumerable<string> Keys => _tables.Keys;
	public IEnumerable<StringTable> Values => _tables.Values;

	public int Count => _tables.Count;

	public bool ContainsKey(string key) => _tables.ContainsKey(key);
	public bool TryGetValue(string key, [MaybeNullWhen(false)] out StringTable value) => _tables.TryGetValue(key, out value);
	public IEnumerator<KeyValuePair<string, StringTable>> GetEnumerator() => _tables.GetEnumerator();

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	//======================================================================| Operators

	public StringTable this[string key] => _tables[key];

	//======================================================================| Methods

	private static void LoadReference(Dictionary<string, string> data) {
		
		HashSet<string> targetKeys = [..data.Keys];
		HashSet<string> newKeys = [];

		int depth = 0;
		while (targetKeys.Count != 0) {
		
			foreach (var key in targetKeys) {
				
				var matches = AngleBreakRegex().Matches(data[key]);

				foreach (Match match in matches) {
					
					var target = match.Groups["data"].Value;
					data[key] = data[key].Replace($"<{target}>", data[target]);
					
				}

				if (AngleBreakRegex().IsMatch(data[key])) {
					newKeys.Add(key);
				}

			}

			targetKeys = newKeys;
			newKeys = [];

			depth++;

			if (depth > 100) {
				throw new InvalidDataException(
					"References of string table are too deep."
				);
			}

		}
				
	}

	[GeneratedRegex(@"<(?<data>.+?)>")]
	private static partial Regex AngleBreakRegex();

}