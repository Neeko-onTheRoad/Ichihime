using Ichihime.Localizing;
using Ichihime.Mahjong;
using Ichihime.ResourceSystem;
using NetCord.Rest;
using NetCord.Services.ApplicationCommands;
using SkiaSharp;

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
		var hai = Hai.AllKinds.FirstOrDefault(h => h.DisplayName(StringTableOfGuildLocale) == haiName);

		if (hai is null) {
			properties.Content = StringTableOfGuildLocale["TestImage.HaiNotFound"]
				.Replace("{name}", haiName);
			return properties;
		}

		var picture = pictureProvider.GetPicture(hai);
		var bounds = picture.CullRect;

		var width = (int)MathF.Ceiling(bounds.Width);
		var height = (int)MathF.Ceiling(bounds.Height);

		using var surface = SKSurface.Create(new SKImageInfo(
			width, height, SKColorType.Rgba8888, SKAlphaType.Premul
		));

		var canvas = surface.Canvas;

		canvas.Clear(SKColors.Transparent);
		canvas.Translate(-bounds.Left, -bounds.Top);
		canvas.DrawPicture(picture);
		canvas.Flush();

		using var image = surface.Snapshot();
		using var data = image.Encode(SKEncodedImageFormat.Png, 100);

		var stream = new MemoryStream();
		data.SaveTo(stream);
		stream.Position = 0;

		return new InteractionMessageProperties()
			.AddAttachments(new AttachmentProperties("hai.png", stream))
			.AddEmbeds(
				new EmbedProperties()
					.WithImage("attachment://hai.png")
			);

	}

	//======================================================================| Types
	
	public enum SplitCharacter {
		NewLine,
		Comma,
		Space
	}

}
