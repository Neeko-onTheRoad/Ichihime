using Ichihime.Localizing;
using Ichihime.Mahjong;
using Ichihime.ResourceSystem;
using NetCord.Rest;
using NetCord.Services.ApplicationCommands;
using SkiaSharp;

namespace Ichihime.SlashCommand;

public class ImageTestSlashCommand(
	StringTables stringTables,
	Properties properties,
	IHaiPictureProvider pictureProvider
) : SlashCommand(stringTables, properties) {

	//======================================================================| Methods

	[SlashCommand("image_test", "Check the bot's image generation. (split with ',')")]
	public InteractionMessageProperties ImageTest(string haiNames) {

		var properties = new InteractionMessageProperties();

		HashSet<string> notFound = [with(StringComparer.OrdinalIgnoreCase)];
		List<SKPicture> pictures = [];

		int currentIndex = 0;

		foreach (var haiName in haiNames.Split(',').Select(name => name.Trim())) {

			var hai = Hai.AllKinds
				.FirstOrDefault(hai => hai
					.DisplayName(StringTableOfGuildLocale)
					.Equals(haiName, StringComparison.OrdinalIgnoreCase)
				);

			if (hai is null) {
				notFound.Add(haiName);
				continue;
			}

			var xPosition = currentIndex * pictureProvider.GeneralSize.Width;

			var picture = pictureProvider
				.GetPicture(hai)
				.ApplyMatrix(SKMatrix.CreateTranslation(xPosition, 0f));

			pictures.Add(picture);
			currentIndex++;

		}

		if (notFound.Count != 0) {
			properties.Content = StringTableOfGuildLocale["TestImage.HaiNotFound"]
				.Replace("{contents}", string.Join(", ", notFound.Select(name => $"'{name}'")));
		}

		using var image = Drawing.DrawAllAndEncode(pictures);

		return properties
			.AddImageEmbed(image);

	}

}
