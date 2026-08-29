namespace Ichihime;

public record struct SlashCommandLocalizeData(

	in string Name,
	in string Description,

	in IReadOnlyDictionary<string, SlashCommandArgLocalizeData> Args,
	in IReadOnlyDictionary<string, string> Contexts

);