using System.Security.AccessControl;

namespace Ichihime;

public class SlashCommandLocalizeDataBuilder {

	//======================================================================| Fields

	private string _name = "";
	private string _description = "";

	private readonly Dictionary<string, string> _contexts = [];
	private readonly Dictionary<string, SlashCommandArgLocalizeDataBuilder> _args =
		new(StringComparer.OrdinalIgnoreCase);

	//======================================================================| Methods
	
	public SlashCommandLocalizeData Build() {
		
		var args = _args
			.Select(pair => (pair.Key, pair.Value.Build()))
			.ToDictionary();

		return new(
			_name, _description, args, _contexts
		);

	}

	public SlashCommandLocalizeDataBuilder WithName(string name) {
		_name = name;
		return this;
	}

	public SlashCommandLocalizeDataBuilder WithDescription(string description) {
		_description = description;
		return this;
	}

	public SlashCommandLocalizeDataBuilder AddContext(string contextId, string value) {
		_contexts.Add(contextId, value);
		return this;
	}

	public SlashCommandLocalizeDataBuilder ModifyArg(string argId, Action<SlashCommandArgLocalizeDataBuilder> build) {
		build.Invoke(_args[argId]);
		return this;
	}

	public SlashCommandLocalizeDataBuilder WithProperty(ReadOnlySpan<string> keys, string value) {

		if (keys[0].Equals("Name", StringComparison.OrdinalIgnoreCase))
			return WithName(value);

		if (keys[0].Equals("Description", StringComparison.OrdinalIgnoreCase))
			return WithDescription(value);

		if (keys[0].Equals("Context", StringComparison.OrdinalIgnoreCase))
			return AddContext(keys[1], value);

		if (keys[0].Equals("Arg", StringComparison.OrdinalIgnoreCase)) {

			if (!_args.TryGetValue(keys[1], out var builder))
				builder = _args[keys[1]] = new();

			builder.WithProperty(keys[2..], value);
			return this;

		}

		throw new InvalidOperationException();

	}

}