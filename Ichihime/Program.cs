using Ichihime.ResourceSystem;

namespace Ichihime;

public static class Program {

	public static async Task Main() {

		IchihimeBot ichihime = new(

			new ServiceInstance<IHaiPictureProvider>(new HaiPictureSvgFileProvider(
				path: Path.Combine("Resources", "HaiImageSvg"),
				pictureScale: 0.85f
			))

		);

		await ichihime.Start();
		await ichihime.WaitForShutdown();

	}

}