using Ichihime.Mahjong;
using SkiaSharp;
using Svg.Skia;

namespace Ichihime.ResourceSystem;

public class HaiPictureSvgFileProvider : IHaiPictureProvider {

	//======================================================================| Fields

	private Dictionary<string, SKPicture> _pictures = [];

	//======================================================================| Propeties

	public SKPicture RearPicture { get; }

	//======================================================================| Constructors

	public HaiPictureSvgFileProvider(string path) {

		var frontSvg = new SKSvg();
		frontSvg.Load(Path.Combine(path, "Front.svg"));
		var frontPicture = frontSvg.Picture ?? throw new FileNotFoundException();

		var rearSvg = new SKSvg();
		rearSvg.Load(Path.Combine(path, "Back.svg"));
		RearPicture = rearSvg.Picture ?? throw new FileNotFoundException();
		
		var recorder = new SKPictureRecorder();

		foreach (var hai in Hai.AllKinds) {
		
			var svg = new SKSvg();
			svg.Load(Path.Combine(path, hai switch {

				Ton => "Ton",
				Nan => "Nan",
				Shā => "Shaa",
				Pē => "Pei",

				Sangenpai => hai.GetType().Name,

				Sūpai sūpai => $"{sūpai switch {

					Manzuhai man => "Man",
					Pinzuhai pin => "Pin",
					Sōzuhai man => "Sou",

					_ => string.Empty

				}}{sūpai.Number}{(sūpai.IsAkadora ? "-Dora" : "")}",

				_ => string.Empty

			} + ".svg"));

			var canvas = recorder.BeginRecording(frontPicture.CullRect);

			canvas.DrawPicture(frontPicture);
			canvas.DrawPicture(svg.Picture);

			_pictures[hai.DisplayName] = recorder.EndRecording();

		}

	}

	//======================================================================| Methods

	public SKPicture GetPicture(Hai hai) => _pictures[hai.DisplayName];

}