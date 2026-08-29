namespace Ichihime;

public class SlashCommandArgLocalizeDataBuilder {

	//======================================================================| Fields

	private string _name = "";
	private string _description = "";

	private readonly Dictionary<string, string> _choices = [];

	//======================================================================| Methods

	public SlashCommandArgLocalizeData Build() => new(
		_name, 
		_description, 
		_choices
	);

	public SlashCommandArgLocalizeDataBuilder WithName(string name) {
		_name = name;
		return this;
	}

	public SlashCommandArgLocalizeDataBuilder WithDescription(string description) {
		_description = description;
		return this;
	}

	public SlashCommandArgLocalizeDataBuilder AddChoice(string key, string name) {
		_choices.Add(key, name);
		return this;
	}

	public SlashCommandArgLocalizeDataBuilder WithProperty(ReadOnlySpan<string> keys, string value) {

		if (keys[0].Equals("Name", StringComparison.OrdinalIgnoreCase))
			return WithName(value);

		if (keys[0].Equals("Description", StringComparison.OrdinalIgnoreCase))
			return WithDescription(value);

		if (keys[0].Equals("Choice", StringComparison.OrdinalIgnoreCase))
			return AddChoice(keys[1], value);

		throw new InvalidOperationException();

	}


}