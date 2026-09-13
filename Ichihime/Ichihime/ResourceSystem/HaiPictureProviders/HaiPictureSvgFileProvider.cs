using Ichihime.Mahjong;
using SkiaSharp;

namespace Ichihime.ResourceSystem;

public class HaiPictureSvgFileProvider : IHaiPictureProvider {

	//======================================================================| Fields

	private readonly Dictionary<Hai, SKPicture> _pictures = [ with(new HaiKindEqualityComparer()) ];

	//======================================================================| Propeties

	public SKPicture RearPicture { get; }
	public SKSize GeneralSize { get; }

	//======================================================================| Constructors

	public HaiPictureSvgFileProvider(string path, float pictureScale) {

		var frontPicture = SvgLoader.ToPicture(Path.Combine(path, "Front.svg"));
		RearPicture = SvgLoader.ToPicture(Path.Combine(path, "Back.svg"));

		GeneralSize = RearPicture.CullRect.Size;
		
		var recorder = new SKPictureRecorder();

		foreach (var hai in Hai.AllKinds) {

			var canvas = recorder.BeginRecording(frontPicture.CullRect);
			var picture = SvgLoader.ToPicture(GetPath(path, hai));
			var center = picture.CullRect;

			var matrix = SKMatrix.CreateScale(pictureScale, pictureScale, center.MidX, center.MidY);

			canvas.DrawPicture(frontPicture);
			canvas.DrawPicture(picture, matrix);

			_pictures[hai] = recorder.EndRecording();

		}

	}

	//======================================================================| Methods

	public SKPicture GetPicture(Hai hai) => _pictures[hai];

	private static string GetPath(string path, Hai hai) => Path.Combine(path, hai switch {

		Ton => "Ton",
		Nan => "Nan",
		Shā => "Shaa",
		Pē => "Pei",

		Sangenpai => hai.GetType().Name,

		Sūpai sūpai => $"{sūpai switch {

			Manzuhai => "Man",
			Pinzuhai => "Pin",
			Sōzuhai => "Sou",

			_ => throw new NotSupportedException()

		}}{sūpai.Number}{(sūpai.IsAkadora ? "-Dora" : "")}",

		_ => throw new NotSupportedException()

	} + ".svg");

}