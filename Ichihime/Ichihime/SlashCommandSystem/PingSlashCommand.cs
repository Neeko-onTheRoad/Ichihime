using NetCord.Services.ApplicationCommands;

namespace Ichihime;

public class PingSlashCommand(StringTables stringTables) : SlashCommand(stringTables) {

	//======================================================================| Properties

	protected override string CommandName => "ping";

	//======================================================================| Methods

	[SlashCommand("ping", "Check the bot's response.")]
	public string Ping(
		int repetitionCount = 1,
		string? alternativeMessage = null,
		SplitCharacter splitCharacter = SplitCharacter.Space
	) {
		
		var message = alternativeMessage ?? LocalizeData
			.Contexts["DefaultMessage"];

		var messages = Enumerable.Repeat(message, repetitionCount);
		var splitter = splitCharacter switch {
			SplitCharacter.NewLine => "\n",
			SplitCharacter.Comma => ", ",
			SplitCharacter.Space or _ => " "
		};

		return string.Join(splitter, messages);

	}

	//======================================================================| Types

	public enum SplitCharacter {
		NewLine,
		Comma,
		Space
	}

}