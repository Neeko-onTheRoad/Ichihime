using Ichihime.Mahjong;
using SkiaSharp;

namespace Ichihime.ResourceSystem;

public interface IHaiPictureProvider {

	public SKSize GeneralSize { get; }
	public SKPicture RearPicture { get; }
	public SKPicture GetPicture(Hai hai);


}