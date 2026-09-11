using Ichihime.Localizing;
using Ichihime.Mahjong;
using Ichihime.ResourceSystem;
using NetCord.Rest;
using NetCord.Services.ApplicationCommands;

namespace Ichihime.SlashCommand;

public class TestCommands(
	StringTables stringTables,
	Properties properties,
	IHaiPictureProvider pictureProvider
) : SlashCommand(stringTables, properties) {

	//======================================================================| Methods

	[SlashCommand("ping", "Check the bot's response.")]
	public string Ping(
		int repetitionCount = 1,
		string? alternativeMessage = null,
		SplitCharacter splitCharacter = SplitCharacter.Space
	) {
		
		var message = alternativeMessage
			?? StringTableOfGuildLocale["Ping.DefaultMessage"];

		var messages = Enumerable.Repeat(message, repetitionCount);
		var splitter = splitCharacter switch {
			SplitCharacter.NewLine => "\n",
			SplitCharacter.Comma => ", ",
			SplitCharacter.Space or _ => " "
		};

		var result = string.Join(splitter, messages);
		return ClampWithDiscordMessageLengthLimit(result);

	}

	[SlashCommand("test_image", "Check the bot's image generation.")]
	public InteractionMessageProperties TestImage(string haiName) {
		
		var properties = new InteractionMessageProperties();
		var hai = Hai.AllKinds.FirstOrDefault(h => h.DisplayName == haiName);

		if (hai is null) {
			properties.Content = StringTableOfGuildLocale["TestImage.HaiNotFound"];
			return properties;
		}

		var stream = pictureProvider.GetPicture(hai);



	}

	//======================================================================| Types
	
	public enum SplitCharacter {
		NewLine,
		Comma,
		Space
	}

}
