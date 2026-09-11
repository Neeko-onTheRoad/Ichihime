using Ichihime.Mahjong;
using SkiaSharp;

namespace Ichihime.ResourceSystem;

public interface IHaiPictureProvider {

	public SKPicture RearPicture { get; }
	public SKPicture GetPicture(Hai hai);

}