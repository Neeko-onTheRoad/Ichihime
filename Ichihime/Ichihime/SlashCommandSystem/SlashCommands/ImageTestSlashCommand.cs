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
	public InteractionMessageProperties ImageTest(string haiNames, int cardPerLine = 14) {

		var properties = new InteractionMessageProperties();
		
		HashSet<string> notFound = [ with(StringComparer.OrdinalIgnoreCase) ];
		List<Hai> hais = [];

		if (haiNames.Trim().Equals("all", StringComparison.OrdinalIgnoreCase)) {
			hais.AddRange(Hai.AllKinds);
		}
		else foreach (var name in haiNames.Split(',').Select(name => name.Trim())) {
		
			var hai = Hai.AllKinds
				.FirstOrDefault(hai => hai
					.DisplayName(StringTableOfUserLocale)
					.Equals(name, StringComparison.OrdinalIgnoreCase)
				);

			if (hai is null) {
				notFound.Add(name);
				continue;
			}

			hais.Add(hai);
		
		}

		int indexX = 0;
		int indexY = 0;
		List<SKPicture> pictures = [];

		foreach (var hai in hais) {

			var xPosition = indexX * pictureProvider.GeneralSize.Width;
			var yPosition = indexY * pictureProvider.GeneralSize.Height;

			var picture = pictureProvider
				.GetPicture(hai)
				.ApplyMatrix(SKMatrix.CreateTranslation(xPosition, yPosition));

			pictures.Add(picture);

			indexX++;
			if (indexX >= cardPerLine) {
				indexX = 0;
				indexY++;
			}

		}

		if (notFound.Count != 0) {
			properties.Content = StringTableOfGuildLocale["Command.TestImage.HaiNotFound"]
				.Replace("{contents}", string.Join(", ", notFound.Select(name => $"'{name}'")));
		}

		if (pictures.Count != 0) {
			using var image = Drawing.DrawAllAndEncode(pictures);
			properties.AddImageEmbed(image);
		}

		return properties;

	}

}
