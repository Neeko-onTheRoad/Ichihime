namespace Ichihime;

public record struct SlashCommandArgLocalizeData(

	in string Name,
	in string Description,

	in IReadOnlyDictionary<string, string> Choices

);