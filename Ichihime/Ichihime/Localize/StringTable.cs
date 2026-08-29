namespace Ichihime;

public class StringTable {

	//======================================================================| Fields

	private readonly Dictionary<string, string> _rawData =
		new(StringComparer.OrdinalIgnoreCase);

	private readonly Dictionary<string, SlashCommandLocalizeData> _slashCommands =
		new(StringComparer.OrdinalIgnoreCase);

	//======================================================================| Properties

	public IReadOnlyDictionary<string, string> RawData => _rawData;
	public IReadOnlyDictionary<string, SlashCommandLocalizeData> SlashCommands => _slashCommands;

	//======================================================================| Constructors

	public StringTable(IReadOnlyDictionary<string, string> dataSet) {
		_rawData = dataSet.ToDictionary();
		ReloadData();
	}

	//======================================================================| Methods

	private void ReloadData() {

		Dictionary<string, SlashCommandLocalizeDataBuilder> slashCommandBuilders = [];

		foreach (var data in _rawData) {

			var keys = data.Key.Split('.');

			if (keys[0].Equals("SlashCommand", StringComparison.OrdinalIgnoreCase)) {
				
				if (!slashCommandBuilders.TryGetValue(keys[1], out var builder))
					builder = slashCommandBuilders[keys[1]] = new();

				builder.WithProperty(keys.AsSpan(2), data.Value);
				continue;

			}

		}

		_slashCommands.Clear();

		foreach (var (id, builder) in slashCommandBuilders) {
			_slashCommands.Add(id, builder.Build());
		}

	}

}
