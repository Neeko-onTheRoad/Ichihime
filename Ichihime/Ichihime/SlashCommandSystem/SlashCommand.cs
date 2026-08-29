using NetCord.Services.ApplicationCommands;

namespace Ichihime;

public abstract class SlashCommand(StringTables stringTables) : ApplicationCommandModule<ApplicationCommandContext> {

	//======================================================================| Fields

	protected StringTables _stringTables = stringTables;

	//======================================================================| Properties

	protected abstract string CommandName { get; }

	protected StringTable StringTableOfUserLocale => _stringTables[Context.User.Locale ?? "en-US"];
	protected StringTable StringTableOfGuildLocale => _stringTables[Context.Guild?.PreferredLocale ?? "en-US"];

	protected SlashCommandLocalizeData LocalizeData => StringTableOfUserLocale.SlashCommands[CommandName];

}