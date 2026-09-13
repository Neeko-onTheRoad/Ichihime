using SkiaSharp;

public static class Drawing {

	public static SKPicture CombineAll(params IList<SKPicture> pictures) {

		using SKPictureRecorder recorder = new();
		using var canvas = recorder.BeginRecording(pictures.TotalBound());

		foreach (var picture in pictures) {
			canvas.DrawPicture(picture);
		}

		return recorder.EndRecording();

	}

	public static SKImage DrawAll(params IList<SKPicture> pictures) {

		var bound = pictures.TotalBound();
		var width = (int)MathF.Ceiling(bound.Width);
		var height = (int)MathF.Ceiling(bound.Height);

		using var surface = SKSurface.Create(new SKImageInfo(
			width, height, SKColorType.Rgba8888, SKAlphaType.Premul
		));

		using var canvas = surface.Canvas;

		canvas.Clear(SKColors.Transparent);
		canvas.Translate(-bound.Left, -bound.Top);

		foreach (var picture in pictures) {
			canvas.DrawPicture(picture);
		}

		canvas.Flush();

		return surface.Snapshot();

	}

	public static SKData DrawAllAndEncode(

		IList<SKPicture> pictures,
		SKEncodedImageFormat format = SKEncodedImageFormat.Png,
		int quality = 100

	) {

		using var image = DrawAll(pictures);
		return image.Encode(format, quality);

	}

	extension(SKPicture picture) {

		public SKPicture ApplyMatrix(SKMatrix matrix) {

			var bounds = matrix.MapRect(picture.CullRect);

			using SKPictureRecorder recorder = new();
			var canvas = recorder.BeginRecording(bounds);

			canvas.DrawPicture(picture, matrix);

			return recorder.EndRecording();

		}

	}

}