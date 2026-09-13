using SkiaSharp;
using Svg.Skia;

public static class SvgLoader {

	public static SKPicture ToPicture(string path) {
		SKSvg svg = new();
		svg.Load(path);
		return svg.Picture ?? throw new FileNotFoundException();
	}

}