using SkiaSharp;

public static class SkiaExtensions {

	extension(IEnumerable<SKPicture> pictures) {

		public SKRect TotalBound() => pictures
			.Select(picture => picture.CullRect)
			.Aggregate(SKRect.Union);

	}

}