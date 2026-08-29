using NetCord.Gateway;
using NetCord.Services.ApplicationCommands;

namespace Ichihime;

public abstract class SlashCommand(StringTables stringTables, Properties properties) : ApplicationCommandModule<ApplicationCommandContext> {

	//======================================================================| Properties

	protected abstract string CommandName { get; }

	protected StringTable StringTableOfUserLocale => stringTables[Context.Interaction.UserLocale];
	protected StringTable StringTableOfGuildLocale => stringTables[Context.Interaction.GuildLocale
		?? Context.Interaction.UserLocale
	];

	//======================================================================| Methods

	protected string ClampWithDiscordMessageLengthLimit(string message) {
		
		var countLimit = int.Parse(properties["MessageLengthLimit"]);

		if (message.Length <= countLimit) return message;

		return StringTableOfGuildLocale["Global.MessageLimitOver"]
			.Replace("{count}", countLimit.ToString());
	}

}