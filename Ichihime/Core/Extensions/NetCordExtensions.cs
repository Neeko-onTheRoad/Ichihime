using NetCord.Rest;
using SkiaSharp;

public static class NetCordExtensions {

	extension (InteractionMessageProperties messageProperties) {
	
		public InteractionMessageProperties AddImageEmbed(SKData data, SKEncodedImageFormat format = SKEncodedImageFormat.Png) {

			var fileName = $"image.{Enum.GetName(format)}";

			MemoryStream stream = new();
			data.SaveTo(stream);
			stream.Position = 0;

			return messageProperties
				.AddAttachments(new AttachmentProperties(fileName, stream))
				.AddEmbeds(new EmbedProperties().WithImage("attachment://" + fileName));

		}

	}

}